using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Functions
{
    class Responses
    {
        public static string getStringFromResponse(string fullText,int enterCountInfront,int enterCountInSelectedString)
        {
            string[] enters = Regex.Split(fullText, "\\r\\n");
            string fullstringWithoutWord = "";
            string fullStringWithWord = "";
            int count = 0;
            foreach (var item in enters)
            {
                if (count < (enterCountInfront))
                {
                    fullstringWithoutWord += item;
                    fullStringWithWord += item;
                    count++;
                }
                else if (count < (enterCountInfront + 1 + enterCountInSelectedString))
                {
                    fullStringWithWord += item;
                    count++;
                }
                else
                {
                    break;
                }

            }
            int startIndexOfResponse = fullstringWithoutWord.Length;
            string goalVariable = fullStringWithWord.Remove(0, fullstringWithoutWord.Length);
            return goalVariable;
        }

    }
}
