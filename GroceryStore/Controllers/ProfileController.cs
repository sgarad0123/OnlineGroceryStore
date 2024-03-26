using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class ProfileController : Controller
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.admin_Employee.Find(TemData.EmpID));
        }
    }
}