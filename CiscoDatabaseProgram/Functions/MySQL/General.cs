using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class General
    {
        public static MySqlConnection MakeMySQLConnnection(string server,string database,string username,string password) // makes connection with a database
        {
            string connectionString = "SERVER=" + server + ";" +"DATABASE=" +database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            return new MySqlConnection(connectionString);    
        }
        public static SqlConnection  MicrosoftSQLConnection(string server, string database, string username, string password)
        {
            string connectionString = "SERVER=" + server + ";" +
                "UID=" + username + ";" +
                "PASSWORD=" + password + ";" +
                "Persist Security Info=True;" +
                "DATABASE=" + database + ";" +
                "connection timeout=10";

            return new SqlConnection(connectionString);
        }
    }
}
