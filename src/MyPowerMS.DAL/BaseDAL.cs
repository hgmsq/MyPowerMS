using System.Collections.Generic;
using DapperExtensions;
namespace MyPowerMS.DAL
{
    public class BaseDAL<T> where T : class
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public  IEnumerable<T> GetAllList()
        {
            return DapperBase.conn.GetList<T>();         
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  T GetById(string id)
        {
            return DapperBase.conn.Get<T>(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        public  bool Add(T model)
        {
           return DapperBase.conn.Insert(model);
        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        public  bool Delete(T model)
        {
           return DapperBase.conn.Delete(model);
        }
        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        public  bool Update(T model)
        {
           return DapperBase.conn.Update(model);
        }
    }
}
