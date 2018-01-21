using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.Models;
using MyPowerMS.Common;
using MyPowerMS.BLL;
namespace MyPowerMS.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            string str = Session["UserName"].ToString();
            return View();
        }
    }
}