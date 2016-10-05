using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static Cisco_Tool.Widgets.Classes;

namespace Cisco_Tool.Widgets.Functions
{
    class XML
    {
        public static void XMLReader(int CommandID)
        {
            widget savedWidget = new widget();
            XmlReader reader;


        }
        public static void XMLWriter(List<widget> details)
        {
            string XMLFile = Environment.SpecialFolder.MyDocuments + "\\ciscotoolconfig";
            if (File.Exists(XMLFile))
            {
                File.Create(XMLFile);
            }
            XmlDocument xmlDoc = new XmlDocument();


        }
    }
}

