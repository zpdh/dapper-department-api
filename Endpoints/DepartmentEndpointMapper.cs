using DapperDepartmentApi.Data.Repositories;

namespace DapperDepartmentApi.Endpoints;

public class DepartmentEndpointMapper
{
    private const string Endpoint = "departments";

    public static void MapEndpoints(WebApplication app)
    {
        MapGetAllEndpoint(app);
    }

    private static void MapGetAllEndpoint(WebApplication app)
    {
        app.MapGet(Endpoint,
            async (IDepartmentRepository repository) => {
                var departments = await repository.GetAllDepartments();

                return departments;
            });
    }
}