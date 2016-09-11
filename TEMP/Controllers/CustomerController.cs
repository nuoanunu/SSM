using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models.CreateModel;

namespace SSM.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {

            return View("NewCustomer");
        }
        
            public ActionResult newCompany()
        {
            NewCompanyModel model = new NewCompanyModel();
            return View("newCompany", model);
        }
    }
}