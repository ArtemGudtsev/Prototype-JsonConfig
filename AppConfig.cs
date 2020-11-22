using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace TestSubstring
{
    public class AppConfig
    {
        #region Runtime dependend properties
        public string ConnectionConfigFilePath => $"config.connection.{CurrentRuntimeType.ToString().ToLowerInvariant()}.json";
        #endregion

        public string SourceFilePath { get; set; }

        public string WorkDirFilePath { get; set; }

        public List<ConfigEnv> Environment { get; set; }

        public EnvType CurrentRuntimeType
        {
            get
            {
                var hostname = IPGlobalProperties.GetIPGlobalProperties().HostName;
                var env = Environment.FirstOrDefault(e => string.Equals(e.Hostname, hostname, StringComparison.InvariantCultureIgnoreCase));

                return env?.Type ?? EnvType.NONE;
            }
        }
    }
}