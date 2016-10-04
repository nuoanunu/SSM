using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
using SSM.Models.Repository;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using SSM.Models.Services;

namespace SSM.Controllers
{
    public class ProductController : Controller
    {
        productRepository pr;
        // GET: Product
        public ProductController()
        {
            pr = new productRepository(new SSMEntities());
        }
        public ActionResult Index()
        {
            ViewData["productList"] = pr.getAll();
            return View("ProductList");
        }
        public ActionResult NewPlan(int productID)
        {
            SSMEntities se = new SSMEntities();

            ViewData["MailCate"] = se.EMAIL_Category.ToList();
            PrePurchase_FollowUp_Plan preplan = new PrePurchase_FollowUp_Plan();
            preplan.name = " New Followup plan - " + DateTime.Today;
            preplan.Description = " New plan";
            preplan.isActive = true;
            preplan.createDate = DateTime.Today;
            preplan.productID = productID;
            preplan.fullDuration = 0;
            se.PrePurchase_FollowUp_Plan.Add(preplan);
            se.SaveChanges();
            ViewData["planID"] = preplan.id;
            ViewData["Product"] = productID;
            return View("NewFollowUpPlan");
        }
        public ActionResult EditPlan(int planID)
        {
            SSMEntities se = new SSMEntities();
            ViewData["MailCate"] = se.EMAIL_Category.ToList();
            PrePurchase_FollowUp_Plan preplan = se.PrePurchase_FollowUp_Plan.Find(planID);
            ViewData["planID"] = preplan.id;
            ViewData["plan"] = preplan;
            ViewData["Product"] = preplan.softwareProduct.id;
            ViewData["steps"] = preplan.Plan_Step.ToList();
            // return View("EditFollowUpPlan");
            return View("FollowUpProgressEditor");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateNewPlan(int planID, String name, String description, String stepdata)
        {

            SSMEntities se = new SSMEntities();
            PrePurchase_FollowUp_Plan preplan = se.PrePurchase_FollowUp_Plan.Find(planID);
            if (preplan != null)
            {
                preplan.name = name;
                preplan.Description = description;
                se.SaveChanges();
            }
            System.Diagnostics.Debug.WriteLine(stepdata);
            String[] steps = stepdata.Split(new[] { "[endofStep]" }, StringSplitOptions.RemoveEmptyEntries);
            int index = 1;
            List<Plan_Step> lst = new List<Plan_Step>();
            foreach (String step in steps)
            {
                System.Diagnostics.Debug.WriteLine(step);
                String[] values = step.Split(new[] { "[endofmail]" }, StringSplitOptions.None);
                if (values.Length > 1)
                {
                    Plan_Step planstep = new Plan_Step();
                    planstep.planID = planID;
                    planstep.StepEmailContent = values[0];
                    planstep.TimeFromLastStep = int.Parse(values[1]);
                    planstep.stepNo = index;
                    se.Plan_Step.Add(planstep);

                    se.SaveChanges();
                    lst.Add(planstep);
                }
                index = index + 1;
            }
            for (int i = 0; i < index - 2; i++)
            {
                Plan_Step plan = lst[i];
                plan.nextStep = lst[i + 1].id;
            }
            for (int i = 1; i < index - 1; i++)
            {
                Plan_Step plan = lst[i];
                plan.previousStep = lst[i - 1].id;
            }
            se.SaveChanges();
            return RedirectToAction("Detail", "Product", new { id = preplan.softwareProduct.id });
        }
        [HttpPost]
        public ActionResult SetInactive(int planid, int productID)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                PrePurchase_FollowUp_Plan plan = se.PrePurchase_FollowUp_Plan.Find(planid);
                plan.isActive = false;
                se.SaveChanges();
                System.Diagnostics.Debug.WriteLine("cccccccc " + productID);
                return RedirectToAction("Detail", new { id = productID });
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("Index");

        }
        public ActionResult SetInactiveMarketPlan(int planid, int productID)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                productMarketPlan plan = se.productMarketPlans.Find(planid);
                plan.isActive = false;
                se.SaveChanges();
                System.Diagnostics.Debug.WriteLine("cccccccc " + productID);
                return RedirectToAction("Detail", new { id = productID });
            }
            catch (Exception e)
            {

            }

