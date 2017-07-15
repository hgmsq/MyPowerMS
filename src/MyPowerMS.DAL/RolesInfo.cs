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
   public class RolesInfo
    {
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_RoleInfo> GetAllList()
        {
            return DapperBase.conn.GetList<T_RoleInfo>();
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_RoleInfo GetById(string id)
        {
            return DapperBase.conn.Get<T_RoleInfo>(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(T_RoleInfo model)
        {
            return DapperBase.conn.Insert<T_RoleInfo>(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return DapperBase.conn.Delete<T_RoleInfo>(id);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_RoleInfo model)
        {
            return DapperBase.conn.Update<T_RoleInfo>(model);
        }
    }
}
