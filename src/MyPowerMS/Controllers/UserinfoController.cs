using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.Models;
using MyPowerMS.BLL;
using MyPowerMS.Common;
using PagedList;

namespace MyPowerMS.Controllers
{
    public class UserinfoController : Controller
    {
        UserInfoBLL userbll = new UserInfoBLL();
        RolesInfoBLL rolebll = new RolesInfoBLL();
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            var result = new List<UserViewModel>();
            var list = userbll.GetAllList().ToList();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    result.Add(new UserViewModel {
                        Id =item.id,
                        UserName=item.UserName,
                        Password=item.PassWord,
                        RoleName=rolebll.GetById(item.Role)==null ?"": rolebll.GetById(item.Role).RoleName,
                        TrueName=item.TrueName,
                        Role=item.Role,
                        CreateDate=Convert.ToDateTime(item.CreateDate)
                    });
                }
            }
            return View(result.ToPagedList(page, 2));
        }
        public ActionResult Add()
        {
            ViewBag.RoleList = rolebll.GetAllList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(string UserName,string TrueName,string Role,string Password,string Pic)
        {
            T_UserInfo model = new T_UserInfo();
            model.id = StringHelper.GetGuid();
            model.PassWord =BaseSecurity.Md5Hash("111111");
            model.UserName = UserName;
            model.TrueName = TrueName;
            model.pic = Pic;
            model.CreateDate = DateTime.Now;
            model.Role = Role;
            try
            {
                
                userbll.Add(model);
                return Json(new { success = true, msg = "操作成功" });
          
            }
            catch
            {
                return Json(new { success = false, msg = "操作失败" });
            }

        }

        public ActionResult Edit(string id)
        {
            ViewBag.RoleList = rolebll.GetAllList();
            T_UserInfo model = userbll.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string id,string UserName, string TrueName, string Role, string Password, string Pic)
        {
            T_UserInfo model = userbll.GetById(id);           
            model.PassWord = BaseSecurity.Md5Hash(Password);
            model.UserName = UserName;
            model.TrueName = TrueName;
            model.CreateDate = DateTime.Now;
            model.Role = Role;
            model.pic = Pic;
            try
            {
                if(userbll.Update(model))
                {
                    return Json(new { success = true, msg = "操作成功" });
                }
                else
                {
                    return Json(new { success = false, msg = "操作失败" });
                }
            }
            catch
            {
                return Json(new { success = false, msg = "操作失败" });
            }
        } 
        [HttpPost]
        public ActionResult DelUser(string id)
        {
            try
            {
               bool result= userbll.Delete(userbll.GetById(id));
                if (result)
                {
                    return Json(new { success = true, msg = "操作成功" });
                }
                else
                {
                    return Json(new { success = false, msg = "操作失败" });
                }
            }
            catch(Exception ex)
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }

        [HttpPost]
        public ActionResult DelSelectUser(string ids)
        {
            try
            {
                string[] arr = ids.TrimEnd(new char[]{ ','}).Split(',');
                bool result = false;
                foreach (var item in arr)
                {
                    result = userbll.Delete(userbll.GetById(item));
                }             
                if (result)
                {
                    return Json(new { success = true, msg = "操作成功" });
                }
                else
                {
                    return Json(new { success = false, msg = "操作失败" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = "服务器内部错误" });
            }
        }
    }
}