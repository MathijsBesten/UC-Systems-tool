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
using System.Configuration;

namespace CiscoDatabaseProgram.Functions.Main
{
    class Main
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

            MainCode.updateDatabase();
            MainCode.updateSerials();
            Timers.DatabaseUpdateTimer(); // user can choose time using the config file
            Timers.SerialCodeTimer(); // user can choose time using the config file


            Console.ReadLine();
        }
    }
}
