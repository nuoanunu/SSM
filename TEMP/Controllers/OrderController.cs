using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using SSM.Models;
using SSM.Models.Repository;

namespace SSM.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public String getAllProduct() {
            try {
                productRepository pr = new productRepository(new SSMEntities());
                List<softwareProduct> lst = pr.getAll();
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(lst);
            }
            catch (Exception e) {

            }
     
            return "";
        }
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