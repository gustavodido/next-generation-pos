using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace WebApi.Configuration
{
    public class DbConnectionFactory
    {
        private readonly IOptions<ApplicationConfiguration> _applicationConfiguration;

        public DbConnectionFactory(IOptions<ApplicationConfiguration> applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        public virtual IDbConnection Create()
        {
            var connection = new NpgsqlConnection(_applicationConfiguration.Value.ConnectionString);
            connection.Open();

            return connection;
        }
    }
}