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
    /// 权限管理
    /// </summary>
    public class PerssionController : Controller
    {
        PermissionsBLL bll = new PermissionsBLL();
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
                        
            return View(bll.GetAllList().ToPagedList(page, 2));
        }
        public ActionResult Add()
        {
            var list = bll.GetAllList().Where(m => m.ParentId == "0").ToList();//获取一级权限列表   
            ViewBag.list = list;
            return View();
        }
        [HttpPost]
        public ActionResult Add(string Title,string ParentId,string Url, string Status = "1" )
        {
            T_Permissions model = new T_Permissions();
            model.id = StringHelper.GetGuid();
            model.ParentId = ParentId;
            model.Title = Title;
            model.Status = int.Parse(Status);//默认正常
            model.Url = Url;           
            model.CreateDate = DateTime.Now;           
            try
            {
                bll.Add(model);
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
            var list = bll.GetAllList().Where(m => m.ParentId == "0").ToList();//获取一级权限列表   
            ViewBag.list = list;
            T_Permissions model = bll.GetById(id);
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
        public ActionResult Edit(string id,string Title, string ParentId, string Url, string Status="1")
        {
            T_Permissions model = bll.GetById(id);            
            model.Title = Title;
            model.ParentId = ParentId;
            model.Status = int.Parse(Status);//默认正常
            model.Url = Url;
            model.CreateDate = DateTime.Now;
            try
            {
                if(bll.Update(model))
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
               bool result= bll.Delete(bll.GetById(id));
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
                    result = bll.Delete(bll.GetById(item));
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