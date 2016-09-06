using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;

using CiscoDatabaseProgram.Functions;

namespace CiscoDatabaseProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Functions.MySQL.Data.getDataFromMainDatabase();
            Console.ReadLine();
        }
    }
}