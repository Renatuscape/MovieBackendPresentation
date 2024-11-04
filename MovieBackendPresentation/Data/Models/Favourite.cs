namespace MovieBackendPresentation.Data.Models;

public class Favourite {
	public int Id { get; set; }
	public int UserId { get; set; }
	public int MovieId { get; set; }
	public User User { get; set; }
	public Movie Movie { get; set; }
}