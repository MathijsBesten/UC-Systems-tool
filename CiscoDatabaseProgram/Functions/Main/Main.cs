using CiscoDatabaseProgram.Functions.Main;
using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Functions.Logging;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace CiscoDatabaseProgram.Functions.Main
{
    class Main
    {
        public static void MainFunction()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       Database Checker       ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine("Welkom op op de console applicatie, ");
            Console.WriteLine("elke 20 minuten zal de database worden gecontroleerd");
            Console.WriteLine("Deze applicatie is ter ondersteuing van de Cisco Tool");
            Console.WriteLine();

            Timers.executeTimer(60); // int is for running every X seconds
            // use 60 for testing

            SerialNumbers.TelnetConnection.telnetClientTCP(PrivateValues.testRouter);
            Console.ReadLine();
        }
        public static void MainCode(Object source, EventArgs e)
        {
            List<string> log = new List<string>();
            log.Add("");
            log.Add("Timestampt: " + DateTime.Now);
            log.Add("Running...");
            Logs.writeToLogfile(log);
            log.Clear(); // clear log for further use in this class

            Console.WriteLine();
            Console.WriteLine(DateTime.Now);
            Console.WriteLine();

            MySqlConnection connectionToMainDB = Connections.MainDB(); // connection to main database
            List<router> mainDatabaseData = Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB(); // connection to Cisco Tool database
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery); // returns list of items from OwnServer
            Data.compareAndSendNewList(mainDatabaseData, OwnDatabaseData); // this will check for changes, if database are not the same it will try to fix itself
        }
    }
}
