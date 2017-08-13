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
   public class UserToRole
    {
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_UserToRole> GetAllList()
        {
            return DapperBase.conn.GetList<T_UserToRole>();
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_UserToRole GetById(string id)
        {
            return DapperBase.conn.Get<T_UserToRole>(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(T_UserToRole model)
        {
            DapperBase.conn.Insert<T_UserToRole>(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(T_UserToRole model)
        {
            return DapperBase.conn.Delete<T_UserToRole>(model);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_UserToRole model)
        {
            return DapperBase.conn.Update<T_UserToRole>(model);
        }
    }
}
