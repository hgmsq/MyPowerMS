using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.Models;
using MyPowerMS.BLL;
using MyPowerMS.Common;

namespace MyPowerMS.Controllers
{
    public class BaseController : Controller
    {
        #region 接口
        IUserInfoBLL userService = new UserInfoBLL();
        PermissionsBLL perssionbll = new PermissionsBLL();
        BaseService baseservice = new BaseService();       
        #endregion
        public static T_UserInfo currentUser = null;   
        public BaseController()
        { 
            currentUser = GetCurrentAccount();
            ViewBag.perssionList = GetPermissions();
        }
        public JsonResult GetPerssionList()
        {
            return Json(GetPermissions(),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        protected T_UserInfo GetCurrentAccount()
        {

            HttpCookie _cookie = CookieHelper.GetCookie("User");       

            if (_cookie["UserId"] != null)
            {
                return userService.GetById(_cookie["UserId"].ToString());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 当前用户拥有权限
        /// </summary>
        /// <returns></returns>
        protected List<PerssionModel> GetPermissions()
        {
            HttpCookie _cookie = CookieHelper.GetCookie("User");
            var result =new  List<PerssionModel>();
            if (_cookie["UserId"] != null)
            {
                var perssionlist=baseservice.GetPermissions(_cookie["UserId"].ToString());//子权限
                List<string> pids = perssionlist.Select(m => m.ParentId).Distinct().ToList();
                foreach(var item in pids)
                {
                    result.Add(new PerssionModel {
                        ParentPermissions = perssionbll.GetById(item),
                        childrenList=perssionlist.Where(m=>m.ParentId==item).ToList()
                    });
                }
                return result;
            }
            else
            {             
                return null;
            }
        }
    }
}