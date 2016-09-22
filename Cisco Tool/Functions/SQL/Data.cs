using Cisco_Tool.Values;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using static Cisco_Tool.Values.PrivateValues;

namespace Cisco_Tool.Functions.SQL
{
    class Data
    {
        private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        public static List<router> getDataFromMicrosoftSQL(SqlConnection connection, string query) // For Microsoft SQL servers

        {
             // initialize list for logging
            try // tries to connect to database
            {
                connection.Open(); // opening connection
                log.Info("Connected to Cisco Tool Database");
            }

            catch (SqlException ex) // cannot connect to server/database
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        log.Error("Could not connect to Cisco Tool Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        log.Error("Could not connect to Cisco Tool Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        log.Error("could not find sql server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        log.Error("Could not connect to Cisco Tool Database - Error code: " + ex.Number);
                        break;
                        //  function will stop on this point
                }
                return null;
            }

            SqlCommand command = connection.CreateCommand(); // makes a SQL command
            command.CommandText = query; // query string

            List<router> routers = new List<router> { }; // makes a list for all the routers in the database

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

                    log.Error("Error while reading one value from Cisco Tool Database - Error Message : " + ex.Message);
                    log.Error("Error Location: " + ex.Source);
                    throw ex;
                }

            }
            connection.Close(); // closed connection to database
            log.Info("Connection to Cisco Tool Database correctly closed");
            return routers; // returns the freshly made Routers list
        }
    } 
}
