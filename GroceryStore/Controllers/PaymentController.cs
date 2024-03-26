using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GroceryStore.Models;
using Razorpay.Api;

namespace GroceryStore.Controllers
{
    public class PaymentController : Controller
    {
        GroceryStoreDbContext db = new GroceryStoreDbContext();
        public OrderDetail _OrderDetail { get; set; }
        public ActionResult IntiateOrder()
        {
            
           

        string key = "rzp_test_umbrFAbVJ3slyJ";
        string secret = "su9eXFaihGucMmKECVRcRk0Q";

        Random _random = new Random();
        string TransactionId = _random.Next(0, 10000).ToString();




        Dictionary<string, object> input = new Dictionary<string, object>();
        input.Add("amount", Convert.ToDecimal(_OrderDetail.TotalAmount)* 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", TransactionId);



            RazorpayClient client = new RazorpayClient(key, secret);
        Razorpay.Api.Order order = client.Order.Create(input);


        ViewBag.OrderId = order["id"].ToString();

            return View("Index",_OrderDetail);

    }


}


}