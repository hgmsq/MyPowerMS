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

        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5Hash(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
