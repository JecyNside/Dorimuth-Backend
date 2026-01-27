using Dorimuth_Backend.Data.Context;
using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly CinemaDbContext _dbContext;

        public CustomerRepository(CinemaDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
