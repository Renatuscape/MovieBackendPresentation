using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBackendPresentation.Data;
using MovieBackendPresentation.Data.Models;

[Route("[Controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly MovieBackendDbContext _database;

    public MovieController(MovieBackendDbContext context)
    {
        _database = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMovie(int id)
    {
        var movie = await _database.Movie.FindAsync(id);
        if (movie == null)
        {
            return NotFound();
        }
        return Ok(movie);
    }

    [HttpGet]
    public async Task<ActionResult> GetMovies()
    {
        var movies = await _database.Movie.ToListAsync();
        return Ok(movies);
    }

    [HttpPost]
    public async Task<ActionResult> CreateDummyData()
    {
        if (_database.Movie != null && _database.Movie.Count() > 0)
        {
            return BadRequest("Movies already exist.");
        }

        var movies = new List<Movie>
        {
            new()
            {
                Title = "Love Actually",
                Genre = "romance, christmas",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/e/eb/Love_Actually_movie.jpg",
            },
            new()
            {
                Title = "The Thing",
                Genre = "horror",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/e/e3/The_Thing_%281982_film%29.png",
            },
            new()
            {
                Title = "The Intouchables",
                Genre = "drama",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/9/93/The_Intouchables.jpg",
            },
            new()
            {
                Title = "Bram Stoker's Dracula",
                Genre = "horror",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/a/a0/Bram_Stoker%27s_Dracula_%281992_film%29.jpg",
            },
            new()
            {
                Title = "Stallion: Spirit of the Cimarron",
                Genre = "animation, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/3/3b/Spirit_Stallion_of_the_Cimarron_poster.jpg",
            },
            new()
            {
                Title = "The Last Unicorn",
                Genre = "animation, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/2/27/The_Last_Unicorn_%281982%29_theatrical_poster.jpg",
            },
            new()
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Genre = "action, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/f/fb/Lord_Rings_Fellowship_Ring.jpg",
            },
            new()
            {
                Title = "The Lord of the Rings: The Two Towers",
                Genre = "action, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/a/a1/Lord_Rings_Two_Towers.jpg",
            },
            new()
            {
                Title = "The Lord of the Rings: The Return of the King",
                Genre = "action, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/4/48/Lord_Rings_Return_King.jpg",
            },
            new()
            {
                Title = "The Lord of the Rings",
                Genre = "animation, action, adventure",
                ImgUrl = "https://upload.wikimedia.org/wikipedia/en/4/40/The_Lord_of_the_Rings_%281978%29.jpg",
            }
        };

        foreach (var movie in movies)
        {
            _database.Movie.Add(movie);
        }
        

        await _database.SaveChangesAsync();
        return Ok();
    }
}