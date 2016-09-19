using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.SerialNumbers;
using log4net;
using System.Data.SqlClient;
using CiscoDatabaseProgram.Functions.MySQL;
using System.Configuration;

namespace CiscoDatabaseProgram.Functions.SerialNumbers
{
    class General
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);   

        public static void getSerialForRouters (List<router> routersWithoutSerial, string username, string password)
        {
            // command sentence below if you want to test
            //routersWithoutSerial = receiveRoutersWithoutSerial(); //gets list of routers without serialnumber
            List<router> finalRouterlist = new List<router>(); // list of routers, all routers will have a Serialnumber
            foreach (var router in routersWithoutSerial) 
            {
                string ChassisSerialNumber = TelnetConnection.telnetClientTCP(router.routerAddress, username, password);
                if (ChassisSerialNumber != null)
                {
                    router.routerSerialnumber = ChassisSerialNumber;
                    log.Info("Serialnumber added - " + router.routerAddress);
                    finalRouterlist.Add(router);
                }
                else
                {
                    Console.WriteLine("serienummer van " + router.routerAddress + " kon niet worden gevonden");
                    log.Error("Serialnumber could not be found ip: " + router.routerAddress);
                    finalRouterlist.Add(router);
                }
            }
            Data.updateRoutersOwnServer(finalRouterlist);
            Console.WriteLine("serienummers zijn opgehaald en in de database gezet");
            log.Info("Serialnumbers are synchronized");

        }
        private static List<router> receiveRoutersWithoutSerial()
        {
            List<router> routersWithoutSerial = new List<router>(); // list for all routers without serial number
            SqlConnection connectionToOwnDB = Connections.OwnDB(); // connection to Cisco Tool database
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.OwnServerServerQuery); // returns list of items from OwnServer
            foreach (var item in OwnDatabaseData) // loop to get routers without a serialnumber
            {
                if (item.routerSerialnumber == "") // if serialnumber field is empty
                {
                    routersWithoutSerial.Add(item); // router will be added to list if it had no serialnumber
                }
            }
            if (routersWithoutSerial.Count >= 1) // if list has more than one
            {
                return routersWithoutSerial; // return found routers

            }
            else // if all the routers have a serialnumber
            {
                Console.WriteLine("Alle routers in de database hebben een serienummer");
                log.Info("All routers in the database have a serialnumber");
                return null;
            } 
        }
    }
}
    