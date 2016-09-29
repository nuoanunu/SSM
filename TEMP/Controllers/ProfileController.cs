using Microsoft.AspNet.Identity;
using SSM.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
namespace SSM.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            SSMEntities se = new SSMEntities();
            String userID = User.Identity.GetUserId();
            ViewData["SalerepDetail"] = se.SaleRepProfiles.SqlQuery("SELECT * FROM SaleRepProfile where userID='"+ userID + "'").FirstOrDefault();
            return View();
        }
        public JsonResult getThiscell(int cellid) {
            CalendarService cs = new CalendarService();
            bool result =cs.getScheduleByCell(cellid, User.Identity.GetUserId());
            if (result) {
                return Json(new { result = "yes" }, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(new { result = "no" }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult UpdateCalendar(String[] ids) {
            String userID = User.Identity.GetUserId();
            System.Diagnostics.Debug.WriteLine("AAAAAAAAAA " + "      userod " + userID) ;
        
            CalendarService cs = new CalendarService();
            cs.updateCalendar(ids, userID);
            return RedirectToAction("Index");
        }
    }
}