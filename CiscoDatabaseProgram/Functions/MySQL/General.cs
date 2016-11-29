using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class General
    {
        // timeout is in seconds

        public static MySqlConnection MySQLConnnection(string server,string database,string username,string password)
        {
            string connectionString = "SERVER=" + server + ";" +"DATABASE=" +database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + "; connection timeout= 3 ";
            return new MySqlConnection(connectionString);    
        }
        public static MySqlConnection MySQLConnnection() 
        {
            string connectionString = "SERVER=" + Settings.Default.MainServerIP + ";" + "DATABASE=" + Settings.Default.MainServerDatabase + ";" + "UID=" + Settings.Default.MainServerUsername + ";" + "PASSWORD=" + Settings.Default.MainServerPassword + "; connection timeout= 3";
            return new MySqlConnection(connectionString);
        }

        public static SqlConnection  MicrosoftSQLConnection(string server, string database, string username, string password) // connection to Own Database
        {
            string connectionString = "SERVER=" + server + ";" +
                "UID=" + username + ";" +
                "PASSWORD=" + password + ";" +
                "Persist Security Info=True;" +
                "DATABASE=" + database + ";" +
                "connection timeout= 3"; 

            return new SqlConnection(connectionString);
        }
    }
}
