using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDto customerDto);
        Task AddManyCustomers(IEnumerable<CustomerDto> customerDtos);
        Task<CustomerDto> GetCustomer(Guid id);
        Task<IEnumerable<CustomerDto>> GetAllCustomers();

        Task UpdateCustomer(CustomerDto customerDto);
        Task UpdateManyCustomers(IEnumerable<CustomerDto> customerDtos);
        Task DeleteCustomer(CustomerDto customerDto);
        Task DeleteManyCustomers(IEnumerable<CustomerDto> customerDtos);

    }
}
