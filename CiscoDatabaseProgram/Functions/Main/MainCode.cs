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

            MySqlConnection connectionToMainDB = Connections.MainDB(); // connection to main database
            List<router> mainDatabaseData = Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB(); // connection to Cisco Tool database
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery); // returns list of items from OwnServer
            Data.compareAndSendNewList(mainDatabaseData, OwnDatabaseData); // this will check for changes, if database are not the same it will try to fix itself
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
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery); // returns list of items from OwnServer
            Data.compareAndSendNewList(mainDatabaseData, OwnDatabaseData); // this will check for changes, if database are not the same it will try to fix itself
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

            //testing part start
            List<router> testList = new List<router>();
            router myTestRouter = new router();
            myTestRouter.routerAddress = ConfigurationManager.AppSettings["TestRouterIP"];
            string username = ConfigurationManager.AppSettings["TestRouterUsername"];
            string password = ConfigurationManager.AppSettings["TestRouterPassword"];
            //testing part end


            testList.Add(myTestRouter);

            SerialNumbers.General.getSerialForRouters(username, password); // main function to get serialnumbers           
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

            //testing part start
            List<router> testList = new List<router>();
            router myTestRouter = new router();
            myTestRouter.routerAddress = ConfigurationManager.AppSettings["TestRouterIP"];
            string username = ConfigurationManager.AppSettings["TestRouterUsername"];
            string password = ConfigurationManager.AppSettings["TestRouterPassword"];
            //testing part end


            testList.Add(myTestRouter);

            SerialNumbers.General.getSerialForRouters(username, password); // main function to get serialnumbers           
        }
    }
}
