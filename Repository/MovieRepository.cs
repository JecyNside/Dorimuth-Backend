using Dorimuth_Backend.Data.Context;
using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly CinemaDbContext _dbContext;

        public MovieRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
