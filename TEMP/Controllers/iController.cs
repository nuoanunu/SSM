using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEMP.Models;

namespace TEMP.Controllers
{
    public class iController : Controller
    {
        public SSMEntities2 dbcnt = new SSMEntities2();
    }
}