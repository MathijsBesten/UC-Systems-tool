namespace Cisco_Tool.Values
{
    class PrivateValues
    {
        public static string OwnServerServerQuery = "select * from dbo.router ORDER BY router_friendlyname";
        public class router
        {
            public int routerId { get; set; }
            public string routerName { get; set; }
            public string routerAlias { get; set; }
            public string routerAddress { get; set; }
            public string routerActivate { get; set; }
            public string routerSerialnumber { get; set; }
            public int routerMainDB { get; set; }

        }
    }
}
