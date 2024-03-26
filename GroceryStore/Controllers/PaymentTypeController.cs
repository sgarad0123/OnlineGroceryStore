using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GroceryStore.Models;

namespace GroceryStore.Controllers
{
    public class PaymentTypeController : Controller
    {
        private readonly GroceryStoreDbContext _context;

        public PaymentTypeController()
        {
            _context = new GroceryStoreDbContext(); // Replace 'YourDbContext' with your actual DbContext class
        }

        public ActionResult Index()
        {
            var paymentTypes = _context.PaymentTypes.ToList();
            return View(paymentTypes);
        }

        public ActionResult Details(int id)
        {
            var paymentType = _context.PaymentTypes.Find(id);
            return View(paymentType);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                _context.PaymentTypes.Add(paymentType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        public ActionResult Edit(int id)
        {
            var paymentType = _context.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }

            return View(paymentType);
        }

        [HttpPost]
        public ActionResult Edit(PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(paymentType).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        public ActionResult Delete(int id)
        {
            var paymentType = _context.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }

            return View(paymentType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var paymentType = _context.PaymentTypes.Find(id);
            if (paymentType == null)
            {
                return HttpNotFound();
            }

            _context.PaymentTypes.Remove(paymentType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
