﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPowerMS.DAL;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
   public class RoleToPermissionsBLL : IRoleToPermissionsBLL
    {
        public readonly RoleToPermissions dal = new RoleToPermissions();
        /// <summary>
        /// 获取所有列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T_RoleToPermissions> GetAllList()
        {
            return dal.GetAllList();
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_RoleToPermissions GetById(string id)
        {
            return dal.GetById(id);
        }
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Add(T_RoleToPermissions model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T_RoleToPermissions model)
        {
            return dal.Update(model);
        }
    }
}