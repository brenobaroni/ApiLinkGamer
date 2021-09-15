using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email, bool ativo);
        Task<bool> InsertUser(User user);
    }
}
