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
            try
            {
                connection.Open();
            }

            catch (MySqlException ex )
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
                }
                Exit.exitByMySQL(ex.Message);
                return null;
            }

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            List<Values.router> routers = new List<router> { }; 
            MySqlDataReader reader;
            reader = command.ExecuteReader(); // starts the reader
            while (reader.Read())
            {
                router Router = new router();
                try
                {
                    //checks if there is a null value in the cell
                    bool one = reader.IsDBNull(1);
                    bool two = reader.IsDBNull(2);
                    bool three = reader.IsDBNull(3);
                    bool four = reader.IsDBNull(4);

                    Router.routerId = reader.GetInt32(0);                               //ID 
                    if (one == false) { Router.routerName = reader.GetString(1); }      // name
                    if (two == false) { Router.routerAlias = reader.GetString(2); }     // alias
                    if (three == false) { Router.routerAddress = reader.GetString(3); } // IP address
                    if (four == false) { Router.routerActivate = reader.GetString(4); } // active
                                                                                        // serialnumber
                    Router.routerMainDB = reader.GetInt32(0);                           // mainDatabase ID
                    routers.Add(Router);         
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Probleem bij het lezen van één waarde uit de Main Database - Error Message: " + ex.Message);
                    Console.WriteLine("Locatie probleem: " + ex.Source);
                    log.Error("Error while reading one value from Main Database - Error Message : " + ex.Message);
                    log.Error("Error Location: " + ex.Source);
                }
            }
            connection.Close(); 
            return routers;
        }
        public static List<router> getDataFromMicrosoftSQL(SqlConnection connection, string query) 
        {
            try 
            {
                connection.Open();
                Console.WriteLine("Verbonden met Cisco Tool database");
                log.Info("Connected to Cisco Tool Database");
            }

            catch (SqlException ex)
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
                return null;
            }

            SqlCommand command = connection.CreateCommand(); 
            command.CommandText = query;
            List<Values.router> routers = new List<router> { };
            SqlDataReader reader; 
            reader = command.ExecuteReader(); // starts the reader
            while (reader.Read())
            {
                router Router = new router(); 
                try
                {
                    //checks if there is a null value in the cell
                    bool one = reader.IsDBNull(1);
                    bool two = reader.IsDBNull(2);
                    bool three = reader.IsDBNull(3);
                    Type threeString = reader.GetFieldType(3);
                    if (threeString != typeof(string)) { three = true; }
                    bool four = reader.IsDBNull(4);
                    bool five = reader.IsDBNull(5);

                    Router.routerId = reader.GetInt32(0);                                   // ID
                    if (one == false) { Router.routerName = reader.GetString(1); }          // Name
                    if (two == false) { Router.routerAlias = reader.GetString(2); }         // alias
                    if (three == false) { Router.routerAddress = reader.GetString(3); }     // ip address
                    if (four == false) { Router.routerActivate = reader.GetString(4); }     // active
                    if (five == false) { Router.routerSerialnumber = reader.GetString(5); } // Serialnumber 
                    Router.routerMainDB = reader.GetInt32(6);                               // mainDatabase ID
                    routers.Add(Router);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Probleem bij het lezen van één waarde uit de Cisco Tool Database - Error Message: " + ex.Message);
                    Console.WriteLine("Locatie probleem: " + ex.Source);
                    log.Error("Error while reading one value from Cisco Tool Database - Error Message : " + ex.Message);
                    log.Error("Error Location: " + ex.Source);
                    Logging.Exit.defaultExit();
                }

            }
            connection.Close();
            Console.WriteLine("Verbinding met Cisco Tool database correct afgesloten");
            log.Info("Connection to Cisco Tool Database correctly closed");
            return routers;
        }

        public static bool insertNewIntoOwnServer(List<router> routerList)
        {   
            SqlConnection connection = Connections.OwnDB();
            try
            {
                connection.Open();
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
            }

            SqlCommand command = connection.CreateCommand();
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
        public static bool updateRoutersOwnServer(List<router> routerList)
        {   
            SqlConnection connection = Connections.OwnDB();
            try
            {
                connection.Open();
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
            }

            SqlCommand command = connection.CreateCommand();
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
                    int rowsEffected = command.ExecuteNonQuery(); // run the command
                    if (rowsEffected == 0)
                    {
                        log.Info("there was no record found in Cisco Tool Database with ip: " + item.routerAddress);
                    }
                    else
                    {
                        log.Info("Serialnumber added in database for router " + item.routerAddress);
                    }
                    
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
        public static void getNewByCompare(List<router> mainDBList, List<router> ownDBList) // run this function before the compare function
        {
            List<int> mainIDsList = new List<int>();
            List<int> OwnIDsList = new List<int>();
            List<int> newIDs = new List<int>();
            string result;
            log.Info("Getting new items from main database");

            #region foreachloops
            foreach (var router in mainDBList)
            {
                mainIDsList.Add(router.routerMainDB);
            }
            foreach (var router in ownDBList) 
            {
                OwnIDsList.Add(router.routerMainDB); 
            }
            mainIDsList = mainIDsList.OrderBy(p => p).ToList(); // order by ID
            OwnIDsList = OwnIDsList.OrderBy(p => p).ToList();   // order by ID
            foreach (var ID in mainIDsList)
            {
                if (!OwnIDsList.Contains(ID))
                {
                    newIDs.Add(ID);
                }
            }


            #endregion
            if (newIDs.Count != 0)
            {
                log.Info("Count new items: " + newIDs.Count());
                List<router> newRouters = new List<router>();
                foreach (int ID in newIDs) 
                {
                    string query = PrivateValues.get1Query + ID;
                    var data = getDataFromMySQL(General.MySQLConnnection(), query); 
                    data[0].routerId = 0;
                    newRouters.Add(data[0]); //index is always 0
                }
                var pushNewRoutersToOwnServer = insertNewIntoOwnServer(newRouters); 
                result = newIDs.Count + " nieuwe routers toegevoegd aan eigen database!";
                log.Info("Correcly added New items to Cisco Tool Database");
            }
            else
            {
                result = "Geen nieuwe routers gevonden";
                log.Error("No new items found in Main Database while trying to get new items");
            }
            Console.WriteLine();
            Console.WriteLine(result);
        } 

        public static void compareDatabasesAndUpdateIfNeeded (List<router> mainDBList, List<router> ownDBList)  
        {
             // list for logFile
            if (mainDBList.Count == ownDBList.Count) 
            {
                Console.WriteLine("Databases vergelijken...");
                log.Info("Comparing Databases...");
                mainDBList = mainDBList.OrderBy(id => id.routerMainDB).ToList(); //order list for comparison 
                ownDBList = ownDBList.OrderBy(id => id.routerMainDB).ToList();   // order list for comparison
                List<router> newOwnDBList = new List<router>(); 
                int totalChanges = 0; 
                for (int count = 0; count < mainDBList.Count; count++) // algorithm for choosing the new information
                {
                    router newRouter = new router();
                    newRouter.routerId = ownDBList[count].routerId;                                 //mainDB is leading
                    newRouter.routerName = mainDBList[count].routerName;                            //mainDB is leading
                    if (mainDBList[count].routerName != ownDBList[count].routerName)
                    {
                        string newName = "Naam - ID: " + mainDBList[count].routerMainDB + " naam was: " + ownDBList[count].routerName + " is nu: " + mainDBList[count].routerName; 
                        Console.WriteLine(newName); 
                        log.Info(newName); 
                        totalChanges++; 
                    }
                    newRouter.routerAlias = mainDBList[count].routerAlias;                          // mainDB is leading
                    if (mainDBList[count].routerAlias != ownDBList[count].routerAlias) 
                    {
                        string newAlias = "Alias - ID: " + mainDBList[count].routerMainDB + " alias was: " + ownDBList[count].routerAlias + " is nu: " + mainDBList[count].routerAlias; 
                        Console.WriteLine(newAlias); 
                        log.Info(newAlias);
                        totalChanges++; 
                    }
                    newRouter.routerAddress = mainDBList[count].routerAddress;                      // mainDB is leading
                    if (mainDBList[count].routerAddress != ownDBList[count].routerAddress) 
                    {
                        string newAddress = "IP adres - ID: " + mainDBList[count].routerMainDB + " IP adres was: " + ownDBList[count].routerAddress + " is nu: " + mainDBList[count].routerAddress; 
                        Console.WriteLine(newAddress); 
                        log.Info(newAddress); 
                        totalChanges++; 
                    }
                    newRouter.routerActivate = mainDBList[count].routerActivate;                    // mainDB is leading
                    if (mainDBList[count].routerActivate != ownDBList[count].routerActivate) 
                    {
                        string newActive = "Active - ID: " + mainDBList[count].routerMainDB + " active status was: " + ownDBList[count].routerActivate + " is nu: " + mainDBList[count].routerActivate; 
                        Console.WriteLine(newActive); 
                        log.Info(newActive); 
                        totalChanges++;
                    }
                    newRouter.routerSerialnumber = ownDBList[count].routerSerialnumber;             // ownDB is leading
                    newRouter.routerMainDB = ownDBList[count].routerMainDB;                         // mainDB is leading
                    if (mainDBList[count].routerMainDB != ownDBList[count].routerMainDB) 
                    {
                        string newMainDB = "ID - ID: " + mainDBList[count].routerMainDB + " Main database ID was: " + ownDBList[count].routerMainDB + " is nu: " + mainDBList[count].routerMainDB; 
                        Console.WriteLine(newMainDB); 
                        log.Info(newMainDB); 
                        totalChanges++;
                    }
                    newOwnDBList.Add(newRouter); 
                }
                if (totalChanges == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Geen veranderingen tussen databases");
                    log.Info("No difference between databases");
                }
                else
                {
                    try
                    {
                        log.Info("Trying to update new Data...");
                        var updateItems = updateRoutersOwnServer(newOwnDBList);
                        if (updateItems == true)
                        {
                            log.Info("Data succesfully updated");
                            log.Info("Total values changed: " + totalChanges);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Database is bijgewerkt");
                        Console.WriteLine("Aantal veranderingen: " + totalChanges);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error bij het updaten van de nieuwe gegevens");
                        Console.WriteLine("Error message: " + ex.Message);
                        log.Error("Error - error while updating new data");
                        log.Error("Error code: " + ex.Message);
                        log.Error("location error: " + ex.Source);
                    }
                }
            }
            else if (mainDBList.Count > ownDBList.Count) //mainDB had more than ownDB
            {
                Console.WriteLine();
                Console.WriteLine("Databases zijn niet gelijk in aantal, Update functie wordt nu uitgevoerd...");
                log.Error("Databases are not equal, update function will be executed");
                log.Info("Starting update Function...");
                getNewByCompare(mainDBList, ownDBList); 
                ownDBList = getDataFromMicrosoftSQL(Connections.OwnDB(), PrivateValues.getAllFromOwnDatabaseQuery);
                compareDatabasesAndUpdateIfNeeded(mainDBList, ownDBList);
            }
            else //ownDB had more than mainDB
            {
                Console.WriteLine("GEEN DATA VERWIJDEREN UIT OFFICELE DATABASE");
                Console.WriteLine(" !!! NIET DE OFFICLE DATABASE !!! Database heeft teveel items, verwijder de data uit table ' dbo.router' !!! NIET DE OFFICLE DATABASE !!! de applicatie zal de database weer opnieuw opbouwen bij de volgende start");
                Console.WriteLine("NIET DE DATA UIT DE OFFICELE DATABASE VERWIJDEREN");
                Console.WriteLine("Graag dit probleeem doorgeven aan de ontwikkelaar: " + "compare_and_send_newlist | TOO MANY ITEMS ");
                log.Error(@"OwnDatabase is too big - Please remove all data from table 'dbo.router' NOT THE OFFICIAL DATABASE!! ");
                log.Error("!!! NOT THE OFFICIAL DATABASE !!!");
            }
        }
    } 
}
