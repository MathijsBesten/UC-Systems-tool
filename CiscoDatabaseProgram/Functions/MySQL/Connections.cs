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
            MySqlConnection connection = Functions.MySQL.General.MySQLConnnection( // Make connection with Database
                ConfigurationManager.AppSettings["MainServerIP"], // ip
                ConfigurationManager.AppSettings["MainServerDatabase"], // database
                ConfigurationManager.AppSettings["MainServerUsername"], // username
                ConfigurationManager.AppSettings["MainServerPassword"] //password
                );  
            return connection;
        }
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.MySQL.General.MicrosoftSQLConnection( // Make connection with Database
                ConfigurationManager.AppSettings["CiscoToolServerIP"],// ip
                ConfigurationManager.AppSettings["CiscoToolServerDatabase"], // database
                ConfigurationManager.AppSettings["CiscoToolServerUsername"], // username
                ConfigurationManager.AppSettings["CiscoToolServerPassword"]);  // password
            return connection;
        }
    }
}
    