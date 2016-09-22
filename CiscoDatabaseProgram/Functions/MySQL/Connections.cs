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
                ConfigurationManager.AppSettings["MainServerIP"],
                ConfigurationManager.AppSettings["MainServerDatabase"], 
                ConfigurationManager.AppSettings["MainServerUsername"], 
                ConfigurationManager.AppSettings["MainServerPassword"]);  
            return connection;
        }
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.MySQL.General.MicrosoftSQLConnection( 
                ConfigurationManager.AppSettings["CiscoToolServerIP"],
                ConfigurationManager.AppSettings["CiscoToolServerDatabase"],
                ConfigurationManager.AppSettings["CiscoToolServerUsername"],
                ConfigurationManager.AppSettings["CiscoToolServerPassword"]);
            return connection;
        }
    }
}
    