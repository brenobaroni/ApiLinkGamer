using Dapper;
using Data.ConnectionFactory;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Models;
using System.Data.Entity;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        IDatabaseFactory _factory;
        private readonly ApiLinkGamerContext _context; 

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


        public async Task<bool> InsertUser(User user)
        {
            using (var connection = _factory.GetDbConnection)
            {
                var sdasda = await connection.QueryFirstAsync<User>("select * from User");
            }


            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();
                transaction.Commit();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
