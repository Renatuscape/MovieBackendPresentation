namespace MovieBackendPresentation.Data.Models;

public class Movie {
	public int Id { get; set; }
	public string Title { get; set; }
	public string Genre { get; set; }
	public string ImgUrl { get; set; }
	public ICollection<UserMovie> UserMovie { get; set; }
}