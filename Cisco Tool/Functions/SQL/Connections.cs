using Cisco_Tool.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Functions.SQL
{
    class Connections
    {
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.SQL.General.MicrosoftSQLConnection( // Make connection with Database
                ConfigurationManager.AppSettings["CiscoToolServerIP"],// ip
                ConfigurationManager.AppSettings["CiscoToolServerDatabase"], // database
                ConfigurationManager.AppSettings["CiscoToolServerUsername"], // username
                ConfigurationManager.AppSettings["CiscoToolServerPassword"]);  // password
            return connection;
        }
    }
}
    