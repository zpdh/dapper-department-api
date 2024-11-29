namespace DapperDepartmentApi.Endpoints;

public class DepartmentEndpoints
{
    private const string Endpoint = "departments";

    public void MapDepartmentEndpoints(WebApplication app)
    {

    }

    public void MapGetEndpoint(WebApplication app)
    {
        app.MapGet(Endpoint,
            async () => {

            });
    }
}