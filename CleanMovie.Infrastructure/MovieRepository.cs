using CleanMovie.Application;
using CleanMovie.Domain;
using CleanMovie.Persistence;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _movieContext;

        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieContext.Movies.ToList();
        }
    }
}
