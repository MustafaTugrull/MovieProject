namespace MovieProject.Model.Dtos.MovieArtists;

public sealed record MovieArtistResponseDto
{
    public long Id { get; init; }
    public string? ArtistName { get; init; }
    public string? MovieNAme { get; init; }
}