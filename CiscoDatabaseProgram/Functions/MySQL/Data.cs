using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data.SqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Data
    {
        public static List<router> getDataFromMySQL(MySqlConnection connection, string query)
        { 
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                Debug.WriteLine("connected to server"); 
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
                Router.routerMainDB = reader.GetInt32(6); // mainDatabase ID


                routers.Add(Router);         // Router is added to the Routers list
                Console.WriteLine(Router.routerAddress);
            }
            connection.Close(); // closed connection to database
            return routers; // returns the freshly made Routers list
        } // for MySQL servers
        public static List<router> getDataFromMicrosoftSQL(SqlConnection connection, string query) // For Microsoft SQL servers
        {
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                Debug.WriteLine("connected to server");
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
                Console.WriteLine(Router.routerAddress);
            }
            connection.Close(); // closed connection to database
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
                    "VALUES (" + "\'" + item.routerId + "\' , \'" + item.routerName + "\',\'" + item.routerAlias + "\',\'" + item.routerActivate + "\',\'" + item.routerSerialnumber + "\',\'" + item.routerAddress + "\');";
                command.CommandText = insertCommand;
                command.ExecuteNonQuery();
            }
            connection.Close();
            return true;
        }
        public static bool updateItemOwnServer(List<router> routerList)
        {
            SqlConnection connection = Connections.OwnDB();
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
                    "WHERE ID = '{6}'";
                query = string.Format(query, item.routerName, item.routerAlias, item.routerAddress, item.routerSerialnumber, item.routerActivate, item.routerId, item.routerId);
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            connection.Close();
            return true; // returns true 
        }

        public static void getNewByCompare(List<router> mainDBList, List<router> ownDBList)
        {
            var newItems = ownDBList.Except(mainDBList).ToList();
            Console.WriteLine();
        }
    }
}
