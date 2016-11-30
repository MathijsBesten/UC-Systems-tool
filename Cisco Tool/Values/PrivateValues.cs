namespace Cisco_Tool.Values
{
    class PrivateValues
    {
        public static string OwnServerServerQuery = "select * from dbo.router ORDER BY router_friendlyname";
        public class Router
        {
            public int RouterId { get; set; }
            public string RouterName { get; set; }
            public string RouterAlias { get; set; }
            public string RouterAddress { get; set; }
            public string RouterActivate { get; set; }
            public string RouterSerialnumber { get; set; }
            public int RouterMainDb { get; set; }
        }
    }
}
