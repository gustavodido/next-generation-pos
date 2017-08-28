using System.Collections.Generic;
using System.Linq;
using Dapper;
using WebApi.Configuration;

namespace WebApi.Services
{
    public class DapperService
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public DapperService(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public virtual IEnumerable<T> List<T>(string query) where T : class
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                return connection
                    .Query<T>(query)
                    .ToList();
            }
        }
    }
}