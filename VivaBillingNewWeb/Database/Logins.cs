using System;

namespace VivaBillingNewWeb.Database
{
    public class Logins
    {
        public long ID { get; set; }
        public string IP { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
    }
}