using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace TestSubstring
{
    public class ConfigService
    {
        protected string AppConfigFilePath { get; set; } = "config.app.json";

        public AppConfig GetAppConfig()
        {
            var content = File.ReadAllText(AppConfigFilePath);

            var appConfig = JsonConvert.DeserializeObject<AppConfig>(content);

            return appConfig;
        }

        public void CreateAppConfig(AppConfig config)
        {
            var content = JsonConvert.SerializeObject(config, Formatting.Indented);

            if (File.Exists(AppConfigFilePath))
            {
                File.Delete(AppConfigFilePath);
            }

            File.WriteAllText(AppConfigFilePath, content);
        }

        #region Create specific configuration

        public void CreateConnectionConfig(ConnectionConfig config)
        {
            var content = JsonConvert.SerializeObject(config.Connections, Formatting.Indented);
            var pathToConnectionConfig = GetAppConfig().ConnectionConfigFilePath;

            if (File.Exists(pathToConnectionConfig))
            {
                File.Delete(pathToConnectionConfig);
            }

            File.WriteAllText(pathToConnectionConfig, content);
        }
        #endregion

        #region Retrieve specific configurations

        public ConnectionConfig GetConnectionConfig()
        {
            var pathToConnectionConfig = GetAppConfig().ConnectionConfigFilePath;
            var content = File.ReadAllText(pathToConnectionConfig);
            var config = new ConnectionConfig
                {Connections = JsonConvert.DeserializeObject<List<ConnectionConfigItem>>(content)};

            return config;
        }
        #endregion

    }
}
