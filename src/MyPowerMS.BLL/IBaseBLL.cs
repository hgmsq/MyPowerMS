using System.Collections.Generic;
using MyPowerMS.DAL;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IRolesInfoBLL
    {
        void Add(T_RoleInfo model);
        bool Delete(T_RoleInfo model);
        IEnumerable<T_RoleInfo> GetAllList();
        T_RoleInfo GetById(string id);
        bool Update(T_RoleInfo model);
    }
}