using Demo.Application;
using Demo.Infrastructure;
using Demo.Presentation.Endpoints;

namespace Demo.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services
            .AddHttpContextAccessor();
    }
    
    public static IServiceCollection AddModule(this IServiceCollection services)
    {
        return services
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure();
    }

    public static void UseModule(this WebApplication application, WebApplication app)
    {
        app.MapApiEndpoints();
    }
}