using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPowerMS.Models;
namespace MyPowerMS.BLL
{
    public class BaseService
    {
        protected UserInfoBLL userbll = new UserInfoBLL();
        protected UserToRoleBLL usertorolebll = new UserToRoleBLL();
        protected PermissionsBLL permissionbll = new PermissionsBLL();
        protected RolesInfoBLL rolebll = new RolesInfoBLL();
        protected RoleToPermissionsBLL roletoperbll = new RoleToPermissionsBLL();
        /// <summary>
        /// 获取当前登录用户的权限列表
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public  List<T_Permissions> GetPermissions(string userid)
        {
            var list = new List<T_Permissions>();
            try
            {                
                T_UserInfo user = userbll.GetById(userid);
                if (user != null)
                {
                    T_UserToRole usertorole = usertorolebll.GetById(userid);//用户拥有的角色
                    if (usertorole != null)
                    {
                        //该角色拥有的权限
                        List<T_RoleToPermissions> roletoplist = roletoperbll.GetAllList().Where(m => m.RoleId == usertorole.RoleId).ToList();
                        List<string> liststr = roletoplist.Select(m => m.Permissions).ToList();
                        list = permissionbll.GetAllList().Where(s => liststr.Contains(s.id)).ToList();
                    }
                }
            }
            catch
            {
               
            }
            return list;
        }
    }
}
