using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using log4net;
using MySql.Data.MySqlClient;
using General = CiscoDatabaseProgram.Functions.SerialNumbers.General;

namespace CiscoDatabaseProgram.Functions.Main
{
    class MainCode
    {
        private static readonly ILog log =
        LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void updateDatabase() // first run
        {
            log.Info("");
            log.Info("Timestampt: " + DateTime.Now);
            log.Info("COMPARING DATABASES");
            log.Info("Running...");
            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();

            MySqlConnection connectionToMainDB = Connections.MainDB();
            List<router> mainDatabaseData = Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB();
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.getAllFromOwnDatabaseQuery);
            Data.compareDatabasesAndUpdateIfNeeded(mainDatabaseData, OwnDatabaseData);
        }

        public static void updateDatabase(Object source, EventArgs e) // timed event
        {
            log.Info("");
            log.Info("Timestampt: " + DateTime.Now);
            log.Info("COMPARING DATABASES");
            log.Info("Running...");
            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();

            MySqlConnection connectionToMainDB = Connections.MainDB(); // connection to main database
            List<router> mainDatabaseData = Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB(); // connection to Cisco Tool database
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.getAllFromOwnDatabaseQuery); // returns list of items from OwnServer
            Data.compareDatabasesAndUpdateIfNeeded(mainDatabaseData, OwnDatabaseData); // this will check for changes, if database are not the same it will try to fix itself
        }

        public static void updateSerials()// first run
        {
            log.Info("");
            log.Info("Timestampt: " + DateTime.Now);
            log.Info("GETTING SERIALNUMBERS");
            log.Info("Running...");
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            string username = Settings.Default.username; 
            string password = Settings.Default.password;
            General.getSerialnumbersForRouters(username, password);
        }

        public static void updateSerials(Object source, EventArgs e) // timed event
        {
            log.Info("");
            log.Info("Timestampt: " + DateTime.Now);
            log.Info("GETTING SERIALNUMBERS");
            log.Info("Running...");
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            string username = Settings.Default.username;
            string password = Settings.Default.password;
            General.getSerialnumbersForRouters(username, password);
        }
    }
}
