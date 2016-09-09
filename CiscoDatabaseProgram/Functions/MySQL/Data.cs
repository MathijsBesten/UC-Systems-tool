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
        public static List<router> getDataFromMySQL(MySqlConnection connection, string query)
        { 
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                Console.WriteLine("Verbonden met hoofdserver"); 
            }

            catch (MySqlException ex ) // cannot connect to server/database
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met server");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        break;
                    //  function will stop on this point
                }
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
            connection.Close(); // closed connection to database
            Console.WriteLine("Verbingen correct afgesloten");
            return routers; // returns the freshly made Routers list
        } // for MySQL servers
        public static List<router> getDataFromMicrosoftSQL(SqlConnection connection, string query) // For Microsoft SQL servers
        {
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                Console.WriteLine("Verbonden met Cisco Tool database");
            }

            catch (MySqlException ex) // cannot connect to server/database
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met server");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + ex.Number);
                        break;
                        //  function will stop on this point
                }
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

                //checks if there is a null value in the cell ** IsDBNull will be set to true if the cell is null **
                bool one = reader.IsDBNull(1);
                bool two = reader.IsDBNull(2);
                bool three = reader.IsDBNull(3);
                Type threeString = reader.GetFieldType(3);
                if (threeString != typeof(string)) { three = true; }
                bool four = reader.IsDBNull(4);

                //values from database are assign to Router router
                Router.routerId = reader.GetInt32(0); // ID
                if (one == false) { Router.routerName = reader.GetString(1); } // Name
                if (two == false) { Router.routerAlias = reader.GetString(2); } // alias
                if (three == false) { Router.routerAddress = reader.GetString(3); } // ip address
                if (four == false) { Router.routerActivate = reader.GetString(4); } // active
                // Serialnumber is only used in OwnDB, no need for storing it in this list
                Router.routerMainDB = reader.GetInt32(6); // mainDatabase ID
                routers.Add(Router);         // Router is added to the Routers list
            }
            connection.Close(); // closed connection to database
            Console.WriteLine("Verbinding correct afgesloten");
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
            catch (MySqlException error)
            {
                switch (error.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met server");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + error.Number);
                        break;
                        //  function will stop on this point
                }
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
                command.ExecuteNonQuery();
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
            catch (SqlException error)
            {
                switch (error.Number)
                {
                    case 0: // unable to connect to server
                        Console.WriteLine("kan niet verbinden met server");
                        break;
                    case 1045: // username or password is wrong
                        Console.WriteLine("Gebruikersnaam en/of wachtwoord zijn fout, probeer het opnieuw");
                        break;
                    default: // this will step into action if its not one of the above
                        Console.WriteLine("Geen foutafhandeling, deze code graag doorgeven aan de ontwikkelaar: " + error.Number);
                        break;
                        //  function will stop on this point
                }
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
                command.ExecuteNonQuery();
            }
            connection.Close();
            return true; // returns true 
        }

        public static void getNewByCompare(List<router> mainDBList, List<router> ownDBList)
        {
            // function will make a mainID list, a OwnID list with there id's from the database
            // the newID's list will fill up because it will take MainID Minus (-) the id's from OwnID
            // foreach new ID there will be a query to get the router from the main database
            // all the routers will be stored in a "router list"
            // the routerlist with all the new routers will be send to the "Own server" 

            List<int> mainIDList = new List<int>(); // initialize list for all id's in MainDatabase
            List<int> OwnIDList = new List<int>(); // initialize list for all id's in OwnDatabase
            var newIDs = new List<int>();

            string result;

            #region foreachloops
            foreach (var router in mainDBList) //  gets a list of all id's in MainDB
            {
                mainIDList.Add(router.routerMainDB);
            }
            foreach (var router in ownDBList) // gets list of all id's in OwnDB
            {
                OwnIDList.Add(router.routerMainDB); 
            }
            mainIDList = mainIDList.OrderBy(p => p).ToList();
            OwnIDList = OwnIDList.OrderBy(p => p).ToList();
            int count = 0;
            foreach (var ID in mainIDList)
            {
                if (!OwnIDList.Contains(ID))
                {
                    newIDs.Add(ID);
                }
            }


            #endregion

            // mainIDList // MainIDList now contains all the id's that are new to OwnDatabase

            if (newIDs.Count != 0)
            {
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
            }
            else
            {
                result = "Geen nieuwe routers gevonden";
            }
            Console.WriteLine();
            Console.WriteLine(result);
        } // run this function before the compare function

        public static void compareAndSendNewList (List<router> mainDBList, List<router> ownDBList)
        {
            if (mainDBList.Count == ownDBList.Count) // checks if the list are containing the correct amount of items
            {
                Console.WriteLine("Databases vergelijken...");
                mainDBList = mainDBList.OrderBy(id => id.routerMainDB).ToList();
                ownDBList = ownDBList.OrderBy(id => id.routerMainDB).ToList();
                List<router> newOwnDBList = new List<router>();
                int countChanges = 0;
                for (int count = 0; count < mainDBList.Count; count++)
                {
                    router newRouter = new router();
                    newRouter.routerId = ownDBList[count].routerId;
                    newRouter.routerName = mainDBList[count].routerName;
                    if (mainDBList[count].routerName != ownDBList[count].routerName)
                    {
                        Console.WriteLine("Naam - ID: " + mainDBList[count].routerMainDB + " naam was: " + ownDBList[count].routerName + " is nu: " + mainDBList[count].routerName);
                        countChanges++;
                    }
                    newRouter.routerAlias = mainDBList[count].routerAlias;
                    if (mainDBList[count].routerAlias != ownDBList[count].routerAlias)
                    {
                        Console.WriteLine("Alias - ID: " + mainDBList[count].routerMainDB + " alias was: " + ownDBList[count].routerAlias + " is nu: " + mainDBList[count].routerAlias);
                        countChanges++;
                    }
                    newRouter.routerAddress = mainDBList[count].routerAddress;
                    if (mainDBList[count].routerAddress != ownDBList[count].routerAddress)
                    {
                        Console.WriteLine("IP adres - ID: " + mainDBList[count].routerMainDB + " IP adres was: " + ownDBList[count].routerAddress + " is nu: " + mainDBList[count].routerAddress);
                        countChanges++;
                    }
                    newRouter.routerActivate = mainDBList[count].routerActivate;
                    if (mainDBList[count].routerActivate != ownDBList[count].routerActivate)
                    {
                        Console.WriteLine("Active - ID: " + mainDBList[count].routerMainDB + " active status was: " + ownDBList[count].routerActivate + " is nu: " + mainDBList[count].routerActivate);
                        countChanges++;
                    }
                    newRouter.routerSerialnumber = ownDBList[count].routerSerialnumber;
                    newRouter.routerMainDB = ownDBList[count].routerMainDB;
                    if (mainDBList[count].routerMainDB != ownDBList[count].routerMainDB)
                    {
                        Console.WriteLine("ID - ID: " + mainDBList[count].routerMainDB + " Main database ID was: " + ownDBList[count].routerMainDB + " is nu: " + mainDBList[count].routerMainDB);
                        countChanges++;
                    }
                    newOwnDBList.Add(newRouter);
                }
                var updateItems = updateItemOwnServer(newOwnDBList);
                if (countChanges == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Geen veranderingen tussen databases");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Database is bijgewerkt");
                    Console.WriteLine("Aantal veranderingen: " + countChanges);
                }
            }
            else if (mainDBList.Count > ownDBList.Count) // if there are new items in the Main database
            {
                Console.WriteLine();
                Console.WriteLine("Databases zijn niet gelijk in aantal, Update functie wordt nu uitgevoerd...");
                getNewByCompare(mainDBList, ownDBList);
                ownDBList = getDataFromMicrosoftSQL(Connections.OwnDB(), PrivateValues.OwnServerServerQuery);
                compareAndSendNewList(mainDBList, ownDBList);
            }
            else // will never be triggerd, otherwise there is a problem with the code
            {
                Console.WriteLine("Database heeft teveel items, verwijder de data uit table \' dbo.router\' de applicatie zal de database weer opnieuw opbouwen bij de volgende start");
                Console.WriteLine("Graag dit probleeem doorgeven aan de ontwikkelaar: " + "compare_and_send_newlist | TOO MANY ITEMS ");
            } 
        }
    } //gets changed data from main server and push it to Owndata
}
