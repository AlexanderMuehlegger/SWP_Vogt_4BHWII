// using:entspricht "import" in JAVA
using Grundlagen.Models;
using System;
using System.Collections.Generic;
using System.IO;


// namespace: entspricht "package" in JAVA
namespace Grundlagen
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            //Variablen und Datentypen
            int age;
            string name;
            double value;   // float
            char choice;
            bool isMale;
            decimal salary; // immer für Geldbeträge verwenden
            DateTime birthdate;

            //Konstanten
            const double PI = 3.1415;
            const string PWD = "Sesam123";

            //Ausgabe
            //Console.ForegroundColor = ConsoleColor.Yellow;
            //Console.BackgroundColor = ConsoleColor.Cyan;
            Console.Clear();

            /*
            Console.WriteLine("erstes Programm");

            //Eingabe
            Console.Write("Ihr Alter: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("männlich [true/false]: ");
            isMale = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Alter: {0,10}; männlich: {1}, age, isMale");

            Console.WriteLine("PI = {0}; Math.PI = {1:f4}", PI, Math.PI);

            Console.WriteLine("Passwort = " + PWD);

            Console.WriteLine();
            */
            /*
            Auswahlanweisungen:
                - if
                - switch
                - ?:
            */
            /*
            Console.Write("Kommazahl: ");
            value = Convert.ToDouble(Console.ReadLine());

            if(value < 0)
            {
                Console.WriteLine("nagativ!");
            }
            else if(value > 0)
            {
                Console.WriteLine("positiv");
            }
            else {
                Console.WriteLine("0");
            }
            */

            /*
            string result;

            Console.Write("Kommazahl: ");
            value = Convert.ToDouble(Console.ReadLine());

            result = value >= 0 ? "positiv oder 0" : "negativ";

            Console.WriteLine("Ergebnis: " + result);
            */
            /*
            Department dep = Department.notSpecified;

            Console.Write("Abteilung [0...WI, 1...MA, usw.]:");
            dep = (Department)Convert.ToInt32(Console.ReadLine());

            switch (dep)
            {
                case Department.WI:
                    Console.WriteLine("Wirtschaft");
                    break;
                case Department.MA:
                    Console.WriteLine("Wirtschaft");
                    break;
                case Department.EL:
                    Console.WriteLine("Wirtschaft");
                    break;
                case Department.BM:
                    Console.WriteLine("Wirtschaft");
                    break;
                case Department.notSpecified:
                    Console.WriteLine("Wirtschaft");
                    break;
                default:
                    Console.WriteLine("falsche Eingabe");
                    break;
            }
            */


            /*
                Schleifen: for / while() / do while() / foreach

            */

            /*
            for (int i = 1; i <= 100; i+=10)
            {
                Console.WriteLine(i);
            }

            for (char i = 'A'; i <= 'Z'; i++)
            {
                Console.WriteLine("{0} -> {1}", i, (int)i);
            }

            int i = 100;

            while(i > 0)
            {
                Console.WriteLine(i);
                i -= 10;
            }
            */

            //Alter eingeben lassen, solange es nicht zwischen 10 und 100 liegt
            /*
            do
            {
                Console.WriteLine("Alter: ");
                age = Convert.ToInt32(Console.ReadLine());

            } while ((age > 100) || (age < 10));
            */

            //foreach
            //Generics: List, Dictionary, Stack, Queue
            //Arrays
            /*
            int[] zahlen = new int[20];
            int[] zahlen2 = { 1, 6, 11, 16, 21 };
            List<string> namen = new List<string> { "Alexander", "Josef", "Niklas", "Daniel" };

            Console.WriteLine("\nZahlen\n");
            foreach (int z in zahlen2)
            {
                Console.WriteLine(z);
            }

            Console.WriteLine("\nNamen\n");
            foreach (string n in namen)
            {
                Console.WriteLine(n);
            }

            Dictionary<string, List<string>> klasse = new Dictionary<string, List<string>>();

            klasse.Add("hw4b", new List<string> { "Dominik", "Fabian" });
            klasse.Add("hw3b", new List<string> { "Luca" });


            //Indexer
            klasse["hw4b"].Add("Florian");
            klasse["hw4b"].Add("Maxi");

            Console.WriteLine(klasse["hw4b"][1]);
            */




            // PrintPersonData();

            /*
            Person p1 = new Person();
            Person p2 = new Person(100, "Noah", "Muigg", Department.WI, new DateTime(2004, 4, 17), 2091.90m);    //m... für decimal

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            //bei einer Zuweisung (=) wird die set-Methode des Properties PersonId aufgerufen
            p1.PersonId = 200;
            p1.Firstname = "Jakob";
            p1.Lastname = "Resch";
            p1.Salary = 2099.90m;
            p1.Department = Department.WI;
            p1.Birthdate = new DateTime(2004, 12, 15);

            Console.WriteLine(p1);

            PrintPersonData(p1);
            PrintPersonData(p2);
            */
            /*
            Artikel a1 = new Artikel();
            Artikel a2 = new Artikel(1, "Apfel", "frischer Apfel", Artikelart.Lebensmittel, 1.20m);

            Console.WriteLine(a1);
            Console.WriteLine(a2);
            */

            string file = "C://tmp//file.txt";

            string content = ReadFile(file);

            Console.WriteLine(content);


            List<Person> people = new List<Person>();

            people.Add(new Student());
            people.Add(new Person());


            //Interface verwenden
            //      auf der linken Seite muss das Interface stehen
            IRepository rep = new RepositoryDB();


            //statische Klasse
            Console.WriteLine("Unser PI = " + StaticClass.PI);
            Console.WriteLine("10 + 34 = " + StaticClass.Add(10, 34));

            //normale Klasse mit statischen Members
            //statische Members verwenden
            NormalClassWithStaticMembers.Value = 309.90;
            Console.WriteLine("Value = " + NormalClassWithStaticMembers.Value);
            Console.WriteLine("DoStatic() = " + NormalClassWithStaticMembers.DoStatic());

            //normale Members verwenden
            NormalClassWithStaticMembers n = new NormalClassWithStaticMembers();
            n.Text = "Hallo";
            Console.WriteLine("Tet = " + n.Text);
            Console.WriteLine("Do() = " + n.Do());

        }


        //eine Methode sollte immer nur eine einzige Aufgabe ausführen
        public static void PrintPersonData()
        {
            Console.WriteLine("Daniel");
            Console.WriteLine("18.5.2004");
            Console.WriteLine("Zellbergeben");
        }

        public static void PrintPersonData(Person p)
        {
            //hier wird die get-Methode von PersonId aufgerufen
            Console.WriteLine("ID: " + p.PersonId);
            Console.WriteLine("Name: " + p.Name);
            Console.WriteLine("Geb.: " + p.Birthdate.ToShortDateString());
        }  

        public static string ReadFile(string pathAndFilename) {
            try
            {
                return File.ReadAllText(pathAndFilename);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Keine Berechtigung für diese Datei/Ordner!");
                //Meldung der Exceptionklasse ausgeben
                //Console.WriteLine(e.Message);
                //alle Methoden, die zuvor aufgerufen wurden
                //Console.WriteLine(e.StackTrace);

                //StackTrace und Message in eine Datei/DB loggen
            }
            catch (IOException)
            {
                Console.WriteLine("Fehler: Datei/Ordner/Pfad");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Fehler: Argument ist null");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Fehler: Argument");
            }
            catch (Exception)
            {
                Console.WriteLine("Irgendein anderer Fehler ist passiert!");
            }

            return null;
        }

    }
}
