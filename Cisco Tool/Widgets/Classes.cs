using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Widgets
{
    public class Classes
    {
        public class widget
        {
            public string widgetName { get; set; }
            public string widgetType { get; set; }
            public string widgetCommand { get; set; }
            public bool widgetUseSelection { get; set; }
            public bool widgetUseLongProcessTime { get; set; }
            public int widgetEnterCountBeforeString { get; set; }
            public int WidgetEnterCountInString { get; set; }
            public string widgetOutput { get; set; }
        }
        public class widgetResult
        {
            public string widgetTag { get; set; }
            public string widgetCommand { get; set; }
            public string widgetOutput { get; set; }
            public bool uselongTime { get; set; }
        }
        public class telnetDetails
        {
            public string IPAddress { get; set; }
            public string command { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string output { get; set; }
            public bool useLongProcessTime { get; set; }
        }
    }
}
