//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPowerMS.Models
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>  
    /// 用户角色关联表  
    /// </summary>
    public partial class T_UserToRole
    {
        /// <summary>  
    	///   
    	/// </summary> 
        public string id { get; set; }
        /// <summary>  
    	///   
    	/// </summary> 
        public string UserId { get; set; }
        /// <summary>  
    	///   
    	/// </summary> 
        public string RoleId { get; set; }
        /// <summary>  
    	/// 创建日期  
    	/// </summary> 
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
