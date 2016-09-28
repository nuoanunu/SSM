using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
namespace SSM.Controllers
{
    public class DealController : Controller
    {
        // GET: Deal
        public ActionResult Index()
        {
            ViewData["ActiveDeal"] = (new SSMEntities()).Deals.ToList();
            return View("");
        }
        public ActionResult Detail(int id)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                Deal thisDeal = se.Deals.Find(id);
                ViewData["DealDetail"] = thisDeal;
                ViewData["TaskStatus"] = se.TaskStatus.ToList();
                ViewData["TaskTypes"] = se.TaskTypes.ToList();
                softwareProduct thisproduct = thisDeal.Deal_Product.First().productMarketPlan.softwareProduct;

                foreach (PrePurchase_FollowUp_Plan plan in thisproduct.PrePurchase_FollowUp_Plan.ToList())
                {
                    if (plan.isOperation) ViewData["ActiveFollowUpPlan"] = plan;
                }
            }
            catch (Exception e) { }

            return View("Detail");
        }
        public ActionResult CreateNewTask(int dealID,String title,String description,int type, String deadline)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                DealTask task = new DealTask();
                task.dealID = dealID;
                task.Deadline = DateTime.Parse(deadline);
                task.CreateDate = DateTime.Today;
                task.status = 1;
                task.type = type;
                task.TaskDescription = description;
                task.TaskName = title;
                se.DealTasks.Add(task);
                se.SaveChanges();
                return RedirectToAction("Detail", new { id = dealID });
            }
            catch (Exception e) {
            }
            return RedirectToAction("Index");
          

        }
    }
}