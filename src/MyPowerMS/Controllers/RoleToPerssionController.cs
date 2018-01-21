using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPowerMS.BLL;
using MyPowerMS.Models;
using MyPowerMS.Common;
namespace MyPowerMS.Controllers
{
    /// <summary>
    /// 角色分配权限
    /// </summary>
    public class RoleToPerssionController : Controller
    {
        PermissionsBLL perssionbll = new PermissionsBLL();
        RolesInfoBLL rolebll = new RolesInfoBLL();
        RoleToPermissionsBLL bll = new RoleToPermissionsBLL();
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
                        name = item.Title,
                        PId = item.ParentId,
                        nocheck = true,
                        open = true,
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
                    result.Add(new PerssonTreeModel
                    {
                        Id = item.id,
                        name = item.Title,
                        PId = id,
                        open = false,
                        nocheck = false,
                        children = null
                    });
                }
            }
            return result;
        }

        /// <summary>
        /// 角色分配权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRolePerssion(string roleId,string ids)
        {
            ids = ids.TrimEnd(new char[] { ','});
            string[] arr = ids.Split(',');
            var dellist = bll.GetAllList().Where(m => m.RoleId == roleId).ToList();
            var addlist = new List<T_RoleToPermissions>();
            if(arr!=null && arr.Count()>0)
            {
                foreach(var item in arr)
                {
                    addlist.Add(new T_RoleToPermissions
                    {
                        id=StringHelper.GetGuid(),
                        Permissions=item,
                        RoleId=roleId
                    });
                }
            }
            if(bll.SaveRolePerssion(addlist,dellist))
            {
                return Json(new { success = true, msg = "操作成功" });
            }
            else
            {
                return Json(new { success = false, msg = "操作失败" });
            }
        }

        #region 权限树model     
    

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
            /// <summary>
            /// 是否展开节点
            /// </summary>
            public bool open { get; set; }
        }
        #endregion
    }
}