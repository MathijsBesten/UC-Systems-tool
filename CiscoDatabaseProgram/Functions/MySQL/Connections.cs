using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Connections
    {
        public static MySqlConnection MainDB()
        {
            MySqlConnection connection = General.MySQLConnnection(
                Settings.Default.MainServerIP,
                Settings.Default.MainServerDatabase,
                Settings.Default.MainServerUsername,
                Settings.Default.MainServerPassword);  
            return connection;
        }
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = General.MicrosoftSQLConnection(
                Settings.Default.CiscoToolServerIP,
                Settings.Default.CiscoToolServerDatabase,
                Settings.Default.CiscoToolServerUsername,
                Settings.Default.CiscoToolServerPassword);
            return connection;
        }
    }
}
    