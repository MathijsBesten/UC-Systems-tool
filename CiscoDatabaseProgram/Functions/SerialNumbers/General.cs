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

        public static void getSerialForRouters(string username, string password)
        {
            // command sentence below if you want to test
            List<router> routersWithoutSerial = receiveRoutersWithoutSerial(); //gets list of routers without serialnumber
            List<router> finalRouterlist = new List<router>(); // list of routers, all routers will have a Serialnumber
            foreach (var router in routersWithoutSerial) //foreach router that has no serialnumber in database
            {
                string ChassisSerialNumber = TelnetConnection.telnetClientTCP(router, username, password); // get serialnumber
                if (ChassisSerialNumber != "") // if serialnumber is found 
                {
                    router.routerSerialnumber = ChassisSerialNumber; //assign found serialnumber to router
                    log.Info("Serialnumber added - " + router.routerAddress); // log to logfile
                    finalRouterlist.Add(router); // add complete router to finalList
                }
                else // serialnumber could not be found ** maybe timeout **
                {
                    Console.WriteLine("serienummer van " + router.routerAddress + " kon niet worden gevonden"); // let user know that there is something wrong
                    log.Error("Serialnumber could not be found ip: " + router.routerAddress); // log error to logfile
                }
            }
            Data.updateRoutersOwnServer(finalRouterlist); // updating new router details to the Cisco Tool Database
            Console.WriteLine("serienummers zijn opgehaald en in de database gezet"); // let the user know that the data was been updated
            log.Info("Serialnumbers are synchronized"); // log to logfile

        }
        private static List<router> receiveRoutersWithoutSerial() // function will be run from the getSerialForRouters function to get all the routers without a serialnumber
        {
            List<router> routersWithoutSerial = new List<router>(); // initialize list for all routers without serial number
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
    