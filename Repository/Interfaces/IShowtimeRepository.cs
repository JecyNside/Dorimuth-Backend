using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;

namespace Dorimuth_Backend.Repository.Interfaces
{
    public interface IShowtimeRepository : IBaseRepository<Showtime>
    {
        Task<IEnumerable<ShowtimeDto>> GetByMovieIdAsync(int movieId);
    }
}
