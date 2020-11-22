using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace TestSubstring
{
    public enum EnvType
    {
        NONE = 0,
        DEV = 1,
        UAT = 2,
        PROD = 3
    }
    public class ConfigEnv
    {
        public string Fqdn { get; set; }

        public string Hostname { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EnvType Type { get; set; }
    }
}
