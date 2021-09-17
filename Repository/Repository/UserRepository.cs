using Dapper;
using Data.ConnectionFactory;
using Data.Context;
using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        IDatabaseFactory _connection;
        private readonly ApiLinkGamerContext _context;

        public UserRepository(IDatabaseFactory connection, ApiLinkGamerContext context)
        {
            _connection = connection;
            _context = context;
        }

        public async Task<User?> GetByEmail(string email, bool ativo)
        {

            using (var connection = _connection.Connection())
            {
                var sql = "select * from [Linkgamer].[dbo].[User] where[Email] = @Email and[Ativo] = Ativo";

                using(var multi = connection.QueryMultipleAsync(sql, new { Email = email, Ativo = ativo }).Result)
                {
                    return (User?)multi.Read<User?>().FirstOrDefault();
                }
            }
        }


        public async Task<bool> InsertUser(User user)
        {
            var users = await _context.User.Where(w => w.Ativo == true).ToListAsync();
            using var transaction = await _context.Database.BeginTransactionAsync();
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
