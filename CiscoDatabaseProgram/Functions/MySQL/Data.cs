using CiscoDatabaseProgram.Functions.Logging;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Data
    {
        private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static List<router> getDataFromMySQL(MySqlConnection connection, string query)
        {
            try // tries to connect to database
            {
                connection.Open(); // opening connection
            }

            catch (MySqlException ex ) // cannot connect to server/database
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met database");
                        log.Error("Could not connect to Main Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        log.Error("Could not connect to Main Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        Console.WriteLine("geen MySQL server gevonden op dit ip");
                        log.Error("could not find MySQL server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("kan niet verbinden met database");
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        log.Error("Could not connect to Main Database - Error code: " + ex.Number);
                        break;
                    //  function will stop on this point
                }
                Exit.exitByMySQL(ex.Message);
                return null;
            }

            MySqlCommand command = connection.CreateCommand(); // makes a MySQL command
            command.CommandText = query; // connects the query string to the MySQLcommand

            List<Values.router> routers = new List<router> { }; // makes a list for all the routers in the database

            MySqlDataReader reader; // initialize the reader
            reader = command.ExecuteReader(); // starts the reader
            while (reader.Read())
            {
                router Router = new router(); // initialize new router element ** Used for storing every row **
                try
                {
                    //checks if there is a null value in the cell ** IsDBNull will be set to true if the cell is null **
                    bool one = reader.IsDBNull(1);
                    bool two = reader.IsDBNull(2);
                    bool three = reader.IsDBNull(3);
                    bool four = reader.IsDBNull(4);

                    //values from database are assign to Router router
                    Router.routerId = reader.GetInt32(0); //ID 
                    if (one == false) { Router.routerName = reader.GetString(1); } // name
                    if (two == false) { Router.routerAlias = reader.GetString(2); } // alias
                    if (three == false) { Router.routerAddress = reader.GetString(3); } // IP address
                    if (four == false) { Router.routerActivate = reader.GetString(4); } // active
                                                                                        // serialnumber wil be null and is only available in OwnDB
                    Router.routerMainDB = reader.GetInt32(0); // mainDatabase ID
                    routers.Add(Router);         // Router is added to the Routers list
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Probleem bij het lezen van één waarde uit de Main Database - Error Message: " + ex.Message);
                    Console.WriteLine("Locatie probleem: " + ex.Source);
                    log.Error("Error while reading one value from Main Database - Error Message : " + ex.Message);
                    log.Error("Error Location: " + ex.Source);
                    throw ex;
                }
            }
            connection.Close(); // closed connection to database
            return routers; // returns the freshly made Routers list
        } // for MySQL servers
        public static List<router> getDataFromMicrosoftSQL(SqlConnection connection, string query) // For Microsoft SQL servers

        {
             // initialize list for logging
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                Console.WriteLine("Verbonden met Cisco Tool database");
                log.Info("Connected to Cisco Tool Database");
            }

            catch (SqlException ex) // cannot connect to server/database
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met database");
                        log.Error("Could not connect to Cisco Tool Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        log.Error("Could not connect to Cisco Tool Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        Console.WriteLine("geen sql server gevonden op dit ip");
                        log.Error("could not find sql server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("kan niet verbinden met database");
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        log.Error("Could not connect to Cisco Tool Database - Error code: " + ex.Number);
                        break;
                        //  function will stop on this point
                }
                Exit.exitBySQL(ex.Message);
                return null;
            }

            SqlCommand command = connection.CreateCommand(); // makes a SQL command
            command.CommandText = query; // query string

            List<Values.router> routers = new List<router> { }; // makes a list for all the routers in the database

            SqlDataReader reader; // initialize the reader
            reader = command.ExecuteReader(); // starts the reader
            while (reader.Read())
            {
                router Router = new router(); // initialize new router element ** Used for storing every row **
                try
                {
                    //checks if there is a null value in the cell ** IsDBNull will be set to true if the cell is null **
                    bool one = reader.IsDBNull(1);
                    bool two = reader.IsDBNull(2);
                    bool three = reader.IsDBNull(3);
                    Type threeString = reader.GetFieldType(3);
                    if (threeString != typeof(string)) { three = true; }
                    bool four = reader.IsDBNull(4);
                    bool five = reader.IsDBNull(5);

                    //values from database are assign to Router router
                    Router.routerId = reader.GetInt32(0); // ID
                    if (one == false) { Router.routerName = reader.GetString(1); } // Name
                    if (two == false) { Router.routerAlias = reader.GetString(2); } // alias
                    if (three == false) { Router.routerAddress = reader.GetString(3); } // ip address
                    if (four == false) { Router.routerActivate = reader.GetString(4); } // active
                    if (five == false) { Router.routerSerialnumber = reader.GetString(5); }// Serialnumber 
                    Router.routerMainDB = reader.GetInt32(6); // mainDatabase ID
                    routers.Add(Router);         // Router is added to the Routers list
                }
                catch (Exception ex) // will execute when there is a problem with a value from the database
                {
                    Console.WriteLine("Probleem bij het lezen van één waarde uit de Cisco Tool Database - Error Message: " + ex.Message);
                    Console.WriteLine("Locatie probleem: " + ex.Source);
                    log.Error("Error while reading one value from Cisco Tool Database - Error Message : " + ex.Message);
                    log.Error("Error Location: " + ex.Source);
                    Logging.Exit.defaultExit();
                    throw ex;
                }

            }
            connection.Close(); // closed connection to database
            Console.WriteLine("Verbinding met Cisco Tool database correct afgesloten");
            log.Info("Connection to Cisco Tool Database correctly closed");
            return routers; // returns the freshly made Routers list
        }

        public static bool writeNewToOwnServer(List<router> routerList)
        {
            
            SqlConnection connection = Connections.OwnDB();
            try
            {
                connection.Open(); // opening connection
                Debug.WriteLine("connected to server");
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met database");
                        log.Error("Could not connect to Cisco Tool Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        log.Error("Could not connect to Cisco Tool Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        Console.WriteLine("geen sql server gevonden op dit ip");
                        log.Error("could not find sql server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("kan niet verbinden met database");
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        log.Error("Could not connect to Cisco Tool Database - Error code: " + ex.Number);
                        break;
                }
                Exit.exitBySQL(ex.Message);
                throw;
            }

            SqlCommand command = connection.CreateCommand(); // makes a SQL command
            foreach (var item in routerList)
            {
                string insertCommand =
                    "INSERT INTO dbo.router " +
                    "(router_mainID, router_name, router_friendlyname, router_active, router_serialnumber, router_ipaddress" + " )" +
                    "VALUES (" + "\'" + item.routerMainDB + "\' , \'" + item.routerName + "\',\'" + item.routerAlias + "\',\'" + item.routerActivate + "\',\'" + item.routerSerialnumber + "\',\'" + item.routerAddress + "\');";
                command.CommandText = insertCommand;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    switch (ex.Message)
                    {
                        default:
                            Console.WriteLine("Er was een probleem bij het wegschrijven van de nieuwe data");
                            Console.WriteLine("ID van nieuwe item" + item.routerMainDB);
                            Console.WriteLine("Error melding: " + ex.Message);
                            log.Error("ERROR - error while writing new data to the Cisco Tool Database");
                            log.Error("ID van item: " + item.routerMainDB);
                            log.Error("error message: " + ex.Message);
                            break;
                    }
                }
            }
            connection.Close();
            return true;
        }
        public static bool updateItemOwnServer(List<router> routerList) // update new routerlist to Owndatabase
        {
            
            SqlConnection connection = Connections.OwnDB(); // open connection with database
            try
            {
                connection.Open(); // opening connection
                Debug.WriteLine("connected to server");
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met database");
                        log.Error("Could not connect to Cisco Tool Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        log.Error("Could not connect to Cisco Tool Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        Console.WriteLine("geen sql server gevonden op dit ip");
                        log.Error("could not find sql server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("kan niet verbinden met database");
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        log.Error("Could not connect to Cisco Tool Database - Error code: " + ex.Number);
                        break;
                }
                Exit.exitBySQL(ex.Message);
                throw;
            }

            SqlCommand command = connection.CreateCommand(); // makes a SQL command
            foreach (var item in routerList)
            {
                int mainID = item.routerId;
                string query = "UPDATE dbo.router " +
                    "SET router_name = '{0}', router_friendlyname = '{1}', router_ipaddress = '{2}', router_serialnumber = '{3}', router_active = '{4}' , router_mainID = '{5}'" +
                    "WHERE router_mainID = '{6}'";
                query = string.Format(query, item.routerName, item.routerAlias, item.routerAddress, item.routerSerialnumber, item.routerActivate, item.routerMainDB, item.routerMainDB);
                command.CommandText = query;
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    switch (ex.Message)
                    {
                        default:
                            Console.WriteLine("Er was een probleem bij het updaten van data");
                            Console.WriteLine("ID van oud item" + item.routerMainDB);
                            Console.WriteLine("Error melding: " + ex.Message);
                            log.Error("ERROR - error while updating new data to the Cisco Tool Database");
                            log.Error("ID van item: " + item.routerMainDB);
                            log.Error("error message: " + ex.Message);
                            break;
                    }
                }
            }
            connection.Close();
            return true; // returns true 
        }
        public static void getNewByCompare(List<router> mainDBList, List<router> ownDBList)
        {
            // function will make a mainID list, a OwnID list with there id's from the database
            // the newID's list will fill up because it will take MainID Minus (-) the id's from OwnID
            // foreach new ID there will be a query to get the router from the jhhhhhhhjhjhjhj database
            // all the routers will be stored in a "router list"
            // the routerlist with all the new routers will be send to the "Own server" 
             // for log file
            List<int> mainIDList = new List<int>(); // initialize list for all id's in MainDatabase
            List<int> OwnIDList = new List<int>(); // initialize list for all id's in OwnDatabase
            List<int> newIDs = new List<int>();
            string result;
            log.Info("Getting new items from main database"); // for logbook

            #region foreachloops
            foreach (var router in mainDBList) //  gets a list of all id's in MainDB
            {
                mainIDList.Add(router.routerMainDB);
            }
            foreach (var router in ownDBList) // gets list of all id's in OwnDB
            {
                OwnIDList.Add(router.routerMainDB); 
            }
            mainIDList = mainIDList.OrderBy(p => p).ToList(); // order by ID for comparison
            OwnIDList = OwnIDList.OrderBy(p => p).ToList(); // order by ID
            int count = 0;
            foreach (var ID in mainIDList) // checks for each ID if they are in Ownlist
            {
                if (!OwnIDList.Contains(ID)) // checks if the ID is in OwnDB
                {
                    newIDs.Add(ID); // is a new ID that is not in OwnDB
                }
            }


            #endregion

            // mainIDList // MainIDList now contains all the id's that are new to OwnDatabase

            if (newIDs.Count != 0)
            {
                log.Info("Count new items: " + newIDs.Count()); // logs how many new items has been found
                List<router> newRouters = new List<router>();
                foreach (int ID in newIDs) //getting the new routers will take a few seconds
                {
                    string query = PrivateValues.get1Query + ID; // makes query string with ID - Only 1 result back
                    var data = getDataFromMySQL(General.MySQLConnnection(), query); // gets router data from main database
                    data[0].routerId = 0; // ID is emptied for the new database
                    newRouters.Add(data[0]); // index 0, function will not return more than one result
                }
                var pushNewRoutersToOwnServer = writeNewToOwnServer(newRouters); // insert new routers to OwnDatabase
                result = newIDs.Count + " nieuwe routers toegevoegd aan eigen database!";
                log.Info("Correcly added New items to Cisco Tool Database"); // count already in logbook
            }
            else
            {
                result = "Geen nieuwe routers gevonden";
                log.Error("No new items found in Main Database while trying to get new items");
            }
            Console.WriteLine();
            Console.WriteLine(result);
        } // run this function before the compare function

        public static void compareAndSendNewList (List<router> mainDBList, List<router> ownDBList) // logging is complete
        {
             // list for logFile
            if (mainDBList.Count == ownDBList.Count) // checks if the list are containing the correct amount of items
            {
                Console.WriteLine("Databases vergelijken...");
                log.Info("Comparing Databases...");
                mainDBList = mainDBList.OrderBy(id => id.routerMainDB).ToList(); //order list for comparison 
                ownDBList = ownDBList.OrderBy(id => id.routerMainDB).ToList(); // order list for comparison
                List<router> newOwnDBList = new List<router>(); // new list for new items
                int countChanges = 0; // will count the final changes
                for (int count = 0; count < mainDBList.Count; count++) // algorithm for choosing the new information
                {
                    router newRouter = new router(); // foreach router in the routerlist there will be a new router
                    newRouter.routerId = ownDBList[count].routerId; // by default the program will use the ownDB ID's because thats the target Database
                    newRouter.routerName = mainDBList[count].routerName;
                    if (mainDBList[count].routerName != ownDBList[count].routerName) // if statements are only for information to the user
                    {
                        string newName = "Naam - ID: " + mainDBList[count].routerMainDB + " naam was: " + ownDBList[count].routerName + " is nu: " + mainDBList[count].routerName; // Combines all the info
                        Console.WriteLine(newName); // echo's the difference to the user
                        log.Info(newName); // adds it to the logList
                        countChanges++; // counts the changes
                    }
                    newRouter.routerAlias = mainDBList[count].routerAlias; // Alias could change in the mainDB
                    if (mainDBList[count].routerAlias != ownDBList[count].routerAlias) // if statements are only for information
                    {
                        string newAlias = "Alias - ID: " + mainDBList[count].routerMainDB + " alias was: " + ownDBList[count].routerAlias + " is nu: " + mainDBList[count].routerAlias; // information string
                        Console.WriteLine(newAlias); // echo's the difference to the user
                        log.Info(newAlias);// adds it to the logList
                        countChanges++; // counts the changes
                    }
                    newRouter.routerAddress = mainDBList[count].routerAddress; // address could change in the MainDB
                    if (mainDBList[count].routerAddress != ownDBList[count].routerAddress) // if statements are only for information
                    {
                        string newAddress = "IP adres - ID: " + mainDBList[count].routerMainDB + " IP adres was: " + ownDBList[count].routerAddress + " is nu: " + mainDBList[count].routerAddress; // information string
                        Console.WriteLine(newAddress); // echo's the difference to the user
                        log.Info(newAddress); // adds it to the logList
                        countChanges++; // counts the changes
                    }
                    newRouter.routerActivate = mainDBList[count].routerActivate; // for new information
                    if (mainDBList[count].routerActivate != ownDBList[count].routerActivate) // if statements are only for information
                    {
                        string newActive = "Active - ID: " + mainDBList[count].routerMainDB + " active status was: " + ownDBList[count].routerActivate + " is nu: " + mainDBList[count].routerActivate; // information string
                        Console.WriteLine(newActive); // echo's the difference to the user
                        log.Info(newActive); // adds it to the logList
                        countChanges++; // counts the changes
                    }
                    newRouter.routerSerialnumber = ownDBList[count].routerSerialnumber; // serialnumber is only known in the OwnDB and is not available in the main DB
                    newRouter.routerMainDB = ownDBList[count].routerMainDB; // mainDB and ownDB could be entered here
                    if (mainDBList[count].routerMainDB != ownDBList[count].routerMainDB) // if statements are only for information
                    {
                        string newMainDB = "ID - ID: " + mainDBList[count].routerMainDB + " Main database ID was: " + ownDBList[count].routerMainDB + " is nu: " + mainDBList[count].routerMainDB; // information string
                        Console.WriteLine(newMainDB); // echo's the difference to the user
                        log.Info(newMainDB); // adds it to the logList
                        countChanges++; // counts the changes
                    }
                    newOwnDBList.Add(newRouter); // add all items to the list
                }
                if (countChanges == 0) // if there are no changed there will be no push to the Cisco tool database
                {
                    Console.WriteLine();
                    Console.WriteLine("Geen veranderingen tussen databases");
                    log.Info("No difference between databases");
                }
                else
                {
                    try // tries to update the new data to the Cisco tool database
                    {
                        log.Info("Trying to update new Data...");
                        var updateItems = updateItemOwnServer(newOwnDBList);
                        if (updateItems == true)
                        {
                            log.Info("Data succesfully updated");
                            log.Info("Total values changed: " + countChanges);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Database is bijgewerkt");
                        Console.WriteLine("Aantal veranderingen: " + countChanges);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error bij het updaten van de nieuwe gegevens");
                        Console.WriteLine("Error message: " + ex.Message);
                        log.Error("Error - error while updating new data");
                        log.Error("Error code: " + ex.Message);
                        log.Error("location error: " + ex.Source);
                        throw;
                    }
                }
            }
            else if (mainDBList.Count > ownDBList.Count) // if there are new items in the Main database
            {
                Console.WriteLine();
                Console.WriteLine("Databases zijn niet gelijk in aantal, Update functie wordt nu uitgevoerd...");
                log.Error("Databases are not equal, update function will be executed");
                log.Info("Starting update Function...");
                getNewByCompare(mainDBList, ownDBList); // gets new entries from the mainDB
                ownDBList = getDataFromMicrosoftSQL(Connections.OwnDB(), PrivateValues.OwnServerServerQuery); // gets the checked and updated own Database
                compareAndSendNewList(mainDBList, ownDBList);
            }
            else // will never be triggerd, otherwise there is a problem with the code
            {
                Console.WriteLine("GEEN DATA VERWIJDEREN UIT OFFICELE DATABASE");
                Console.WriteLine(" !!! NIET DE OFFICLE DATABASE !!! Database heeft teveel items, verwijder de data uit table ' dbo.router' !!! NIET DE OFFICLE DATABASE !!! de applicatie zal de database weer opnieuw opbouwen bij de volgende start");
                Console.WriteLine("NIET DE DATA UIT DE OFFICELE DATABASE VERWIJDEREN");
                Console.WriteLine("Graag dit probleeem doorgeven aan de ontwikkelaar: " + "compare_and_send_newlist | TOO MANY ITEMS ");
                log.Error(@"OwnDatabase is too big - Please remove all data from table 'dbo.router' NOT THE OFFICIAL DATABASE!! ");
                log.Error("!!! NOT THE OFFICIAL DATABASE !!!");
            }
        }
    } //gets changed data from main server and push it to Owndata
}
