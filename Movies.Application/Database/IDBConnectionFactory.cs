using Npgsql;
using System.Data;

namespace Movies.Application.Database; 

public interface IDBConnectionFactory
{
    Task<IDbConnection> CreateConnection();
}

public class NpgsqlConnectionFactory (string _connectionString) : IDBConnectionFactory
{
    public async Task<IDbConnection> CreateConnection()
    {
        var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();
        return connection;

    }

}
