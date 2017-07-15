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
   public class RoleToPermissions : IRoleToPermissions
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
        public int Add(T_RoleToPermissions model)
        {
            return DapperBase.conn.Insert<T_RoleToPermissions>(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return DapperBase.conn.Delete<T_RoleToPermissions>(id);
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
    }
}
