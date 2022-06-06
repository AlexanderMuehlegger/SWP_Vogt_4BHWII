using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            //Instanz/Objekt von User erzeugen
            //  Objektinitalisierersyntax
            Student student = new Student() {
                StudentId = 100,
                FirstName = "Josef",
                LastName = "Strillinger",
                BirthDate = new DateTime(2004, 7, 8)
            };

            //User an die View übergeben
            return View(student);
        }
        public IActionResult AboutUs() {
            return View();
        }
    }
}
