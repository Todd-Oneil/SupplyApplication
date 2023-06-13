namespace OrdersApplication.Data;
using MySql.Data;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

public class DbContext : IDbContext
{
    private readonly IConfiguration _configuration;
    public DbContext(IConfiguration config)
    {
        _configuration = config;
    }

    public async Task<IEnumerable<T>> GetDataWithQuery<T, P>(
        string Query,
        P parameters,
        string connectionId = "DefaultConnection")
    {
        using IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(Query, parameters, commandType: CommandType.Text);
    }

    public async Task SaveData<T>(
        string query,
        T parameters,
        string connectionId = "DefaultConnection")
    {
        using IDbConnection connection = new MySqlConnection(_configuration.GetConnectionString(connectionId));

        await connection.ExecuteAsync(query, parameters, transaction: connection.BeginTransaction(), commandType: CommandType.Text);
    }

}
