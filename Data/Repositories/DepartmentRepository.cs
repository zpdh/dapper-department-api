using Dapper;
using DapperDepartmentApi.DTOs;
using DapperDepartmentApi.Entities;

namespace DapperDepartmentApi.Data.Repositories;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department?>> GetAllDepartmentsAsync();
    Task<Department?> GetSingleDepartmentAsync(int id);
    Task InsertIntoDepartmentAsync(DepartmentDto department);
    Task UpdateDepartmentAsync(int id, DepartmentDto department);
    Task DeleteDepartmentAsync(int id);
}

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DepartmentRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Department?>> GetAllDepartmentsAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string query = "SELECT * FROM Department";

        return await connection.QueryAsync<Department>(query);
    }

    public async Task<Department?> GetSingleDepartmentAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string query = "SELECT * FROM Department WHERE Id = @id";
        var parameters = new { id };

        return await connection.QuerySingleAsync<Department>(query, parameters);
    }

    public async Task InsertIntoDepartmentAsync(DepartmentDto department)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string query = "INSERT INTO Department (Name) VALUES (@Name)";

        await connection.ExecuteAsync(query, department);
    }

    public async Task UpdateDepartmentAsync(int id, DepartmentDto department)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string query = "UPDATE Department SET NAME = @Name WHERE Id = @Id";
        var parameters = new { department.Name, Id = id };

        await connection.ExecuteAsync(query, parameters);
    }

    public async Task DeleteDepartmentAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string query = "DELETE FROM Department WHERE Id = @Id";
        var parameters = new { Id = id };

        await connection.ExecuteAsync(query, parameters);
    }
}