using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.CreateModel
{
    public class NewCompanyModel
    {
        public String companyName { get; set; }
        public String logo { get; set; }
        public String Industry { get; set; }
        public String EmployeeStatus { get; set; }
        public float annualIncome { get; set; }
        public String Comment { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String sites { get; set; }
        public String Street { get; set; }
        public String city { get; set; }
        public String region { get; set; }
        public String state { get; set; }
        public String Country { get; set; }
    }
}