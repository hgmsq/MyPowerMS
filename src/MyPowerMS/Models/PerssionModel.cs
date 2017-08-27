using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyPowerMS.Models;
namespace MyPowerMS.Models
{
    /// <summary>
    /// 用户权限model
    /// </summary>
    public class PerssionModel
    {
        /// <summary>
        /// 一级权限
        /// </summary>
        public T_Permissions ParentPermissions { get; set; }
        /// <summary>
        /// 子权限列表
        /// </summary>
        public List<T_Permissions> childrenList { get; set; }
    }
}