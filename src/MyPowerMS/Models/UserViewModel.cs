using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPowerMS.Models
{
    /// <summary>
    /// 用户管理model
    /// </summary>
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string TrueName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string RoleName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}