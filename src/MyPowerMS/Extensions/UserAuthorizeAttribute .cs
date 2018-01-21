using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.BLL;
using MyPowerMS.Models;
using MyPowerMS.Common;

namespace MyPowerMS.Extensions
{
    public class UserAuthorizeAttribute: AuthorizeAttribute
    {
        UserInfoBLL bll = new UserInfoBLL();
        
        /// <summary>
        /// 验证用户是否登陆
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //检查Cookies["User"]是否存在
            if (httpContext.Request.Cookies["User"] == null) return false;
            //验证用户名密码是否正确
            HttpCookie _cookie = httpContext.Request.Cookies["User"];
            string _userName = _cookie["UserName"];
            string _password = _cookie["Password"];
            httpContext.Response.Write("用户名:" + _userName);
            if (_userName == "" || _password == "") return false;            
            T_UserInfo model = bll.GetAllList().Where(m => m.UserName == _userName).Where(m => m.PassWord == BaseSecurity.Base64Encode(_password)).SingleOrDefault();
            if (model == null) return true;
            else return false;
        }
    }
}