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
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleinfoController : Controller
    {
        UserInfoBLL userbll = new UserInfoBLL();
        RolesInfoBLL rolebll = new RolesInfoBLL();
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {            
            var list = rolebll.GetAllList().ToList();          
            return View(list.ToPagedList(page, 2));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string RoleName, string RoleDesc)
        {
            T_RoleInfo model = new T_RoleInfo();
            model.id = StringHelper.GetGuid();
            model.RoleName = RoleName;
            model.RoleDesc = RoleDesc;           
            model.CreateDate = DateTime.Now;           
            try
            {
                rolebll.Add(model);
                return Json(new { success = true, msg = "操作成功" });          
            }
            catch
            {
                return Json(new { success = false, msg = "操作失败" });
            }

        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(string id)
        {
            T_RoleInfo model = rolebll.GetById(id);
            return View(model);
        }
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="RoleName"></param>
        /// <param name="RoleDesc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(string id, string RoleName, string RoleDesc)
        {
            T_RoleInfo model = rolebll.GetById(id);           
            model.RoleName = RoleName;
            model.RoleDesc = RoleDesc;          
            model.CreateDate = DateTime.Now;         
            try
            {
                if(rolebll.Update(model))
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
        public ActionResult Del(string id)
        {
            try
            {
               bool result= rolebll.Delete(rolebll.GetById(id));
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
        public ActionResult DelSelect(string ids)
        {
            try
            {
                string[] arr = ids.TrimEnd(new char[]{ ','}).Split(',');
                bool result = false;
                foreach (var item in arr)
                {
                    result = rolebll.Delete(rolebll.GetById(item));
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