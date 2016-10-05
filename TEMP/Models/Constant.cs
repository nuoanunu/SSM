using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models
{
    public class Constant
    {
        public static string STRING_FIRSTNAME = "[FIRST NAME]";
        public static string STRING_PRODUCTNAME = "[PRODUCT NAME]";
        public static string STRING_DATE = "[DATE],[DAY],[TIME]";
        public static string STRING_DAY = "[DAY]";
        public static string STRING_TIME = "[TIME]";
        public static string STRING_CODE = "[CODE]";
        public static string STRING_POST = "[POST";
        public static string STRING_FEATURE = "[FEATURE";
        public static string STRING_COMPANY = "[COMPANY NAME]";
        public static string STRING_LINK = "[LINK";
        public static List<string> AllConstant = new List<string> { STRING_FIRSTNAME, STRING_PRODUCTNAME };
        public static string replaceMailContent(Deal deal, String content) {
            String result = content;
            while (content.Contains(STRING_FIRSTNAME)) {
                result = result.Replace(STRING_FIRSTNAME, deal.contact.FirstName);
            }
            while (content.Contains(STRING_PRODUCTNAME))
            {
                result = result.Replace(STRING_FIRSTNAME, deal.PrePurchase_FollowUp_Plan.softwareProduct.name);
            }
            while (content.Contains(STRING_DATE))
            {

                DealTask meeting = new DealTask();
                foreach (DealTask task in deal.DealTasks) {
                    if (task.type == 4) meeting = task;
                }
                result = result.Replace(STRING_FIRSTNAME, ((DateTime) meeting.Deadline).ToShortTimeString() );

            }
    
            return result;
        }
    }
}