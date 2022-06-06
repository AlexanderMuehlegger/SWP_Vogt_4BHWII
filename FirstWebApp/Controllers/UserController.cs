using FirstWebApp.Models;
using FirstWebApp.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers {
    public class UserController : Controller {

        //Regel: programmiere immer gegen eine Schnittstelle (Interface, Basisklasse)
        // => Programm ist leichter änderbar, flexibler, testbarer
        private IRepositoryUsers _rep = new RepositoryUsersDB();

        public async Task<IActionResult> Index() {
            //hier sollen alle User aus der DB-Tabelle geladen und an die View
            //weitergegeben werden

            try
            {
                await _rep.ConnectAsync();
                //User an die View übergeben
                return View(_rep.GetAllUsers());
            }
            catch (DbException)
            {
                return View("_Message", new Message("Benutzer", "Datenbankfehler",
                            "Bitte versuchen Sie es später erneut!"));
            }
            finally
            {
                await _rep.DisconnectAsync();
            }

        }

        //Parameter id: muss so lauten, da er in der Datei Startup.cs (ganz unten)
        //so benannt wurde
        public async Task<IActionResult> Delete(int id) {
            try
            {
                await _rep.ConnectAsync();
                _rep.Delete(id);
                return RedirectToAction("index");
            }
            catch (DbException)
            {
                return View("_Message", new Message("Benutzer", "Datenbankfehler",
                            "Bitte versuchen Sie es später erneut!"));
            }
            finally
            {
                await _rep.DisconnectAsync();
            }

            return View();
        }

        [HttpGet]
        //userId ... dieser Name muss mit dem Namen im Formular bei action übereinstimmen
        public async Task<IActionResult> ChangeUserData(int id) {
            try
            {
                await _rep.ConnectAsync();
                User user = _rep.GetUser(id);
                return View(user);
            } catch (DbException)
            {
                return View("_Message", new Message("Benutzer", "Datenbankfehler",
                            "Bitte versuchen Sie es später erneut!"));
            }
            finally
            {
                await _rep.DisconnectAsync();
            }
        }

        [HttpPost]
        //userId ... dieser Name muss mit dem Namen im Formular bei action übereinstimmen
        public async Task<IActionResult> ChangeUserData(User formData) {
            ValidateResitrationData(formData);
            if (ModelState.IsValid)
            {
                try
                {
                    await _rep.ConnectAsync();
                    if (!_rep.ChangeUserData(formData)) {
                        return View("_Message", new Message("User", "ERROR"));
                    }
                    else {
                        return View("_Message", new Message("User", "Ändern erfolgreich!"));
                    }
                }
                catch (DbException)
                {
                    return View("_Message", new Message("Benutzer", "Datenbankfehler",
                           "Bitte versuchen Sie es später erneut!"));
                }
                finally
                {
                    await _rep.DisconnectAsync();
                }
            }

            return View(formData);
        }

        [HttpGet]
        public IActionResult Registration() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(User userDataFromForm) {
            //Parameter überprüfen
            if (userDataFromForm == null)
            {
                //Weiterleitung an eine andere Action (Methode)
                //im selben Controller
                return RedirectToAction("Registration");
            }

            //Eingabedaten der Registrierung überprüfen - Validierung
            ValidateResitrationData(userDataFromForm);

            //unser Formular wurde richtig ausgefüllt
            if (ModelState.IsValid)
            {
                //TODO: Eingabedaten in einer DB abspeichern
                try
                {
                    await _rep.ConnectAsync();
                    if (_rep.Insert(userDataFromForm))
                    {
                        //unsere _Message-View aufrufen
                        return View("_Message", new Message("Registrierung", "Sie haben sich erfolgreich registriert!"));
                    }
                    else
                    {
                        return View("_Message", new Message("Registrierung", "Sie haben sich NICHT erfolgreich registriert!",
                                                "Bitte versuchen Sie es später erneut!"));
                    }
                }
                //DbException ... Basisklasse der Datenbank-Exceptions
                catch (DbException)
                {
                    return View("_Message", new Message("Registrierung", "Datenbankfehler!",
                                                "Bitte versuchen Sie es später erneut!"));
                }
                finally
                {
                    await _rep.DisconnectAsync();
                }
            }

            //das Formular wurde nicht richtig ausgefüllt
            //und die bereits eingegebenen Daten sollten wieder angezeigt werden
            return View(userDataFromForm);
        }

        private void ValidateResitrationData(User u) {
            //Parameter überprüfen
            if (u == null)
            {
                return;
            }

            //Username
            if ((u.Username == null) || (u.Username.Trim().Length < 4))
            {
                ModelState.AddModelError("Username", "Der Benutzername muss mindestens 4 Zeichen lang sein!");
            }

            //Password
            if ((u.Password == null) || (u.Password.Length < 8))
            {
                ModelState.AddModelError("Password", "Das Passwort muss mindestens 8 Zeichen lang sein!");
            }

            //Gender

            //Birthdate
            if (u.Birthdate > DateTime.Now)
            {
                ModelState.AddModelError("Birthdate", "Das Geburtsdatum darf nicht in der Zukunft sein!");
            }

            //EMail

        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(User formData) {
            try
            {
                await _rep.ConnectAsync();
                if(_rep.Login(formData.Username, formData.Password))
                {
                    return View("_Message", new Message("Anmeldung", "Sie haben sich erfolgreich angemeldet!"));
                }
                else
                {
                    return View("_Message", new Message("Anmeldung", "FEHLER bei der Anmeldung!"));
                }
            }
            catch (DbException)
            {
                return View("_Message", new Message("Registrierung", "Datenbankfehler!",
                                                "Bitte versuchen Sie es später erneut!"));
            }
            finally
            {
                await _rep.DisconnectAsync();
            }
        }



        //der Parameter der Methode muss gleich lauten, wie der vergebene Name bei den AJAX variablen
        public IActionResult checkEmail(string email) {
            // mit DB verbinden und überprüfen ob Email vorhanden ist
            if (email == "hallo@gmail.com")
                return new JsonResult(true);

            return new JsonResult(false);
        }
    }
}

