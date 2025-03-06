using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Database;
using Movies.Application.Repositories;

namespace Movies.Application.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddSingleton<IMovieRepository, MovieRepository>();
        return service;
    }
    
    public static IServiceCollection AddDatabase(this IServiceCollection service , string connectionString)
    {
        service.AddSingleton<IDBConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        service.AddSingleton<DbInitializer>();
        return service;
    }
    
}