using Hackathon.AgriFood.Models.Dtos.Relations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces.Relations
{
    public interface ICustomerToFarmerService
    {
        Task AddCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto);

        Task AddManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos);

        Task<CustomerToFarmerDto> GetCustomerToFarmer(Guid firstGuid, Guid secondId);

        Task<IEnumerable<CustomerToFarmerDto>> GetCustomerToFarmersByFirstId(Guid firstId);

        Task<IEnumerable<CustomerToFarmerDto>> GetCustomerToFarmersBySecondId(Guid secondId);

        Task<IEnumerable<CustomerToFarmerDto>> GetAllCustomerToFarmers();

        Task UpdateCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto);

        Task UpdateManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos);

        Task DeleteCustomerToFarmer(CustomerToFarmerDto customerToFarmerDto);

        Task DeleteManyCustomerToFarmers(IEnumerable<CustomerToFarmerDto> customerToFarmerDtos);
    }
}
