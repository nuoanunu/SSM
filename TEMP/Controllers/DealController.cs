using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
using Microsoft.AspNet.Identity;
using Hangfire;
using SSM.Models.Services;
using SSM.Models.Repository;

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
        public ActionResult CreateDeal(Deal deal, int plan)
        {
            SSMEntities se = new SSMEntities();
            deal.planID = plan;
            deal.Creator = User.Identity.GetUserId();
            deal.StartDate = DateTime.Today;
            deal.Stage = 1;
            deal.Probability = 0;
            deal.CompleteOn = null;
            deal.LastUpdateStage = null;
            deal.Status = 1;

            se.Deals.Add(deal);
            se.SaveChanges();
            contact contact = se.contacts.Find(deal.Client);
            if (contact != null)
            {
                foreach (Plan_Step tep in se.PrePurchase_FollowUp_Plan.Find(plan).Plan_Step)
                {

                    if (tep.TimeFromLastStep == null) tep.TimeFromLastStep = 0;
                    dealdata data = new dealdata();
                    taskdata taskdata = new taskdata(tep);
                    Contactdata contactdata = new Contactdata(contact);
                    data.DealTask = taskdata;
                    data.contact = contactdata;
                    String mailContent = Constant.replaceMailContent(data, taskdata.MailContent);
               
                    if (tep.TimeFromLastStep == 0)
                    {

                        BackgroundJob.Schedule(() => EmailServices.SendMail(mailContent, contact.emails, taskdata.subject), TimeSpan.FromSeconds(10));

                    }
                    else
                    {
                        BackgroundJob.Schedule(() => EmailServices.SendMail(mailContent, contact.emails, taskdata.subject), TimeSpan.FromDays((int)tep.TimeFromLastStep));
                    }
                }
            }


            return RedirectToAction("Detail", new { id = deal.id });

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
                softwareProduct thisproduct = thisDeal.PrePurchase_FollowUp_Plan.softwareProduct;

                foreach (PrePurchase_FollowUp_Plan plan in thisproduct.PrePurchase_FollowUp_Plan.ToList())
                {
                    if (plan.isOperation) ViewData["ActiveFollowUpPlan"] = plan;
                }
            }
            catch (Exception e) { }

            return View("Detail");
        }
        public ActionResult CreateNewTask(int dealID, String title, String description, int type, String deadline)
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
            catch (Exception e)
            {
            }
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            List<SelectListItem> client = new List<SelectListItem>();
            List<SelectListItem> productPlan = new List<SelectListItem>();
            //new SelectListItem() {Text="Alabama", Value="AL"}
            SSMEntities se = new SSMEntities();
            String userID = User.Identity.GetUserId();
            AspNetUser thissalerep = se.AspNetUsers.Find(userID);
            foreach (contact_resposible crm in thissalerep.contact_resposible.ToList())
            {
                client.Add(new SelectListItem() { Text = crm.contact.FirstName + " " + crm.contact.MiddleName + " " + crm.contact.LastName, Value = crm.contactID + "" });
            }
            foreach (PrePurchase_FollowUp_Plan plan in se.PrePurchase_FollowUp_Plan.ToList())
            {
                productPlan.Add(new SelectListItem() { Text = plan.name, Value = plan.id + "" });
            }

            ViewData["ProductResponsibleFor"] = productPlan;
            ViewData["ClientResponsibleFor"] = client;
            return View("Create");
        }
        public void DealWon(int id)
        {
            SSMEntities se = new SSMEntities();
            DealRepository dealrepo = new DealRepository(se);
            Deal deal = dealrepo.getByID(id);
            if (deal != null)
            {
                deal.Status = 3;
                order order = new order();
                customer cus = new customer();
                cus.cusAddress = deal.contact.Street + " " + deal.contact.City + " " + deal.contact.Region + " ";
                cus.cusCompany = 1;
                cus.cusEmail = deal.contact.emails;
                cus.cusName = deal.contact.FirstName + " " + deal.contact.MiddleName + " " + deal.contact.LastName;
                cus.cusPhone = deal.contact.Phone;
                se.customers.Add(cus);
                se.SaveChanges();
                order.customerID = cus.id;
                float price = 0;
                order.orderNumber = 123123123;
                order.subtotal = deal.productMarketPlan.Price;
                order.status = 1;
                order.total = (double)order.subtotal * 1.1;
                order.VAT = (double)order.subtotal * 0.1;
                se.orders.Add(order);
                se.SaveChanges();
                MarketPlanPurchased mp = new MarketPlanPurchased();
                mp.orderID = order.id;
                mp.planID = deal.productMarketPlan.id;
                mp.productID = deal.productMarketPlan.productID;
                mp.SoldPrice = 10000;
                se.MarketPlanPurchaseds.Add(mp);
                se.SaveChanges();


            }
        }
    }
}