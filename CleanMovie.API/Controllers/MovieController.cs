using CleanMovie.Application;
using CleanMovie.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CleanMovie.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ITokenRepository _tokenRepository;

        public MovieController(IMovieService movieService, ITokenRepository tokenRepository)
        {
            _movieService = movieService;
            _tokenRepository = tokenRepository;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _movieService.GetMovies();
            return Ok(movies);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            var Movie = _movieService.CreateMovie(movie);
            return Ok(Movie);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]

        public IActionResult Authenticate(User user)
        {
            var token = _tokenRepository.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
