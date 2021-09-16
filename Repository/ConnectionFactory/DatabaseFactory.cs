
using MySqlConnector;
using System.Data;
using System.Data.Entity;

namespace Data.ConnectionFactory
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        public MySqlConnection GetDbConnection => SetConnection();


        private MySqlConnection SetConnection()
        {
            string? connectionString = Environment.GetEnvironmentVariable("ApiLinkGamerConnection");

            if (connectionString != null)
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            else
                throw new Exception("Erro ao connectar-se a base de dados.");
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
