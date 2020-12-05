using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Models.Dtos;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Providers;
using Hackathon.AgriFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public CustomerService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddCustomer(CustomerDto customerDto)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customer = _entityConverter.GetModelFromDto(customerDto);

            await customerRepository.Add(customer);
        }

        public async Task AddManyCustomers(IEnumerable<CustomerDto> customerDtos)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customers = customerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerRepository.AddRange(customers);
        }

        public async Task DeleteCustomer(CustomerDto customerDto)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customer = _entityConverter.GetModelFromDto(customerDto);

            await customerRepository.Delete(customer);
        }

        public async Task DeleteManyCustomers(IEnumerable<CustomerDto> customerDtos)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customers = customerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerRepository.DeleteRange(customers);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customers = await customerRepository.GetAll();

            return customers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<CustomerDto> GetCustomer(Guid id)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customer = await customerRepository.Get(id);

            return _entityConverter.GetDtoFromModel(customer);
        }

        public async Task UpdateCustomer(CustomerDto customerDto)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customer = _entityConverter.GetModelFromDto(customerDto);

            await customerRepository.Update(customer);
        }

        public async Task UpdateManyCustomers(IEnumerable<CustomerDto> customerDtos)
        {
            var customerRepository = _repositoryProvider.GetRepository<Customer>();
            var customers = customerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerRepository.UpdateRange(customers);
        }
    }
}
