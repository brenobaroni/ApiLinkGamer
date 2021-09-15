
using Data.ConnectionFactory;
using Data.Context;
using Data.Repository;
using Data.Repository.Interfaces;
using Service.Service;
using Service.Service.Interfaces;

namespace ApiLinkGamer.Configuration;
public class DependencyInjection
{
    #region [ Método Externo ]

    public static void AddDependencies(ref IServiceCollection services)
    {
        AddServices(ref services);
        AddRepoitorys(ref services);
        AddGenerics(ref  services);
    }

    #endregion [ Método Externo ]

    #region [ Repositório Genérico ]

    private static void AddServices(ref IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
    }

    #endregion [ Repositório Genérico ]

    #region [ Repositório Específicos - Core]

    private static void AddRepoitorys(ref IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }

    #endregion [ Repositório Específicos ]

    #region [ Repositório Específicos - Core]

    private static void AddGenerics(ref IServiceCollection services)
    {
        services.AddDbContext<ApiLinkGamerContext>();
        services.AddTransient<IDatabaseFactory, DatabaseFactory>();
        //services.AddScoped<ITokenServiceCore, TokenServiceCore>();
        //services.AddScoped(typeof(IUserCore), typeof(UserCore));
    }

    #endregion [ Repositório Específicos ]
}
