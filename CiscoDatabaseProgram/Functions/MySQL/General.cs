using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using CiscoDatabaseProgram.Values;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class General
    {
        public static MySqlConnection MySQLConnnection(string server,string database,string username,string password) // makes connection with a database
        {
            string connectionString = "SERVER=" + server + ";" +"DATABASE=" +database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + "; connection timeout= 3 ";
            return new MySqlConnection(connectionString);    
        }
        public static MySqlConnection MySQLConnnection() // Uses default data
        {
            string connectionString = "SERVER=" + PrivateValues.NIETAANZITTENserver + ";" + "DATABASE=" + PrivateValues.NIETAANZITTENserverDB + ";" + "UID=" + PrivateValues.NIETAANZITTENserverUsername + ";" + "PASSWORD=" + PrivateValues.NIETAANZITTENserverPassword + "; connection timeout= 3";
            return new MySqlConnection(connectionString);
        }

        public static SqlConnection  MicrosoftSQLConnection(string server, string database, string username, string password) // connection to Own Database
        {
            string connectionString = "SERVER=" + server + ";" +
                "UID=" + username + ";" +
                "PASSWORD=" + password + ";" +
                "Persist Security Info=True;" +
                "DATABASE=" + database + ";" +
                "connection timeout= 3"; // time in seconds timeout

            return new SqlConnection(connectionString);
        }
    }
}
