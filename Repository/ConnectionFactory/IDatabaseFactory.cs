using MySql.Data.MySqlClient;

namespace Data.ConnectionFactory
{
    public interface IDatabaseFactory
    {
        MySqlConnection GetDbConnection { get; }
    }
}
