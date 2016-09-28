using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.TempModel
{
    public class EmailCategory
    {         

        public int id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> lastupdate { get; set; }
        public Nullable<System.DateTime> createddate { get; set; }
        public string creator { get; set; }
        public string color { get; set; }       
    }
}