using Application.Interfaces;
using Application.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ApplicationDb"));
        }
        else
        {
            string _defaultConnection = configuration.GetConnectionString("DefaultConnection") ?? "";
            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(_defaultConnection, ServerVersion.AutoDetect(_defaultConnection), mySqlOptions => mySqlOptions.MigrationsAssembly("WebApi")));
        }

        #region Repositories
        services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddTransient<IUserRepositoryAsync, UserRepositoryAsync>();
        services.AddTransient<IProductRepositoryAsync, ProductRepositoryAsync>();

        #endregion

    }
}

