using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

using CiscoDatabaseProgram.Functions;
using MySql.Data.MySqlClient;
using CiscoDatabaseProgram.Values;
using CiscoDatabaseProgram.Functions.MySQL;
using CiscoDatabaseProgram.Functions.Logging;
using System.Data.SqlClient;
using CiscoDatabaseProgram.Functions.Main;

namespace CiscoDatabaseProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.Main.Main.MainFunction();
        }
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}