using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SSM.Models;
using SSM.Models.Repository;
using SSM.Models.TempModel;
using SSM.ViewModels;

namespace SSM.Controllers
{
    public class MailTemplateController : Controller
    {
        EmailCategoryRepository cateRepo;
        MailTemplateRepository mailRepo;
        
        public MailTemplateController()
        {
            cateRepo = new EmailCategoryRepository(new SSMEntities());
            mailRepo = new MailTemplateRepository(new SSMEntities());
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Add()
        {   
            var viewModel = new CreateEmailTemplateViewModel
            {
                EmailTemplateEntity = new EmailTemplateEntity(),
                EmailCategories = getCategories()
            };
            return View("Add",viewModel);
        }

        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(CreateEmailTemplateViewModel viewModel)
        {            
            if (!ModelState.IsValid)
            {
                var newViewModel = new CreateEmailTemplateViewModel
                {
                    EmailTemplateEntity = viewModel.EmailTemplateEntity,
                    EmailCategories = getCategories()
                };
                return View("Add", newViewModel);
            }
            var emailTemplate = viewModel.EmailTemplateEntity;
            if (emailTemplate.id == 0)
            {
                emailTemplate.isActive = true;
                emailTemplate.createdDate = DateTime.Now;
                mailRepo.CreateNewEmailTemplate(emailTemplate);
            }
            else
            {
                mailRepo.EditMailTemplate(emailTemplate);
            }
            return RedirectToAction("Add", "MailTemplate");
        }

        public List<EmailCategory> getCategories()
        {
            var dbCategories = cateRepo.getAll();
            EmailCategory category = null;
            List<EmailCategory> cates = new List<EmailCategory>();
            foreach (var cate in dbCategories)
            {
                category = new EmailCategory();
                category.id = cate.id;
                category.Name = cate.Name;
                category.color = cate.color;
                category.createddate = cate.createddate;
                category.creator = cate.creator;
                category.description = cate.description;
                category.lastupdate = category.lastupdate;
                cates.Add(category);
            }
            return cates;
        }
    }
}