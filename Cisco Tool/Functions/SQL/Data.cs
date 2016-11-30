using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Cisco_Tool.Values.PrivateValues;

namespace Cisco_Tool.Functions.SQL
{
    class Data
    {
        private static readonly log4net.ILog Log =
         log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<Router> GetDataFromMicrosoftSql(SqlConnection connection, string query) 
        {
            try
            {
                connection.Open();
                Log.Info("Connected to Cisco Tool Database");
            }

            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0: // unable to connect to server
                        Log.Error("Could not connect to Cisco Tool Database - Unable to connect");
                        break;
                    case 1045: // username or password is wrong
                        Log.Error("Could not connect to Cisco Tool Database - Wrong username or password");
                        break;
                    case 1326: // server was not found
                        Log.Error("could not find sql server on given ip");
                        break;
                    default: // this will step into action if its not one of the above
                        Log.Error("Could not connect to Cisco Tool Database - Error code: " + ex.Number);
                        break;
                }
                return null;
            }

            SqlCommand command = connection.CreateCommand();
            command.CommandText = query; // this is not from user input and is staticly set in the private class
            List<Router> routers = new List<Router>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Router router = new Router();
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
                    router.RouterId = reader.GetInt32(0);                                   // ID
                    if (one == false) { router.RouterName = reader.GetString(1); }          // Name
                    if (two == false) { router.RouterAlias = reader.GetString(2); }         // alias
                    if (three == false) { router.RouterAddress = reader.GetString(3); }     // ip address
                    if (four == false) { router.RouterActivate = reader.GetString(4); }     // active
                    if (five == false) { router.RouterSerialnumber = reader.GetString(5); } // Serialnumber 
                    router.RouterMainDb = reader.GetInt32(6);                               // mainDatabase ID
                    routers.Add(router);
                }
                catch (Exception ex)
                {
                    Log.Error("Error while reading one value from Cisco Tool Database - Error Message : " + ex.Message);
                    Log.Error("Error Location: " + ex.Source);
                }
            }
            connection.Close();
            Log.Info("Connection to Cisco Tool Database correctly closed");
            return routers;
        }
    } 
}
