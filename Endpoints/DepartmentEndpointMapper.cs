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
        MapUpdateEndpoint(app);
        MapDeleteEndpoint(app);
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

    private static void MapUpdateEndpoint(WebApplication app)
    {
        app.MapPut($"{Endpoint}/id:int",
            async (IDepartmentRepository repository, int id, DepartmentDto department) => {
                await repository.UpdateDepartmentAsync(id, department);

                return Results.NoContent();
            });
    }

    private static void MapDeleteEndpoint(WebApplication app)
    {
        app.MapDelete($"{Endpoint}/id:int",
            async (IDepartmentRepository repository, int id) => {
                await repository.DeleteDepartmentAsync(id);

                return Results.NoContent();
            });
    }
}