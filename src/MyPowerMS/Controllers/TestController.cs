using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPowerMS.Controllers
{
    public class TestController : Controller
    {
        Common.StringHelper test { get; set; }
        // GET: Test
        public ActionResult Index()
        {
            string str = test1.Hello();
            return Content("111");
        }
    }
}