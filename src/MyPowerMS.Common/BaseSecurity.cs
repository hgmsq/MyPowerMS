using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyPowerMS.Common
{
    /// <summary>
    /// Base加密类库
    /// </summary>
    public class BaseSecurity
    {
        /// <summary>  
        /// BASE64加密字符串  
        /// </summary>  
        /// <param name="str">源字符串</param>  
        /// <returns></returns>   
        public static string Base64Encode(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        /// <summary>  
        /// BASE64解密字符串  
        /// </summary>  
        /// <param name="base64Str">Base64字串</param>  
        /// <returns></returns>   
        public static string Base64Decode(string base64Str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64Str));
        }
    }
}
