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
            //T_UserInfo model = new T_UserInfo();
            //model.id = Guid.NewGuid().ToString("N");
            //model.Role = "a1e96b68bc704fef988e6472e623366d";
            //model.UserName = "admin";
            //model.TrueName = "管理员";
            //model.PassWord = "111111";               
            //model.CreateDate = DateTime.Now;   
            //userService.Add(model);
            //return Content("执行成功！");
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            T_UserInfo model = userService.GetAllList().Where(m => m.UserName == username).Where(m=>m.PassWord==password).SingleOrDefault();
            if (model != null)
            {
                Session["UserId"] = model.id;
                Session["UserName"] = model.UserName;
                Session["password"] = model.PassWord;
                return RedirectToAction("Index", "Default");               
            }
            else
            {
                return View();
            }
        }
    }
}