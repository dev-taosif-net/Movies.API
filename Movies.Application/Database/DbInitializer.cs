using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Database;

public class DbInitializer (IDBConnectionFactory _connectionFactory)
{
    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnection();
        await connection.ExecuteAsync($"""
        CREATE TABLE IF NOT EXISTS movies
        (
            Id UUID PRIMARY KEY,
            Title TEXT NOT NULL,
            Slug TEXT NOT NULL,
            RealiseYear INT NOT NULL
        )
        """);


    }
}
