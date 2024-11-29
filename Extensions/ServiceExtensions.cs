using DapperDepartmentApi.Data;
using DapperDepartmentApi.Data.Repositories;

namespace DapperDepartmentApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConnectionFactory(configuration);
        services.AddRepositories();
    }

    private static void AddConnectionFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection")!;

        services.AddSingleton<IDbConnectionFactory>(new DbConnectionFactory(connectionString));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
    }
}