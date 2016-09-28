using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Functions.Network
{
    class validation
    {
        public static bool validateIPv4(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }
            string[] splittedValues = ipString.Split('.');
            if (splittedValues.Length != 4)
            {
                return false;
            }
            byte splitResult;
            return splittedValues.All(r => byte.TryParse(r, out splitResult));

        }
    }
}
