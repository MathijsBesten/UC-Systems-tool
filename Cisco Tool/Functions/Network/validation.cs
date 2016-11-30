using System.Linq;

namespace Cisco_Tool.Functions.Network
{
    class Validation
    {
        public static bool ValidateIPv4(string ipString)
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
