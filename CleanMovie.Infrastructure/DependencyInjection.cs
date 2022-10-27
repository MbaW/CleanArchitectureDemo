using CleanMovie.Application;
using CleanMovie.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMovie.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MovieDBConnection"),
                b => b.MigrationsAssembly(typeof(MovieContext).Assembly.FullName)), ServiceLifetime.Singleton);

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            return services;
        }
    }
}
