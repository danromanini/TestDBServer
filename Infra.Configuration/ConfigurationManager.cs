using Test.Domain.Interface;

namespace Infra.Configuration
{
    public class ConfigurationManager : IConfigurationManager
    {        
        public IConfigurationProvider ConfigurationProvider { get; private set; }
        public IConnectionStringProvider ConnectionStringProvider { get; private set; }

        public ConfigurationManager(JsonConfiguration configuration, IConfigurationProvider configurationProvider, IConnectionStringProvider connectionStringProvider)
        {
            ConfigurationProvider = configurationProvider;
            ConnectionStringProvider = connectionStringProvider;
        }
    }
}
