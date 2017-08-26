using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.BLL;
using MyPowerMS.Models;
namespace MyPowerMS.Controllers
{
    /// <summary>
    /// 角色分配权限
    /// </summary>
    public class RoleToPerssionController : Controller
    {
        PermissionsBLL perssionbll = new PermissionsBLL();
        RolesInfoBLL rolebll = new RolesInfoBLL();
        // GET: RoleToPerssion
        public ActionResult Index(string id)
        {
            ViewBag.role = rolebll.GetById(id);
            return View();
        }
        /// <summary>
        /// 获取目录树的json
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public JsonResult GetPerssionTree(string roleid)
        {
            var parentlist = perssionbll.GetAllList().Where(m=>m.ParentId=="0").ToList();
            var childrenlist = perssionbll.GetAllList().Where(m => m.ParentId != "0").ToList();
            var result = new List<PerssonTreeModel>();
            if (parentlist!=null && parentlist.Count>0)
            {
                foreach(var item in parentlist)
                {
                    result.Add(new PerssonTreeModel {
                        Id = item.id,
                        name =item.Title,
                        PId =item.ParentId,
                        nocheck= false,
                        children = GetChildrenList(item.id,childrenlist)
                    });
                }
            }
            return Json(result,JsonRequestBehavior.AllowGet);
            
        }
        /// <summary>
        /// 获取一级权限下面的子节点
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>

        public List<PerssonTreeModel> GetChildrenList(string id, List<T_Permissions> list)
        {
            var result = new List<PerssonTreeModel>();
            list = list.Where(m => m.ParentId == id).ToList();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    result.Add(new PerssonTreeModel {
                        Id = item.id,
                        name=item.Title,
                        PId=id,
                        nocheck = false,
                        children =null
                    });
                }
            }
            return result;
        }

        public class PerssonTreeModel           
        {
            public string Id { get; set; }
            /// <summary>
            /// 权限名称
            /// </summary>
            public string name { get; set; }
            public string PId { get; set; }
            /// <summary>
            /// 子节点
            /// </summary>
            public List<PerssonTreeModel> children { get; set; }
            /// <summary>
            /// 是否有复选框
            /// </summary>
            public bool nocheck { get; set; }
        }
    }
}