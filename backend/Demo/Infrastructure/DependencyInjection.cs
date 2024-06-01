using Demo.Application.Common.Interfaces;
using Demo.Infrastructure.Common.Persistence;
using Demo.Infrastructure.Users.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddPersistence();
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        
        services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("UsersDatabase"));

        return services;
    }
}