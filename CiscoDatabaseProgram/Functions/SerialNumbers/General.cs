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

        public static void getSerialnumbersForRouters(string username, string password)
        {
            List<router> routersWithoutSerial = receiveAllRoutersWithoutSerial(); 
            List<router> finalRouterlist = new List<router>();
            if (routersWithoutSerial == null)
            {
                Console.WriteLine("Alle routers hebben in de database een serienummer");
                log.Info("All routers in the database have a serialnumber");
                return;
            }
            foreach (var router in routersWithoutSerial)
            {
                string ChassisSerialNumber = TelnetConnection.telnetClientTCP(router, username, password); // return null if serialnumber is not found
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
                }
            }
            Data.updateRoutersOwnServer(finalRouterlist);
            Console.WriteLine("serienummers zijn opgehaald en in de database gezet");
            log.Info("Serialnumbers are synchronized");

        }
        public static void TESTmanualListGetSerialnumbersForRouters(List<router> routersWithoutSerial, string username, string password)
        {
            List<router> finalRouterlist = new List<router>();
            if (routersWithoutSerial.Count == 0)
            {
                Console.WriteLine("Alle routers hebben in de database een serienummer");
                log.Info("All routers in the database have a serialnumber");
                return;
            }
            foreach (var router in routersWithoutSerial)
            {
                string ChassisSerialNumber = TelnetConnection.telnetClientTCP(router, username, password); // return null if serialnumber is not found
                if (ChassisSerialNumber != "")
                {
                    router.routerSerialnumber = ChassisSerialNumber;
                    log.Info("Serialnumber found for - " + router.routerAddress);
                    finalRouterlist.Add(router);
                }
                else
                {
                    Console.WriteLine("serienummer van " + router.routerAddress + " kon niet worden gevonden");
                    log.Error("Serialnumber could not be found ip: " + router.routerAddress);
                }
            }
            Data.updateRoutersOwnServer(finalRouterlist);
            Console.WriteLine("serienummers zijn in de database gezet");
            log.Info("Serialnumbers are synchronized");

        }
        private static List<router> receiveAllRoutersWithoutSerial()
        {
            List<router> routersWithoutSerial = new List<router>();
            SqlConnection connectionToOwnDB = Connections.OwnDB();
            List<router> OwnDatabaseData = Data.getDataFromMicrosoftSQL(connectionToOwnDB, PrivateValues.getAllFromOwnDatabaseQuery); 
            foreach (var Router in OwnDatabaseData) 
            {
                if (Router.routerSerialnumber == "")
                {
                    routersWithoutSerial.Add(Router); 
                }
            }
            if (routersWithoutSerial.Count >= 1) 
            {
                return routersWithoutSerial; 

            }
            else
            {
                Console.WriteLine("Alle routers in de database hebben een serienummer");
                log.Info("All routers in the database have a serialnumber");
                return null;
            } 
        }
        public static string findCereal(string originalstring) // Find chassis serial number ** command: show diag **
        {
            string searchPattern = "Chassis Serial Number    :";
            if (originalstring.Contains(searchPattern))
            {
                int indexOfPattern = originalstring.IndexOf(searchPattern); // index of the pattern
                int startIndex = indexOfPattern + searchPattern.Length + 1; // adding 1 for space after :
                string chassisSerialNumber = originalstring.Substring(startIndex, 11);
                return chassisSerialNumber;
            }
            else
            {
                Console.WriteLine("Serienummber kon niet worden achterhaalt");
                log.Error("ERROR - could not find serialnumber using substring method");
                return null;
            }
        }
    }
}
    