using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace TestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var configService = new ConfigService();

            configService.CreateAppConfig(new AppConfig
            {
                WorkDirFilePath = @"E:\out",
                SourceFilePath = @"C:\Users\Artem\Documents",
                Environment = new List<ConfigEnv>
                {
                    new ConfigEnv
                    {
                        Type = EnvType.DEV,
                        Hostname = Dns.GetHostName(),
                        Fqdn = $"{IPGlobalProperties.GetIPGlobalProperties().HostName}.{IPGlobalProperties.GetIPGlobalProperties().DomainName}"
                    },
                    new ConfigEnv
                    {
                        Type = EnvType.PROD,
                        Hostname = "a301-311-5638",
                        Fqdn = "a301-311-5638.some.domain.com"
                    }
                }
            });

            var config = configService.GetAppConfig();
            var runtimeType = config.CurrentRuntimeType;

            configService.CreateConnectionConfig(new ConnectionConfig
            {
                Connections = new List<ConnectionConfigItem>
                {
                    new ConnectionConfigItem
                    {
                        Credential = new ConnectionCredential
                        {
                            AccessKey = "uyecqwuihcdusihduiash",
                            SecretKey = "jiejdiojiodjeijdioeij"
                        },
                        Fqdn = "server-1.some.domain.com"
                    },
                    new ConnectionConfigItem
                    {
                        Credential = new ConnectionCredential
                        {
                            AccessKey = "kdokdeokdoekdoekdoe",
                            SecretKey = "kxoekdoekdeokdoekdo"
                        },
                        Fqdn = "server-2.some.domain.com"
                    }
                }
            });

            var connectionConfig = configService.GetConnectionConfig();
        }
    }
}
