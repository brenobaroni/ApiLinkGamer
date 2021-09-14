using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Entity;

namespace Data.ConnectionFactory
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        public MySqlConnection GetDbConnection => SetConnection();


        private MySqlConnection SetConnection()
        {
            string? connectionString = Environment.GetEnvironmentVariable("ApiLinkGamerDBConnection");

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
            GetDbConnection.Close();
            GC.SuppressFinalize(this);
        }
    }
}
