using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;
using Newtonsoft.Json;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Functions
{
    class JSON
    {
        private static readonly ILog log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string path = (Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\Ciscotool";
        public static string fileName = "\\widgets.json";


        public static void writeJSON(List<widget> widgetList)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                if (!File.Exists(path + fileName))
                {
                    FileStream file = File.Create(path + fileName);
                    file.Close();
                    log.Info("Cisco directory and widget file has been made");
                }
                log.Info("widget file has been made");
            }
            else
            {
                if (!File.Exists(path + fileName))
                {
                    FileStream file =  File.Create(path + fileName);
                    file.Close();
                    log.Info("widget file has been made");
                }
            }

            List<widget> currentJSON = readJSON();
            if (currentJSON != null)
            {
                foreach (var item in currentJSON)
                {
                    widgetList.Add(item);
                }
            }
            string json = JsonConvert.SerializeObject(widgetList.ToArray(),Formatting.Indented);
            File.WriteAllText(path + fileName, json);
            log.Info("Widgets are written to local file");
        }
        public static List<widget> readJSON()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                log.Info("Cisco directory has been made");
            }
            if (!File.Exists(path + fileName))
            {
                var file = File.Create(path + fileName);
                file.Close();
                log.Info("widget file has been made");
            }
            string json = File.ReadAllText(path + fileName);
            if (json != "")
            {
                var widgetsArray = JsonConvert.DeserializeObject<List<widget>>(json);
                log.Info("Widgets are loaded from local file");
                return widgetsArray;
            }
            log.Error("widget file was empty while trying to read");
            return null;
        }

        public static void removeWidgetFromWidgetList(int index)
        {
            try
            {
                var widgets = readJSON(); //get current widgets
                widgets.RemoveAt(index);
                string json = JsonConvert.SerializeObject(widgets.ToArray(), Formatting.Indented);
                File.WriteAllText(path + fileName, json);
                log.Info("Widget ' " + widgets[index] + " ' is removed from local widget file");
            }
            catch (Exception ex)
            {
                log.Error("Widget cannot be removed because of a error, ");
                log.Error("Errormessage: " + ex.Message);
            }

        }
    }
}
