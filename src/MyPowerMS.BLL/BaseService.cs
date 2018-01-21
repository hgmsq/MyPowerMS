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
            var result = new List<T_Permissions>();
            try
            {                
                T_UserInfo user = userbll.GetById(userid);
                if (user != null)
                {
                   // T_RoleInfo usertorole = usertorolebll.GetById(user.Role);//用户拥有的角色
                    if (!string.IsNullOrWhiteSpace(user.Role))
                    {
                        //该角色拥有的权限
                        List<T_RoleToPermissions> roletoplist = roletoperbll.GetAllList().Where(m => m.RoleId == user.Role).ToList();
                        List<string> liststr = roletoplist.Select(m => m.Permissions).ToList();  
                        //用户权限                      
                        list = permissionbll.GetAllList().Where(s => liststr.Contains(s.id)).ToList();
                        List<string> pids = list.Select(m => m.ParentId).Distinct().ToList();
                        result.Add(new T_Permissions {

                        });

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
