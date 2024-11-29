using DapperDepartmentApi.Data.Repositories;
using DapperDepartmentApi.DTOs;

namespace DapperDepartmentApi.Endpoints;

public class DepartmentEndpointMapper
{
    private const string Endpoint = "departments";

    public static void MapEndpoints(WebApplication app)
    {
        MapGetAllEndpoint(app);
        MapGetSingleEndpoint(app);
        MapPostEndpoint(app);
    }

    private static void MapGetAllEndpoint(WebApplication app)
    {
        app.MapGet(Endpoint,
            async (IDepartmentRepository repository) => {
                    var departments = await repository.GetAllDepartmentsAsync();

                    return Results.Ok(departments);
            });
    }

    private static void MapGetSingleEndpoint(WebApplication app)
    {
        app.MapGet($"{Endpoint}/id:int",
            async (IDepartmentRepository repository, int id) => {
                var department = await repository.GetSingleDepartmentAsync(id);

                return Results.Ok(department);
            });
    }

    private static void MapPostEndpoint(WebApplication app)
    {
        app.MapPost(Endpoint,
            async (IDepartmentRepository repository, DepartmentDto department) => {
                await repository.InsertIntoDepartmentAsync(department);

                return Results.NoContent();
            });
    }
}