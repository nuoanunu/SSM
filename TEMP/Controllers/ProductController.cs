using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
using SSM.Models.Repository;

namespace SSM.Controllers
{
    public class ProductController : Controller
    {
        productRepository pr;
        // GET: Product
        public ProductController() {
            pr = new productRepository(new SSMEntities());
        }
        public ActionResult Index()
        {
            ViewData["productList"] = pr.getAll();
            return View("ProductList");
        }
        public ActionResult NewPlan()
        {
          
            return View("NewFollowUpPlan");
        }
        public ActionResult Detail(int id)
        {
            productRepository pr = new productRepository(new SSMEntities());
            try
            {
                softwareProduct product = pr.getById(id);
                if (product != null)
                {
                    ViewData["productDetail"] = product;
                    return View("ProductDetail");
                }
            }
            catch (Exception e) {
                
            }
            return RedirectToAction("Index");

        }
        public String CreateNewOption(String attID , String optCode, String optname, String optdes, String optprice,) {

        }



    }
}