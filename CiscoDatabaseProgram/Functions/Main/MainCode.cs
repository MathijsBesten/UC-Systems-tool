using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CiscoDatabaseProgram.Functions.Main
{
    class MainCode
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            List<router> mainDatabaseData = Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
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
            List<router> mainDatabaseData = Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
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
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            SerialNumbers.General.getSerialnumbersForRouters(username, password);
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
            string username = ConfigurationManager.AppSettings["username"];
            string password = ConfigurationManager.AppSettings["password"];
            SerialNumbers.General.getSerialnumbersForRouters(username, password);
        }

        public static void TESTUpdateSerials() // timed event
        {
            log.Info("");
            log.Info("Timestampt: " + DateTime.Now);
            log.Info("GETTING SERIALNUMBERS");
            log.Info("Running...");
            Console.WriteLine("");
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();
            string username = "mathijs";
            string password = "denbesten";
            List<router> testRouters = new List<router>();
            router testRouter = new router();

            SerialNumbers.General.TESTmanualListGetSerialnumbersForRouters(testRouters, username, password);
        }
    }
}
