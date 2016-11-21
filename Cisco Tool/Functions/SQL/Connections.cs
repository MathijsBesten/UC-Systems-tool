using System.Data.SqlClient;

namespace Cisco_Tool.Functions.SQL
{
    class Connections
    {
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.SQL.General.MicrosoftSQLConnection(
                Properties.Settings.Default.CiscoToolServerIP,
                Properties.Settings.Default.CiscoToolServerDatabase,
                Properties.Settings.Default.CiscoToolServerUsername,
                Properties.Settings.Default.CiscoToolServerPassword);
            return connection;
        }
    }
}
    