using Dorimuth_Backend.DTO_s;
using Dorimuth_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dorimuth_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredMovies([FromQuery] MovieFilterDto filter)
        {
            var movies = await _movieService.GetFilteredMoviesAsync(filter);
            return Ok(movies);
        }
    }
}
