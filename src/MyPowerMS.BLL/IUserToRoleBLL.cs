using System.Collections.Generic;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IUserToRoleBLL
    {
        void Add(T_UserToRole model);
        bool Delete(string id);
        IEnumerable<T_UserToRole> GetAllList();
        T_UserToRole GetById(string id);
        bool Update(T_UserToRole model);
    }
}