﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPowerMS.DAL;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
   public class RolesInfoBLL:IRolesInfoBLL
    {
        public readonly RolesInfo dal = new RolesInfo();
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_RoleInfo> GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_RoleInfo GetById(string id)
        {
            return dal.GetById(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(T_RoleInfo model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(T_RoleInfo model)
        {
            return dal.Delete(model);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_RoleInfo model)
        {
            return dal.Update(model);
        }

    }
}
