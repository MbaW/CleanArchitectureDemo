using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Persistence
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}
