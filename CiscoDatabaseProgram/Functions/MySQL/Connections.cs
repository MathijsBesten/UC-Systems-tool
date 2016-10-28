using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Connections
    {
        public static MySqlConnection MainDB()
        {
            MySqlConnection connection = Functions.MySQL.General.MySQLConnnection(
                Settings.Default.MainServerIP,
                Settings.Default.MainServerDatabase,
                Settings.Default.MainServerUsername,
                Settings.Default.MainServerPassword);  
            return connection;
        }
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.MySQL.General.MicrosoftSQLConnection(
                Settings.Default.CiscoToolServerIP,
                Settings.Default.CiscoToolServerDatabase,
                Settings.Default.CiscoToolServerUsername,
                Settings.Default.CiscoToolServerPassword);
            return connection;
        }
    }
}
    