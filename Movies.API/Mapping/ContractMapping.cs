using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.API.Mapping;

public static class ContractMapping
{
    public static Movie ToMovie(this CreateMovieRequest request)
    {
        return new Movie()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            RealiseYear = request.RealiseYear,
            Genres = request.Genres.ToList()
        };
    }
    
    public static Movie ToMovie(this UpdateMovieRequest request , Guid id)
    {
        return new Movie()
        {
            Id = id,
            Title = request.Title,
            RealiseYear = request.RealiseYear,
            Genres = request.Genres.ToList()
        };
    }

    public static MovieResponse ToMovieResponse(this Movie request)
    {
        return new MovieResponse
        {
            Title = request.Title,
            RealiseYear = request.RealiseYear,
            Genres = request.Genres.ToList()
        };

    }
    
    public static MoviesResponse ToMovieResponse(this IEnumerable<Movie> request)
    {
        return new MoviesResponse
        {
           MovieList = request.Select(x=>x.ToMovieResponse())
        };
    }
    
}