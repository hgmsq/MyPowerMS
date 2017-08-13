using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPowerMS.Common
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// 返回Guid字符串 
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
