using Microsoft.Extensions.Configuration;
using TestAssignmentProject.models;

namespace TestAssignmentProject.utilities
{
    public class ConfigReader
    {   
        public static Configs getGlobalConfigs()
        {
            var globalConfigs = GetConfig();

            var configs = new Configs();
            configs.GoIbiboAirportSearchGetApiUrl = globalConfigs["URLs:GoIbiboAirportSearchGetApiUrl"];
            configs.ReqResCreateUserPostApiUrl = globalConfigs["URLs:ReqResCreateUserPostApiUrl"];
            return configs;
        }

        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true);

            return builder.Build();
        }
    }
}
