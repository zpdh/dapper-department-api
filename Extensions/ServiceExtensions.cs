using DapperDepartmentApi.Data;

namespace DapperDepartmentApi.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConnectionFactory(configuration);
    }

    private static void AddConnectionFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection")!;

        services.AddSingleton<IDbConnectionFactory>(new DbConnectionFactory(connectionString));
    }
}