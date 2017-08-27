using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPowerMS.Models;
using Dapper;
using DapperExtensions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MyPowerMS.DAL
{
   public class RoleToPermissions
    {
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_RoleToPermissions> GetAllList()
        {
            return DapperBase.conn.GetList<T_RoleToPermissions>();
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_RoleToPermissions GetById(string id)
        {
            return DapperBase.conn.Get<T_RoleToPermissions>(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(T_RoleToPermissions model)
        {
            DapperBase.conn.Insert<T_RoleToPermissions>(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(T_RoleToPermissions model)
        {
            return DapperBase.conn.Delete<T_RoleToPermissions>(model);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_RoleToPermissions model)
        {
            return DapperBase.conn.Update<T_RoleToPermissions>(model);
        }
        /// <summary>
        /// 分配权限
        /// </summary>
        /// <param name="addlist"></param>
        /// <param name="dellist"></param>
        /// <returns></returns>
        public bool SaveRolePerssion(List<T_RoleToPermissions> addlist, List<T_RoleToPermissions> dellist)
        {
            try
            {
                IDbTransaction transaction = null;
                if (dellist != null && dellist.Count > 0)
                {
                    foreach (var item in dellist)
                    {
                        DapperBase.conn.Delete(item, transaction);
                    }
                }
                DynamicParameters parameters = new DynamicParameters();
                //参数名，value  
                parameters.Add("Capacity", addlist.Count);
                if(addlist!=null && addlist.Count>0)
                {
                    foreach(var item in addlist)
                    {
                        DapperBase.conn.Insert(item, transaction);
                    }
                }
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
