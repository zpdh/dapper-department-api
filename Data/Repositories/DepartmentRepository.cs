using Dapper;
using DapperDepartmentApi.Entities;

namespace DapperDepartmentApi.Data.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllDepartments();
}

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DepartmentRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Department>> GetAllDepartments()
    {
        using var connection = _connectionFactory.CreateConnection();

        return await connection.QueryAsync<Department>(
            "SELECT * FROM Department"
        );
    }
}