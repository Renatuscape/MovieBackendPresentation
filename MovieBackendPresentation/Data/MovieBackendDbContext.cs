using Microsoft.EntityFrameworkCore;
using MovieBackendPresentation.Data.Models;

namespace MovieBackendPresentation.Data
{
    public class MovieBackendDbContext : DbContext
    {
        public MovieBackendDbContext(DbContextOptions<MovieBackendDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
