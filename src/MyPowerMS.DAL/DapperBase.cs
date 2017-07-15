using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPowerMS.DAL
{
    /// <summary>
    /// 数据库连接对象
    /// </summary>
    public class DapperBase
    {
        private static string sqlConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public static IDbConnection conn = new SqlConnection(sqlConnection);
    }
}
