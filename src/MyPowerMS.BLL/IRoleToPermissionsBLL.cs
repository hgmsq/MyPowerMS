using System.Collections.Generic;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IRoleToPermissionsBLL
    {
        void Add(T_RoleToPermissions model);
        bool Delete(T_RoleToPermissions model);
        IEnumerable<T_RoleToPermissions> GetAllList();
        T_RoleToPermissions GetById(string id);
        bool Update(T_RoleToPermissions model);
    }
}