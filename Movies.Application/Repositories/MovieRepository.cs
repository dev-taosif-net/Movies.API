using Movies.Application.Models;

namespace Movies.Application.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly List<Movie> _movie = [];
    
    public Task<bool> CreateAsync(Movie movie)
    {
        _movie.Add(movie);
        return Task.FromResult(true);
    }

    public Task<Movie?> GetByIdAsync(Guid id)
    {
        var data = _movie.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(data);
    }

    public Task<Movie?> GetBySlugAsync(string slugId)
    {
        var data = _movie.FirstOrDefault(x => x.Slug == slugId);
        return Task.FromResult(data);
    }

    public Task<IEnumerable<Movie>> GetAllAsync()
    {
        return Task.FromResult(_movie.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Movie movie)
    {
        var index = _movie.FindIndex(x => x.Id == movie.Id);
        if (index == -1)
        {
            return Task.FromResult(false);
        }

        _movie[index] = movie;
        return Task.FromResult(true);

    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _movie.RemoveAll(x => x.Id == id);
        var movieRemoved = removedCount > 0;
        return Task.FromResult(movieRemoved);
    }
}