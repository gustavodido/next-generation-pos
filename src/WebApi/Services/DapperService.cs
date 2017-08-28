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
        
        public virtual IEnumerable<T> List<T>(string query, object param) where T : class
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                return connection
                    .Query<T>(query, param)
                    .ToList();
            }
        }

        public virtual T ExecuteScalar<T>(string command)
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                return connection.ExecuteScalar<T>(command);
            }
        }

        public virtual void Execute(string command, object param)
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                connection.Execute(command, param);
            }
        }

    }
}