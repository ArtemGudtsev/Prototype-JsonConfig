﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestSubstring
{
    public class ConnectionConfig
    {
        [JsonProperty(PropertyName = "targets")]
        public List<ConnectionConfigItem> Connections { get; set; }
    }
}
