using System.Collections.Generic;
using MyPowerMS.DAL;
using MyPowerMS.Models;

namespace MyPowerMS.BLL
{
    public interface IBaseBLL
    {
        void Add<T>(T model);
        bool Delete<T>(T t);
        IEnumerable<T> GetAllList<T>(T t);
        T_RoleInfo GetById(string id);
        bool Update<T>(T t);
    }
}