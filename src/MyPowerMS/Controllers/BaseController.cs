using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.Models;
using MyPowerMS.BLL;

namespace MyPowerMS.Controllers
{
    public class BaseController : Controller
    {
        #region 接口
        IUserInfoBLL userService = new UserInfoBLL();
        #endregion
        public static T_UserInfo currentUser = null;   
        public BaseController()
        {
            currentUser = GetCurrentAccount();
        }
        /// <summary>
        /// 获取当前登陆人的账户信息
        /// </summary>
        /// <returns>账户信息</returns>
        protected T_UserInfo GetCurrentAccount()
        {
            if (Session["UserId"] != null)
            {
                return userService.GetById(Session["UserId"].ToString());
            }
            else
            {
                return null;
            }
        }
    }
}