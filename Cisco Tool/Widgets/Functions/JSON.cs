using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;
using Newtonsoft.Json;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Functions
{
    class Json
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string Path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\Ciscotool";
        public static string FileName = "\\widgets.json";


        public static void WriteJson(List<Widget> widgetList)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                if (!File.Exists(Path + FileName))
                {
                    FileStream file = File.Create(Path + FileName);
                    file.Close();
                    Log.Info("Cisco directory and widget file has been made");
                }
                Log.Info("widget file has been made");
            }
            else
            {
                if (!File.Exists(Path + FileName))
                {
                    FileStream file =  File.Create(Path + FileName);
                    file.Close();
                    Log.Info("widget file has been made");
                }
            }

            List<Widget> currentJson = ReadJson();
            if (currentJson != null)
            {
                foreach (var item in currentJson)
                {
                    widgetList.Add(item);
                }
            }
            string json = JsonConvert.SerializeObject(widgetList.ToArray(),Formatting.Indented);
            File.WriteAllText(Path + FileName, json);
            Log.Info("Widgets are written to local file");
        }
        public static List<Widget> ReadJson()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
                Log.Info("Cisco directory has been made");
            }
            if (!File.Exists(Path + FileName))
            {
                var file = File.Create(Path + FileName);
                file.Close();
                Log.Info("widget file has been made");
            }
            string json = File.ReadAllText(Path + FileName);
            if (json != "")
            {
                var widgetsArray = JsonConvert.DeserializeObject<List<Widget>>(json);
                Log.Info("Widgets are loaded from local file");
                return widgetsArray;
            }
            Log.Error("widget file was empty while trying to read");
            return null;
        }

        public static void RemoveWidgetFromWidgetList(int index)
        {
            try
            {
                var widgets = ReadJson(); //get current widgets
                widgets.RemoveAt(index);
                string json = JsonConvert.SerializeObject(widgets.ToArray(), Formatting.Indented);
                File.WriteAllText(Path + FileName, json);
                Log.Info("Widget ' " + widgets[index] + " ' is removed from local widget file");
            }
            catch (Exception ex)
            {
                Log.Error("Widget cannot be removed because of a error, ");
                Log.Error("Errormessage: " + ex.Message);
            }

        }
    }
}
