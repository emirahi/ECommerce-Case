using ECommerce.Business.Exceptions;

namespace ECommerce.WebApi.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (InsufficientStockException e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            httpContext.Response.Body = httpContext.Response.Body;
            await httpContext.Response.WriteAsync(e.Message);
        }
        catch (Exception e)
        {
            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            await httpContext.Response.WriteAsync(e.Message);
            
        }
    }
    
}
