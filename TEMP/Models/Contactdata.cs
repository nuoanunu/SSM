using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models
{
    public class Contactdata
    {
        public String FirstName { get; set; }
        public String lastname { get; set; }
        public String middlename { get; set; }
        public String email { get; set; }
        public String company { get; set; }
    }
    public class dealdata {
        Contactdata contact;
        List<taskdata> DealTask;
    }
    public class taskdata {
        public String MailContent { get; set; }
        public String subject { get; set; }
        public String FirstName { get; set; }
    }
}