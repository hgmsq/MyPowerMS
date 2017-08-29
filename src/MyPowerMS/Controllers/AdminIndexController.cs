using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.Models;
using MyPowerMS.Common;
using MyPowerMS.BLL;
using MyPowerMS.Extensions;

namespace MyPowerMS.Controllers
{
    //[UserAuthorize]
    public class AdminIndexController:BaseController
    {       
        // GET: AdminIndex
        public ActionResult Index()
        {
            //string str = Session["UserName"].ToString();
            ViewBag.perssionList = GetPermissions();
            return View();
        }
    }
}