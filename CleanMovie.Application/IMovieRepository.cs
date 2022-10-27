using CleanMovie.Domain;

namespace CleanMovie.Application
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        Movie CreateMovie(Movie movie);
    }
}
