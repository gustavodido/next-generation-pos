using System;

namespace WebApi.Configuration
{
    public class EvolveConfiguration
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public EvolveConfiguration(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public void Migrate()
        {
            using (var connection = _dbConnectionFactory.Create())
            {
                var evolve = new Evolve.Evolve(connection, Console.WriteLine);
                // evolve.Clean();
                evolve.Migrate();
            }
        }
    }
}