using System.Text.RegularExpressions;


namespace Cisco_Tool.Widgets.Functions
{
    class Responses
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string GetStringFromResponse(string fullText,int enterCountInfront,int enterCountInSelectedString)
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
                    goalVariable = fullStringWithWord.Remove(0, fullstringWithoutWord.Length);
                }
                //OPTIONAL - removes all enters
                goalVariable = goalVariable.Replace(@"\r\n", "");
                Log.Info("substring is found from response");
                return goalVariable;
            }
            else
            {
                return ""; // starting string was empty
            }
        }
    }
}
