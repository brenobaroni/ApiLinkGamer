using Dapper;
using Data.ConnectionFactory;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        IDatabaseFactory _factory;
        ApiLinkGamerContext _context; 

        public UserRepository(IDatabaseFactory databaseFactory, ApiLinkGamerContext context)
        {
            _factory = databaseFactory;
            _context = context;
        }

        public async Task<User> GetByEmail(string email, bool ativo)
        {
            using (var connection = _factory.GetDbConnection)
            {
                 return await connection.QueryFirstAsync<User>("select * from User where Email = @Email and Ativo = @Ativo", new { Email = email, Ativo = ativo });
            }
        }
    }
}
