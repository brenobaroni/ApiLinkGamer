
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

    }

    #endregion [ Repositório Genérico ]

    #region [ Repositório Específicos - Core]

    private static void AddRepoitorys(ref IServiceCollection services)
    {
        //services.AddScoped<ITokenServiceCore, TokenServiceCore>();
        //services.AddScoped(typeof(IUserCore), typeof(UserCore));
    }

    #endregion [ Repositório Específicos ]

    #region [ Repositório Específicos - Core]

    private static void AddGenerics(ref IServiceCollection services)
    {
        //services.AddScoped<ITokenServiceCore, TokenServiceCore>();
        //services.AddScoped(typeof(IUserCore), typeof(UserCore));
    }

    #endregion [ Repositório Específicos ]
}
