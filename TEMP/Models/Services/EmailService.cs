using SSM.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SSM.Models.Services
{
    public class EmailServices
    {
        public static async Task SendMail(int dealID , int step)

        { DealRepository dealRepo = new DealRepository(new SSMEntities());
            System.Diagnostics.Debug.WriteLine("DAFUG");
            Deal deal = dealRepo.getByID(dealID);
            Plan_Step thisStep = new Plan_Step();
            List<Plan_Step> Steps = deal.PrePurchase_FollowUp_Plan.Plan_Step.ToList();
            foreach(Plan_Step stepp in Steps) {
                if (stepp.stepNo == step) thisStep = stepp;
            }
            String mailContent = thisStep.StepEmailContent;
            mailContent = Constant.replaceMailContent(deal, mailContent);
            var body = "{0}";
            var message = new MailMessage();
            message.To.Add(new MailAddress(deal.contact.emails));  // replace with valid value 
            message.From = new MailAddress("dwarpro@gmail.com");  // replace with valid value
            message.Subject = "Your email subject";
            SSMEntities context = new SSMEntities();

            message.Body = string.Format(body, mailContent);
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
               await  smtp.SendMailAsync(message);
                System.Diagnostics.Debug.WriteLine("yay ?");
            }
      
        }
    }
}