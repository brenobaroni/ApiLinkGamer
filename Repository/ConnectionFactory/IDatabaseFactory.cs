using MySqlConnector;

namespace Data.ConnectionFactory
{
    public interface IDatabaseFactory
    {
        MySqlConnection GetDbConnection { get; }
    }
}
