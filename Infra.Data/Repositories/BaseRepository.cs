using Microsoft.Extensions.Configuration;

namespace Infra.Data.Repositories
{
    public abstract class BaseRepository
    {
        IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").
            GetSection("LancamentosConnection").Value;
            return connection;
        }
    }
}
