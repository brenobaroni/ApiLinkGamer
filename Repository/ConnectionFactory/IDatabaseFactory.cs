using System.Data;

namespace Data.ConnectionFactory
{
    public interface IDatabaseFactory
    {
        IDbConnection Connection();
    }
}
