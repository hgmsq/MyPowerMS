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
   public class RoleToPermissions : BaseDAL<T_RoleToPermissions>
    {
        
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
