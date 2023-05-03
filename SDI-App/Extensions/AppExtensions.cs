using Microsoft.EntityFrameworkCore;
using SDI_App.Data;
using SDI_App.Mappings;
using SDI_App.Middleware;
using SDI_App.Repository;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Extensions;

public static class PhoneExtensions
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("LocalConnection"));
        });
        return services;
    }

    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PhoneMappings));
        services.AddAutoMapper(typeof(PersonMappings));
        services.AddAutoMapper(typeof(TabletMappings));
        services.AddAutoMapper(typeof(AwMappings));
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<ITabletRepository, TabletRepository>();
        services.AddScoped<IAccessedWebsiteRepository, AccessedWebsiteRepository>();
        return services;
    }

    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ErrorHandlerMiddleware>();
        return services;
    }
}
