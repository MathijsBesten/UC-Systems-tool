using System.Data.SqlClient;

namespace Cisco_Tool.Functions.SQL
{
    class Connections
    {
        public static SqlConnection OwnDb()
        {
            SqlConnection connection = MicrosoftSqlConnection(
                Properties.Settings.Default.CiscoToolServerIP,
                Properties.Settings.Default.CiscoToolServerDatabase,
                Properties.Settings.Default.CiscoToolServerUsername,
                Properties.Settings.Default.CiscoToolServerPassword);
            return connection;
        }
        public static SqlConnection MicrosoftSqlConnection(string server, string database, string username, string password)
        {
            string connectionString = "SERVER=" + server + ";" +
                "UID=" + username + ";" +
                "PASSWORD=" + password + ";" +
                "Persist Security Info=True;" +
                "DATABASE=" + database + ";" +
                "Connection Timeout=1"; // time in seconds timeout
            return new SqlConnection(connectionString);
        }
    }
}
    