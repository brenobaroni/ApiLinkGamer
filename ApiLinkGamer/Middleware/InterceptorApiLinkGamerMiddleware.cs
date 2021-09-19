
using Microsoft.AspNetCore.Http;

namespace Middleware;

public class InterceptorApiLinkGamerMiddleware
{
    private readonly RequestDelegate _next;
    public InterceptorApiLinkGamerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var endPoint = context.GetEndpoint();

        if (endPoint != null)
            await _next(context);

        Console.WriteLine("Middleware end");
    }
}
