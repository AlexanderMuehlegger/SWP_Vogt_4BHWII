using FirstWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers {
    public class ShopController : Controller {
        public IActionResult Index() {
            //Artikel aus der DB laden und
            //Artikelliste an die View übergeben
            return View(LoadArticlesFromDB());
        }
        public IActionResult Search() {
            return View();
        }
        public IActionResult Basket() {
            return View();
        }




        private List<Article> LoadArticlesFromDB() {
            //Initialisierersyntax
            return new List<Article>() { 
                new Article(){ ArticleId = 100, ArticleName="iPhone", Brand = "Apple", ReleaseDate=new DateTime(2021,9,30)},
                new Article(){ ArticleId = 101, ArticleName="Maus", Brand = "Logitech", ReleaseDate=new DateTime(2019,7,16)},
                new Article(){ ArticleId = 102, ArticleName="TV12321", Brand = "Samsung", ReleaseDate=new DateTime(2011,2,22)},
                new Article(){ ArticleId = 103, ArticleName="Sneakers", Brand = "Bla", ReleaseDate=new DateTime(2020,4,3)},

            };

        }
    }
}
