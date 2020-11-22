using System;
using System.Collections.Generic;
using System.Text;

namespace TestSubstring
{
    public class ConnectionConfigItem
    {
        public string Fqdn { get; set; }

        public int Port { get; set; } = 8834;

        public ConnectionCredential Credential { get; set; }
    }
}
