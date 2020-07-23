using System;

namespace Backend
{
    public class ServerInfoResponse
    {
        public DateTime Timestamp { get; set; }
        public string Hostname { get; set; }
        public string ServerIPAddress { get; set; }
        public string ClientIPAddress { get; set; }
    }
}
