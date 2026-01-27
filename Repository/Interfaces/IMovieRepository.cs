using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;

namespace Dorimuth_Backend.Repository.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<IEnumerable<MovieDto>> GetFilteredMoviesAsync(MovieFilterDto filter);
    }
}
