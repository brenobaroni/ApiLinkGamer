
namespace Middleware;

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class InterceptorApiLinkGamerMiddleware
{
    private readonly RequestDelegate _next;


    public async Task Invoke(HttpContext context)
    {
        var endPoint = context.GetEndPoint();
    }
}
