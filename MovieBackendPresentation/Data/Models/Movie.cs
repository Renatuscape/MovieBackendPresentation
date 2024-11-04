namespace MovieBackendPresentation.Data.Models;

public class Movie {
	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Genre { get; set; } = string.Empty;
    public string ImgUrl { get; set; } = string.Empty;
    public ICollection<UserMovie>? UserMovie { get; set; }
}