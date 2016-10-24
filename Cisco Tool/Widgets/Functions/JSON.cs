using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Functions
{
    class JSON
    {
        public static string path = (System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "\\Ciscotool";
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
                }
            }
            else
            {
                if (!File.Exists(path + fileName))
                {
                    FileStream file =  File.Create(path + fileName);
                    file.Close();
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
            System.IO.File.WriteAllText(path + fileName, json);
        }
        public static List<Classes.widget> readJSON()
        {
            if (!Directory.Exists(path))
            {
               var file =  Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + fileName))
            {
                var file = File.Create(path + fileName);
                file.Close();
            }
            string json = File.ReadAllText(path + fileName);
            if (json != "")
            {
                var widgetsArray = JsonConvert.DeserializeObject<List<widget>>(json);
                return widgetsArray;
            }
            else
            {
                return null;
            }
        }

        public static void removeWidgetFromWidgetList(int index)
        {
            var widgets = readJSON(); //get current widgets
            widgets.RemoveAt(index);
            string json = JsonConvert.SerializeObject(widgets.ToArray(), Formatting.Indented);
            System.IO.File.WriteAllText(path + fileName, json);

        }
    }
}
