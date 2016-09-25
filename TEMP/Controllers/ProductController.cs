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
        public ActionResult NewPlan()
        {
            ViewData["MailCate"] = (new SSMEntities()).EMAIL_Category.ToList();
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
        public async Task<ActionResult> guimail() {
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
            return Json(new { success =" fale" }, JsonRequestBehavior.AllowGet);
        }
    }
    }