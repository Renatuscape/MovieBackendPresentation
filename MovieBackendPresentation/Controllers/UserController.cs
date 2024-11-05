using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MovieBackendPresentation.Controllers.ControllerModels;
using MovieBackendPresentation.Data;
using MovieBackendPresentation.Data.Models;
using MovieBackendPresentation.Security;

namespace MovieBackendPresentation.Controllers;

[Route("[Controller]")]
[ApiController]
public class UserController : ControllerBase {
	private readonly MovieBackendDbContext _context;

	public UserController(MovieBackendDbContext context) {
		_context = context;
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetUser(int id) {
		var user = await _context.User.FindAsync(id);
		if (user == null) {
			return NotFound();
		}
		return Ok(user);
	}

	[HttpGet]
	public async Task<ActionResult> GetUsers() {
		var user = await _context.User.ToListAsync();
		return Ok(user);
	}

	[HttpPost]
	public async Task<ActionResult> CreateUser(CreateUser user) {
		var salt = PasswordHasher.GenerateSalt();
		
		User newUser = new() {
			Email    = user.Email,
			Password = PasswordHasher.HashPassword(user.Password + salt),
			Salt     = salt,
			Username = user.Username
		};
		_context.User.Add(newUser);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}