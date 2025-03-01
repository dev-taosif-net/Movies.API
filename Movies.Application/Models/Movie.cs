using System.Text.RegularExpressions;

namespace Movies.Application.Models;

public partial class Movie
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public string Slug => GenerateSlug();
    public required int RealiseYear { get; set; }
    public required IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();

    private string GenerateSlug()
    {
        var title = SlugRegex().Replace(Title.Trim(), "-");

        return $"{title}-{RealiseYear}";
    }

    [GeneratedRegex(@"\s+" ,RegexOptions.NonBacktracking , 5 )]
    private static partial Regex SlugRegex();
}