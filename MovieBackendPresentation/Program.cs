using Microsoft.EntityFrameworkCore;

using MovieBackendPresentation.Data;

namespace MovieBackendPresentation;

public class Program {
	public static void Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddDbContext<MovieBackendDbContext>(
			c => c.UseSqlite(builder.Configuration.GetConnectionString("LocalConnection")));

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment()) {
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();
		app.UseCors(c => { c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}