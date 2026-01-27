using Dorimuth_Backend.Data.Entities;
using Dorimuth_Backend.Repository.Interfaces;

namespace Dorimuth_Backend.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddCustomerAsync(Customer entity)
        {
            return await _customerRepository.AddAsync(entity);
        }
    }
}
