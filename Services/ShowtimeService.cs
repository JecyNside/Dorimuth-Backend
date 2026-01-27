using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Services
{
    public class ShowtimeService
    {
        private readonly IShowtimeRepository _showtimeRepository;

        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }

        public async Task<IEnumerable<Showtime>> GetAllShowtimesAsync()
        {
            return await _showtimeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<ShowtimeDto>> GetShowtimesByMovieIdAsync(int movieId)
        {
            return await _showtimeRepository.GetByMovieIdAsync(movieId);
        }

        public async Task<Showtime?> GetShowtimeByIdAsync(int showtimeId)
        {
            return await _showtimeRepository.GetByIdAsync(showtimeId);
        }
    }
}
