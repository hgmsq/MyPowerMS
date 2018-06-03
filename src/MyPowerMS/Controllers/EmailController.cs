using MyPowerMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPowerMS.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="recipient"></param>
        /// <param name="mailtitle"></param>
        /// <param name="emailContent"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendEmail(string recipient, string mailtitle, string emailContent)
        {
            try
            {
                string senderServerIp = "smtp.qq.com";   //使用163代理邮箱服务器（也可是使用qq的代理邮箱服务器，但需要与具体邮箱对相应）
                string mailUsername = "431557313@qq.com";              //登录邮箱的用户名
                string mailPassword = "rqpsgfvcubwscafj"; //对应的登录邮箱的第三方密码（你的邮箱不论是163还是qq邮箱，都需要自行开通stmp服务）
                string mailPort = "25"; //发送邮箱的端口号
                string fromMailAddress = "431557313@qq.com";//你的邮箱

                string toMailAddress = recipient; //要发送对象的邮箱
                string subjectInfo = mailtitle;//主题
                string bodyInfo = emailContent;//以Html格式发送的邮件

                EmailHelper myEmail = new EmailHelper(senderServerIp, toMailAddress, fromMailAddress, subjectInfo, bodyInfo, mailUsername, mailPassword, mailPort, true, false);
                var result= myEmail.Send();
                return Json(new { success = true, msg = "邮件发送成功" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.ToString() });
            }
        }

    }
}