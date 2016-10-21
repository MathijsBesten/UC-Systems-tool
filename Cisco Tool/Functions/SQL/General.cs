using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Cisco_Tool.Values;
using System.Configuration;

namespace Cisco_Tool.Functions.SQL
{
    class General
    {
        public static SqlConnection  MicrosoftSQLConnection(string server, string database, string username, string password)
        {
            string connectionString = "SERVER=" + server + ";" +
                "UID=" + username + ";" +
                "PASSWORD=" + password + ";" +
                "Persist Security Info=True;" +
                "DATABASE=" + database + ";" +
                "Connection Timeout=3"; // time in seconds timeout

            return new SqlConnection(connectionString);
        }
    }
}