            return RedirectToAction("Index");

        }
        public ActionResult Detail(int id)
        {
            System.Diagnostics.Debug.WriteLine("12111211 " + id);
            productRepository pr = new productRepository(new SSMEntities());
            try
            {
                softwareProduct product = pr.getById(id);
                if (product != null)
                {
                    List<double> totalvalues = new List<double>();
                    ProductServices ps = new ProductServices();
                    for (int i = 0; i < 12; i++)
                    {
                        totalvalues .Add( ps.getMonthValues(i, product.id));
                        System.Diagnostics.Debug.WriteLine("added " + ps.getMonthValues(i, product.id))  ;
                    }
                    ViewData["productDetail"] = product;

                    ViewData["productperformance"] = totalvalues;
                    return View("ProductDescription");
                }
            }
            catch (Exception e)
            {

            }
            return RedirectToAction("Index");

        }
        public JsonResult CreateNewOption(int attID, String optCode, String optname, String optdes, float optprice)
        {
            try
            {
                attributeOption opt = new attributeOption();
                opt.attributeID = attID;
                opt.code = optCode;
                opt.name = optname;
                opt.price = optprice;
                opt.description = optdes;
                productRepository se = new productRepository(new SSMEntities());
                se.insertNewOption(opt);

                return Json(new { result = "true" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(new { result = "false" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNewAtt(int productID, String attname, String attcode, String attdes)
        {
            try
            {
                productAttribute att = new productAttribute();
                att.name = attname;
                att.productID = productID;
                att.code = attcode;
                att.description = attcode;
                productRepository se = new productRepository(new SSMEntities());
                se.insertNewAttribute(att);

                return Json(new { result = "true" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(new { result = "false" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNewMarketPlan(int productID, String planName, float price, float floorPrice, float ceilPrice, String optionIds, String newMarketPlanDes)
        {
            try
            {
                productMarketPlan att = new productMarketPlan();
                att.Name = planName;
                att.productID = productID;
                att.Description = newMarketPlanDes;
                att.Price = price;
                att.floorprice = floorPrice;
                att.ceilPrice = ceilPrice;
                att.isActive = true;
                att.operating = false;
                att.CreatedDay = DateTime.Today;
                string[] ids = optionIds.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                productRepository se = new productRepository(new SSMEntities());
                se.insertNewMarketPlan(att, ids);

                return Json(new { result = "true" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(new { result = "false" }, JsonRequestBehavior.AllowGet);

        }
        public async Task<ActionResult> guimail()
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("nhatvhn99@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("dwarpro@gmail.com");  // replace with valid value
            message.Subject = "Your email subject";
            SSMEntities context = new SSMEntities();

            message.Body = string.Format(body, "dwarpro@gmail.com", "dwarpro@gmail.com", context.Email_Template.ToList().First().MailContent);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "dwarpro@gmail.com",  // replace with valid value
                    Password = "320395qww"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return Json(new { success = " suc" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = " fale" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult PrePlanSwitchStatus(int id)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                PrePurchase_FollowUp_Plan myplan = se.PrePurchase_FollowUp_Plan.Find(id);
                softwareProduct software = myplan.softwareProduct;
                foreach (PrePurchase_FollowUp_Plan plan in software.PrePurchase_FollowUp_Plan.ToList())
                {
                    if (plan.id != id)
                        plan.isOperation = false;
                }
                myplan.isOperation = !myplan.isOperation;
                se.SaveChanges();
                return Json(new { result = "succeed" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(new { result = "fail" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult MarketPlanSwitchStatus(int id)
        {
            try
            {
                SSMEntities se = new SSMEntities();
                productMarketPlan myplan = se.productMarketPlans.Find(id);
                myplan.operating = !myplan.operating;
                se.SaveChanges();
                return Json(new { result = "succeed" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {

            }
            return Json(new { result = "fail" }, JsonRequestBehavior.AllowGet);
        }
    }
}