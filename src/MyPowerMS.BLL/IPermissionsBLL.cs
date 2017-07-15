using System.Collections.Generic;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IPermissionsBLL
    {
        int Add(T_Permissions model);
        bool Delete(string id);
        IEnumerable<T_Permissions> GetAllList();
        T_Permissions GetById(string id);
        bool Update(T_Permissions model);
    }
}