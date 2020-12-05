using Hackathon.AgriFood.Models.Dtos.Relations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces.Relations
{
    public interface ICustomerToShopService
    {
        Task AddCustomerToShop(CustomerToShopDto customerToShopDto);

        Task AddManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos);

        Task<CustomerToShopDto> GetCustomerToShop(Guid firstGuid, Guid secondId);

        Task<IEnumerable<CustomerToShopDto>> GetCustomerToShopsByFirstId(Guid firstId);

        Task<IEnumerable<CustomerToShopDto>> GetCustomerToShopsBySecondId(Guid secondId);

        Task<IEnumerable<CustomerToShopDto>> GetAllCustomerToShops();

        Task UpdateCustomerToShop(CustomerToShopDto customerToShopDto);

        Task UpdateManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos);

        Task DeleteCustomerToShop(CustomerToShopDto customerToShopDto);

        Task DeleteManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos);
    }
}
