using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Values;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class Data
    {
        public static List<router> getDataFromMainDatabase()
        { 
            MySqlConnection connection = MySQL.General.MakeMySQLConnnection( // Make connection with Database
                PrivateValues.NIETAANZITTENserver, // ip
                PrivateValues.NIETAANZITTENserverDB, // database
                PrivateValues.NIETAANZITTENserverUsername, // username
                PrivateValues.NIETAANZITTENserverPassword);  // password

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
            }

            string query = PrivateValues.NIETAANZITTENserverQuery; // for local use
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
                Router.routerId = reader.GetInt32(0);
                if (one == false) { Router.routerName = reader.GetString(1); }
                if (two == false) { Router.routerAlias = reader.GetString(2); }
                if (three == false) { Router.routerAddress = reader.GetString(3); }
                if (four == false) { Router.routerActivate = reader.GetString(4); }

                routers.Add(Router);         // Router is added to the Routers list
                Console.WriteLine(Router.routerAddress);
            }
            connection.Close(); // closed connection to database
            return routers; // returns the freshly made Routers list
        }
    }
}
