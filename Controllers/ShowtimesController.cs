using Dorimuth_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dorimuth_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowtimesController : ControllerBase
    {
        private readonly ShowtimeService _showtimeService;

        public ShowtimesController(ShowtimeService showtimeService)
        {
            _showtimeService = showtimeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFunctions()
        {
            var movies = await _showtimeService.GetAllShowtimesAsync();
            return Ok(movies);
        }

        [HttpGet("by-movie/{id}")]
        public async Task<IActionResult> GetFunctionsByMovieId(int id)
        {
            var showtimes = await _showtimeService.GetShowtimesByMovieIdAsync(id);

            if (showtimes == null || !showtimes.Any())
            {
                return NotFound(new { message = "No se encontraron funciones para esta película" });
            }

            return Ok(showtimes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFunctionById(int id)
        {
            var showtime = await _showtimeService.GetShowtimeByIdAsync(id);
            if (showtime == null)
            {
                return NotFound(new { message = "Función no encontrada" });
            }
            return Ok(showtime);
        }
    }
}
