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
            SqlConnection connection = Functions.SQL.General.MicrosoftSQLConnection(
                ConfigurationManager.AppSettings["CiscoToolServerIP"],
                ConfigurationManager.AppSettings["CiscoToolServerDatabase"], 
                ConfigurationManager.AppSettings["CiscoToolServerUsername"], 
                ConfigurationManager.AppSettings["CiscoToolServerPassword"]);
            return connection;
        }
    }
}
    