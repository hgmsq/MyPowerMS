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
            var passwordnew = BaseSecurity.Md5Hash(password);
            T_UserInfo model = userService.GetAllList().Where(m => m.UserName == username).Where(m => m.PassWord == passwordnew).SingleOrDefault();
            if (model != null)
            {
                Session["UserId"] = model.id;
                Session["UserName"] = model.UserName;
                Session["password"] = model.PassWord;
                HttpCookie _cookie = new HttpCookie("User");
                _cookie.Values.Add("UserId", model.id);
                _cookie.Values.Add("UserName", model.UserName);
                //_cookie.Values.Add("Password", BaseSecurity.Base64Encode(model.PassWord));
                _cookie.Values.Add("Password",passwordnew);
                Response.Cookies.Add(_cookie);
                return RedirectToAction("Index", "AdminIndex");               
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            if (Request.Cookies["User"] != null)
            {
                HttpCookie _cookie = Request.Cookies["User"];
                _cookie.Expires = DateTime.Now.AddHours(-1);
                Response.Cookies.Add(_cookie);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}