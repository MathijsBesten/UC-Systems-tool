using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                PrivateValues.NIETAANZITTENserver, // ip
                PrivateValues.NIETAANZITTENserverDB, // database
                PrivateValues.NIETAANZITTENserverUsername, // username
                PrivateValues.NIETAANZITTENserverPassword
                );  // password
            return connection;
        }
        public static SqlConnection OwnDB()
        {
            SqlConnection connection = Functions.MySQL.General.MicrosoftSQLConnection( // Make connection with Database
                PrivateValues.OwnServer,// ip
                PrivateValues.OwnServerDatabase, // database
                PrivateValues.OwnServerUsername, // username
                PrivateValues.OwnServerPassword);  // password
            return connection;
        }
    }
}
    