
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ApiLinkGamerContextFactory : IDesignTimeDbContextFactory<ApiLinkGamerContext>
    {
        public ApiLinkGamerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiLinkGamerContext>();
            string? connectionString = Environment.GetEnvironmentVariable("ApiLinkGamerDBConnection");

            if (connectionString != null)
            {
                optionsBuilder.UseMySQL(connectionString);
            }
            else
                throw new Exception("Erro ao connectar-se a base de dados.");

            return new ApiLinkGamerContext(optionsBuilder.Options);
        }
    }
}
