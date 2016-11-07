using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisco_Tool.Widgets
{
    class Classes
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
        }

        public class widgetResult
        {
            public int widgetTag { get; set; }
            public string widgetOutput { get; set; }
        }
    }
}
