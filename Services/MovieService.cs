using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.DTO_s;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MovieDto>> GetFilteredMoviesAsync(MovieFilterDto filter)
        {
            return await _movieRepository.GetFilteredMoviesAsync(filter);
        }
    }
}
