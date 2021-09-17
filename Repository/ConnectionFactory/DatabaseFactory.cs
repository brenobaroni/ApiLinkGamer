
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Data.ConnectionFactory
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        public IDbConnection Connection()
        {
            return new SqlConnection(Environment.GetEnvironmentVariable("ApiLinkGamerConnection"));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
