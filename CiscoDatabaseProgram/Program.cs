using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

using CiscoDatabaseProgram.Functions;
using MySql.Data.MySqlClient;
using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.MySQL;
using System.Data.SqlClient;

namespace CiscoDatabaseProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connectionToMainDB = Connections.MainDB(); // connection to main database
            List<router> mainDatabaseData =  Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB();
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery);
            Data.getNewByCompare(mainDatabaseData, OwnDatabaseData);


            Console.ReadLine();
        }
    }
}