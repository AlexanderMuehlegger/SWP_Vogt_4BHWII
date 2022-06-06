using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Models.DB {
    //TODO: asynchrone Programmierung
    interface IRepositoryUsers {

        Task ConnectAsync();
        Task DisconnectAsync();

        //CRUD-Operationen ... Create Read Update Delete
        bool Insert(User user);
        Task<bool> Delete(int userId);
        bool ChangeUserData(User newUserData);
        User GetUser(int userId);
        Task<List<User>> GetAllUsers();
        bool Login(string username, string password);

        //weitere Methoden


    }
}
