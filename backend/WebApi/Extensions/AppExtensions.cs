using WebApi.Middlewares;

namespace WebApi.Extensions;

/// <summary>
/// 
/// </summary>
public static class AppExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public static void UseSwaggerExtension(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi");
        });
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMiddleware>();
    }
}

