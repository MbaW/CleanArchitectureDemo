using CleanMovie.Domain;

namespace CleanMovie.Application
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        Movie CreateMovie(Movie movie);

    }
}
