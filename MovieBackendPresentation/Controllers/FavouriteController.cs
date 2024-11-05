using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MovieBackendPresentation.Controllers.ControllerModels;
using MovieBackendPresentation.Data;
using MovieBackendPresentation.Data.Models;

namespace MovieBackendPresentation.Controllers;

[Route("[Controller]")]
[ApiController]
public class FavouriteController : ControllerBase {
	private readonly MovieBackendDbContext _context;

	public FavouriteController(MovieBackendDbContext context) {
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult> GetFavourites() {
		var favourites = await _context.Favourites.ToListAsync();
		return Ok(favourites);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult> GetFavourite(int id) {
		var favourite = await _context.Favourites.FindAsync(id);
		return Ok(favourite);
	}

	[HttpGet("{id:int}/user")]
	public async Task<ActionResult> GetUserFavourite(int id) {
		var favourite = await _context.Favourites.Where(c => c.UserId == id).ToListAsync();
		return Ok(favourite);
	}

	[HttpPost]
	public async Task<ActionResult> CreateFavourite(CreateFavourite favourite) {
		Favourite newFavourite = new() {
			MovieId = favourite.MovieId,
			UserId  = favourite.UserId
		};

		await _context.AddAsync(newFavourite);
		await _context.SaveChangesAsync();
		
		return Ok();
	}
}