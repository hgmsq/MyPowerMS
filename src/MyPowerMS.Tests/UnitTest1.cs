using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyPowerMS.Common;
namespace MyPowerMS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string senderServerIp = "smtp.qq.com";   //使用163代理邮箱服务器（也可是使用qq的代理邮箱服务器，但需要与具体邮箱对相应）
            string toMailAddress = "hgmyz@outlook.com";              //要发送对象的邮箱
            string fromMailAddress = "431557313@qq.com";//你的邮箱
            string subjectInfo = "测试邮件";                  //主题
            string bodyInfo = "<p>你好，美好的一天</p>";//以Html格式发送的邮件
            string mailUsername = "431557313@qq.com";              //登录邮箱的用户名
            string mailPassword = "rqpsgfvcubwscafj"; //对应的登录邮箱的第三方密码（你的邮箱不论是163还是qq邮箱，都需要自行开通stmp服务）
            string mailPort = "25";                      //发送邮箱的端口号
                                                         //string attachPath = "E:\\123123.txt; E:\\haha.pdf";

            //创建发送邮箱的对象
            EmailHelper myEmail = new EmailHelper(senderServerIp, toMailAddress, fromMailAddress, subjectInfo, bodyInfo, mailUsername, mailPassword, mailPort, true, false);

            //添加附件
            //email.AddAttachments(attachPath);
            myEmail.Send();
  
        }
    }
}
