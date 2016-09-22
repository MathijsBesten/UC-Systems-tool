using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using CiscoDatabaseProgram.Values;
using System.Configuration;

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
            string connectionString = "SERVER=" + ConfigurationManager.AppSettings["MainServerIP"] + ";" + "DATABASE=" + ConfigurationManager.AppSettings["MainServerDatabase"] + ";" + "UID=" + ConfigurationManager.AppSettings["MainServerUsername"] + ";" + "PASSWORD=" + ConfigurationManager.AppSettings["MainServerPassword"] + "; connection timeout= 3";
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
