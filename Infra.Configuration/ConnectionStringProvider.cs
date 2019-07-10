using Test.Domain.Interface;

namespace Infra.Configuration
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private static string _cachedConnectionString;

        public string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_cachedConnectionString))
            {
                _cachedConnectionString = "";
            }

            return _cachedConnectionString;
        }
    }
}
