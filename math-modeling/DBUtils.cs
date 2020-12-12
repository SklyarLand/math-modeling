using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_modeling
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "math_modeling";
            string username = "root";
            string password = "root";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
