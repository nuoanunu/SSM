using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
namespace SSM.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderDetail(int id)
        {
            return View("orderDetail");
        }
        public ActionResult NewDeal(Deal newdeal, String responsiblesRole ,String options)
        {
            return View("CreateDeal");
        }
    
    }
}