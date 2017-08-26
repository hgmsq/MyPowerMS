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
    public class LoginController : Controller
    {
        #region 接口
        IUserInfoBLL userService = new UserInfoBLL();        
        #endregion
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            T_UserInfo model = userService.GetAllList().Where(m => m.UserName == username).Where(m=>m.PassWord==BaseSecurity.Base64Decode(password)).SingleOrDefault();
            if (model != null)
            {
                Session["UserId"] = model.id;
                Session["UserName"] = model.UserName;
                Session["password"] = model.PassWord;
                return RedirectToAction("Index", "AdminIndex");               
            }
            else
            {
                return View();
            }
        }
    }
}