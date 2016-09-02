using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CiscoDatabaseProgram.Functions.MySQL
{
    class General
    {
        public static MySqlConnection MySQLConnnection(string server,string database,string username,string password) // makes connection with a database
        {
            server = "localhost";
            database = "routers";
            username = "root";
            password = "usbw";
            string connectionString = "SERVER="+server+";DATABASE="+database+";UID:"+ username + ";PASSWORD:"+password+";";
            return new MySqlConnection(connectionString);    
        }
        public static void GetDatabaseInfo()
        {

        }

    }
}
