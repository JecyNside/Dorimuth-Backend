using Dorimuth_Backend.Data.Context;
using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;
using Dorimuth_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dorimuth_Backend.Repository
{
    public class ShowtimeRepository : BaseRepository<Showtime>, IShowtimeRepository
    {
        private readonly CinemaDbContext _dbContext;

        public ShowtimeRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ShowtimeDto>> GetByMovieIdAsync(int movieId)
        {
            return await _dbContext.Showtimes
                .Include(s => s.Room)
                .Where(s => s.MovieId == movieId && s.Active)
                .OrderBy(s => s.StartTime)
                .Select(s => new ShowtimeDto
                {
                    ShowtimeId = s.ShowtimeId,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    AvailableTickets = s.AvailableTickets,
                    Active = s.Active,
                    MovieId = s.MovieId,
                    Room = new RoomDto
                    {
                        RoomId = s.Room.RoomId,
                        Name = s.Room.Name,
                        Capacity = s.Room.Capacity
                    }
                })
                .ToListAsync();
        }
    }
}
