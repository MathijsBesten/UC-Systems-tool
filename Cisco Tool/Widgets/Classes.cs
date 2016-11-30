namespace Cisco_Tool.Widgets
{
    public class Classes
    {
        public class Widget
        {
            public string WidgetName { get; set; }
            public string WidgetType { get; set; }
            public string WidgetCommand { get; set; }
            public bool WidgetUseSelection { get; set; }
            public bool WidgetUseLongProcessTime { get; set; }
            public int WidgetEnterCountBeforeString { get; set; }
            public int WidgetEnterCountInString { get; set; }
            public string WidgetOutput { get; set; }
        }
        public class WidgetResult
        {
            public string WidgetTag { get; set; }
            public string WidgetCommand { get; set; }
            public string WidgetOutput { get; set; }
            public bool UselongTime { get; set; }
        }
        public class TelnetDetails
        {
            public string IpAddress { get; set; }
            public string Command { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Output { get; set; }
            public bool UseLongProcessTime { get; set; }
        }
    }
}
