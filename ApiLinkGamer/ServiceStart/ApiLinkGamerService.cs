
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiLinkGamer.ServiceStart;
public class ApiLinkGamerService
{
    public static void Start(ref IServiceCollection services)
    {
        StartAuthentication(ref services);
    }

    private static void StartAuthentication(ref IServiceCollection services)
    {
        var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("ApiLinkGamerToken") ?? "adW#)#0w#)a0t0aw0yraegsgaw04w0T$t40Awt4044");

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateAudience = false,
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = async (context) =>
                {
                    context.Response.StatusCode = 401;
                    await context.Response.HttpContext.Response.WriteAsync("Acesso Negado!");
                },
                OnChallenge = async (context) =>
                 {
                     context.HandleResponse();
                     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                     context.Response.ContentType = "application/text";
                     await context.Response.WriteAsync("Acesso Negado!");
                 },
                OnForbidden = async (context) =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/text";
                    await context.Response.WriteAsync("Acesso Negado!");
                }
            };
        });
    }
}
