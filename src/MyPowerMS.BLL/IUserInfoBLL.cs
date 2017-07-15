using System.Collections.Generic;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IUserInfoBLL
    {
        void Add(T_UserInfo model);
        bool Delete(string id);
        IEnumerable<T_UserInfo> GetAllList();
        T_UserInfo GetById(string id);
        bool Update(T_UserInfo model);
    }
}