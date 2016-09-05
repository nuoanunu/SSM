using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEMP.Controllers
{
    public class LicenseController : Controller
    {
        // GET: License
        public ActionResult Index()
        {
            return View("Manage");
        }
    }
}