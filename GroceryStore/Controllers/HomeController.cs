using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryStore.Models;
namespace GroceryStore.Controllers
{
    public class HomeController : Controller
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.FruitProduct = db.Products.Where(x => x.Category.Name.Equals("Fruits")).ToList();
            ViewBag.FoodgrainProduct = db.Products.Where(x => x.Category.Name.Equals("Foodgrains")).ToList();
            ViewBag.SnackProduct = db.Products.Where(x => x.Category.Name.Equals("Snack")).ToList();
            ViewBag.NonvegProduct = db.Products.Where(x => x.Category.Name.Equals("Nonveg")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();

            this.GetDefaultData();

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "Welcome to our contact page!";
            return View();
        }
    }
}