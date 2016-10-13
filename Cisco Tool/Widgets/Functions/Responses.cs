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
            if (fullText != "")
            {
                string[] enters = Regex.Split(fullText, "\\r\\n");
                string fullstringWithoutWord = "";
                string fullStringWithWord = "";
                int count = 0;
                string goalVariable;
                if (enterCountInfront == 0 && enterCountInSelectedString == 0) // the complete reponse
                {
                    goalVariable = fullText;
                    string splitter = @"\r\n";
                    int lenthOfSplitter = splitter.Length;
                    int locationOfFirstSplitter = goalVariable.IndexOf("\r\n");
                    goalVariable = goalVariable.Substring((locationOfFirstSplitter + lenthOfSplitter));
                }
                else
                {
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
                    goalVariable = fullStringWithWord.Remove(0, fullstringWithoutWord.Length);
                }
                //OPTIONAL - removes all enters
                goalVariable = goalVariable.Replace(@"\r\n", "");

                return goalVariable;
            }
            else
            {
                return ""; // starting string was empty
            }

        }
    }
}
