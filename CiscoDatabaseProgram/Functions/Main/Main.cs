﻿using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Deze applicatie er ter ondersteuing van de Cisco Tool");
            Console.WriteLine();


            MySqlConnection connectionToMainDB = Connections.MainDB(); // connection to main database
            List<router> mainDatabaseData = Functions.MySQL.Data.getDataFromMySQL(connectionToMainDB, PrivateValues.NIETAANZITTENserverQuery); // returns null if failed to connect
            SqlConnection connectionToOwnDB = Connections.OwnDB(); // connection to Cisco Tool database
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery); // returns list of items from OwnServer
            Data.compareAndSendNewList(mainDatabaseData, OwnDatabaseData); // this will check for changes, if database are not the same it will try to fix itself




            Console.ReadLine();





        }
    }
}