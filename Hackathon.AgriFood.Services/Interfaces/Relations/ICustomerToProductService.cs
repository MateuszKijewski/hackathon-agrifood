using Hackathon.AgriFood.Models.Dtos.Relations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces.Relations
{
    public interface ICustomerToProductService
    {
        Task AddCustomerToProduct(CustomerToProductDto customerToProductDto);

        Task AddManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos);

        Task<CustomerToProductDto> GetCustomerToProduct(Guid firstGuid, Guid secondId);

        Task<IEnumerable<CustomerToProductDto>> GetCustomerToProductsByFirstId(Guid firstId);

        Task<IEnumerable<CustomerToProductDto>> GetCustomerToProductsBySecondId(Guid secondId);

        Task<IEnumerable<CustomerToProductDto>> GetAllCustomerToProducts();

        Task UpdateCustomerToProduct(CustomerToProductDto customerToProductDto);

        Task UpdateManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos);

        Task DeleteCustomerToProduct(CustomerToProductDto customerToProductDto);

        Task DeleteManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos);
    }
}
