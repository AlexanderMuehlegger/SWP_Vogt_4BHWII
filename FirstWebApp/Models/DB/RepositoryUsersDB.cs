using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models.DB {


    //parallele und asynchrone Programmierung
    //Thread's: sollten in C# nicht direkt verwendet werden (sie werden allerdings immer intern verwendet)
    //Task's (Aufgaben): sollten statt Thread's verwendet werden
    //async/await: verwendet im Hintergrund Task's und ermöglicht das die asynchrone und synchrone Programmierung 
    //      fast identisch ist
    //

    //diese Klasse implementiert unser interface
    public class RepositoryUsersDB : IRepositoryUsers {

        //Verbindungszeichenkette angeben: IP-Adresse des MySQL-Servers,
        //Datenbankname, User + Password am DB-Server
        private string _connectionString = "Server=localhost;database=web_4b;user=root;password=";
        //Verbindungsobjekt zum Zugriff auf die Datenbank
        //hiermit können SQL-Befehle an den DB-Server gesendet werden
        private DbConnection _conn;
        public async Task ConnectAsync() {
            //falls das Verbindungsobjekt noch nicht erzeugt wurde
            if(this._conn == null)
            {
                //wird es erzeugt
                this._conn = new MySqlConnection(this._connectionString);
            }
            //falls die Verbindung noch nicht hergestellt wurde
            if(this._conn.State != ConnectionState.Open)
            {
                //wird sie geöffnet
                await this._conn.OpenAsync();
            }
        }

        public async Task DisconnectAsync() {
            //falls das Verb.Objekt existiert und die Verbindung geöffnet ist
            if((this._conn != null) && (this._conn.State == ConnectionState.Open))
            {
                //wird sie geschlossen
                await this._conn.CloseAsync();
            }
        }

        public async Task<bool> Delete(int userId) {
            if (this._conn?.State == ConnectionState.Open)
            {
                DbCommand cmdDeleteUser = this._conn.CreateCommand();
                cmdDeleteUser.CommandText = "delete from users where user_id = @userid";

                DbParameter paramID = cmdDeleteUser.CreateParameter();

                paramID.ParameterName = "userid";
                paramID.DbType = DbType.Int32;
                paramID.Value = userId;
                cmdDeleteUser.Parameters.Add(paramID);

                return await cmdDeleteUser.ExecuteNonQueryAsync() == 1;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsers() {

            //leere Liste erzeugen
            List<User> users = new List<User>();

            if (this._conn?.State == ConnectionState.Open)
            {

                //leeres Command erzeugen
                DbCommand cmdAllUsers = this._conn.CreateCommand();
                //SQL-Befehl angeben
                cmdAllUsers.CommandText = "select * from users";

                //mit dem DbDatReader kann zeilenweise durch das Ergebnis gegangen werden
                using (DbDataReader reader = await cmdAllUsers.ExecuteReaderAsync())
                {
                    //Read() ... eine Zeile (Datensatz) lesen
                    while (reader.Read())
                    {
                        //und dann der Liste hinzufügen
                        users.Add(new User()
                        {
                            //UserId ... Name des Properties der Klasse User
                            //user_id ... Name des Feldes in der DB-Tabelle
                            UserId = Convert.ToInt32(reader["user_id"]),
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            EMail = Convert.ToString(reader["email"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"])
                        });
                        //DbNull.Value
                    }

                }//hier wird der DbDataReader automatisch wieder freigegeben
                 //hier wird die Methode Dispose() von DbDataReader aufgerufen
                 //kurze Schreibweise für try ... finally
            }

            //2 mögliche Fälle: entweder ist die Liste leer (kein User vorhanden)
            //oder sie beinhaltet alle User der DB-Tabelle
            return users;
        }


        public User GetUser(int userId) {

            User user;

            if (this._conn?.State == ConnectionState.Open)
            {
                DbCommand cmdUser = this._conn.CreateCommand();
                
                cmdUser.CommandText = "select * from users where user_id=@userId";

                DbParameter paramID = cmdUser.CreateParameter();
                paramID.ParameterName = "userId";
                paramID.DbType = DbType.Int32;
                paramID.Value = userId;

                cmdUser.Parameters.Add(paramID);

                using (DbDataReader reader = cmdUser.ExecuteReader())
                {

                    if (reader.Read()) {
                        return new User()
                        {
                            UserId = userId,
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"]),
                            Birthdate = Convert.ToDateTime(reader["birthdate"]),
                            EMail = Convert.ToString(reader["email"]),
                            Gender = (Gender)Convert.ToInt32(reader["gender"])
                        };
                    }

                }
            }
            return new User();
        }

        public bool Insert(User user) {
            if(this._conn?.State == ConnectionState.Open)
            {
                //ein leeres Command wird erzeugt
                DbCommand cmdInsert = this._conn.CreateCommand();
                //Parameter verwenden: @username
                //es werden damit SQL-Injections verhindert
                //SQL-Injection: ein Angreifer versucht einen SQL-Befehl einzuschleusen
                //und somit auszuführen
                cmdInsert.CommandText= "insert into users values(null, @username, sha2(@pwd, 512), @bDate, @mail, @gender);";

                //Parameter @username zusammenbauen
                DbParameter paramUN = cmdInsert.CreateParameter();
                //hier wird unser oben vergebener Parametername verwendet
                paramUN.ParameterName = "username";
                paramUN.DbType = DbType.String;
                paramUN.Value = user.Username;

                DbParameter paramPWD = cmdInsert.CreateParameter();
                paramPWD.ParameterName = "pwd";
                paramPWD.DbType = DbType.String;
                paramPWD.Value = user.Password;

                DbParameter paramBDate = cmdInsert.CreateParameter();
                paramBDate.ParameterName = "bDate";
                paramBDate.DbType = DbType.Date;
                paramBDate.Value = user.Birthdate;

                DbParameter paramEMail = cmdInsert.CreateParameter();
                paramEMail.ParameterName = "mail";
                paramEMail.DbType = DbType.String;
                paramEMail.Value = user.EMail;

                DbParameter paramGender = cmdInsert.CreateParameter();
                paramGender.ParameterName = "gender";
                paramGender.DbType = DbType.Int32;
                paramGender.Value = user.Gender;

                //dem Command (cmdInsert) die Parameter bekanntgeben
                cmdInsert.Parameters.Add(paramUN);
                cmdInsert.Parameters.Add(paramPWD);
                cmdInsert.Parameters.Add(paramBDate);
                cmdInsert.Parameters.Add(paramEMail);
                cmdInsert.Parameters.Add(paramGender);

                //das Command (INSERT-Befehl) an den DB-Server senden
                return cmdInsert.ExecuteNonQuery() == 1;

            }
            return false;
        }

        public bool Login(string username, string password) {
            if(this._conn?.State == ConnectionState.Open)
            {
                DbCommand cmdSelect = this._conn.CreateCommand();
                cmdSelect.CommandText = "select * from users where username=@username and password=sha2(@password, 512)";

                DbParameter paramUsername = cmdSelect.CreateParameter();
                paramUsername.ParameterName = "username";
                paramUsername.DbType = DbType.String;
                paramUsername.Value = username;
                cmdSelect.Parameters.Add(paramUsername);

                DbParameter paramPassword = cmdSelect.CreateParameter();
                paramPassword.ParameterName = "password";
                paramPassword.DbType = DbType.String;
                paramPassword.Value = password;
                cmdSelect.Parameters.Add(paramPassword);

                using (DbDataReader r = cmdSelect.ExecuteReader())
                {
                    return r.Read();
                }
            }
            return false;
        }

        public bool ChangeUserData(User newUserData) {
            if (this._conn?.State == ConnectionState.Open)
            {
                
                DbCommand cmdUpdate = this._conn.CreateCommand();
                cmdUpdate.CommandText = "update users set username=@username, password=@password, birthdate=@birthdate, email=@email, gender=@gender where user_id=@userId";

                DbParameter paramUN = cmdUpdate.CreateParameter();
                paramUN.ParameterName = "username";
                paramUN.DbType = DbType.String;
                paramUN.Value = newUserData.Username;

                DbParameter paramPWD = cmdUpdate.CreateParameter();
                paramPWD.ParameterName = "password";
                paramPWD.DbType = DbType.String;
                paramPWD.Value = newUserData.Password;

                DbParameter paramBD = cmdUpdate.CreateParameter();
                paramBD.ParameterName = "birthdate";
                paramBD.DbType = DbType.DateTime;
                paramBD.Value = newUserData.Birthdate;

                DbParameter paramEmail = cmdUpdate.CreateParameter();
                paramEmail.ParameterName = "email";
                paramEmail.DbType = DbType.String;
                paramEmail.Value = newUserData.EMail;

                DbParameter paramGender = cmdUpdate.CreateParameter();
                paramGender.ParameterName = "gender";
                paramGender.DbType = DbType.Int32;
                paramGender.Value = newUserData.Gender;

                DbParameter paramID = cmdUpdate.CreateParameter();
                paramID.ParameterName = "userId";
                paramID.DbType = DbType.Int32;
                paramID.Value = newUserData.UserId;

                cmdUpdate.Parameters.Add(paramUN);
                cmdUpdate.Parameters.Add(paramPWD);
                cmdUpdate.Parameters.Add(paramBD);
                cmdUpdate.Parameters.Add(paramEmail);
                cmdUpdate.Parameters.Add(paramGender);
                cmdUpdate.Parameters.Add(paramID);

                return cmdUpdate.ExecuteNonQuery() == 1;

            }
            return false;
        }
    }
}
