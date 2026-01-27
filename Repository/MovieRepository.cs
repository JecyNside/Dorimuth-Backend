using Dorimuth_Backend.Data.Context;
using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;
using Dorimuth_Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dorimuth_Backend.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly CinemaDbContext _dbContext;

        public MovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MovieDto>> GetFilteredMoviesAsync(MovieFilterDto filter)
        {
            var query = _dbContext.Movies
                .Include(m => m.Showtimes)
                .ThenInclude(s => s.Room)
                .Where(m => m.Active)
                .AsQueryable();

            // Filtro por titulo
            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                query = query.Where(m => m.Title.Contains(filter.Title));
            }

            // Filtro por genero
            if (!string.IsNullOrWhiteSpace(filter.Genre))
            {
                query = query.Where(m => m.Genre == filter.Genre);
            }

            // Filtros de showtimes
            if (filter.RoomId.HasValue || filter.StartTime.HasValue)
            {
                query = query.Where(m => m.Showtimes.Any(s =>
                    s.Active &&
                    (!filter.RoomId.HasValue || s.RoomId == filter.RoomId.Value) &&
                    (!filter.StartTime.HasValue || s.StartTime.TimeOfDay == filter.StartTime.Value)
                ));
            }

            return await query
                .Select(m => new MovieDto
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Synopsis = m.Synopsis,
                    Genre = m.Genre,
                    DurationMinutes = m.DurationMinutes,
                    ImageUrl = m.ImageUrl,
                    Active = m.Active
                })
                .ToListAsync();
        }
    }
}
