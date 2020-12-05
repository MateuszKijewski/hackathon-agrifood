using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Models.Dtos.Relations;
using Hackathon.AgriFood.Models.Models.Relations;
using Hackathon.AgriFood.Repositories.Providers;
using Hackathon.AgriFood.Services.Interfaces.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Services.Relations
{
    public class CustomerToProductService : ICustomerToProductService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public CustomerToProductService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddCustomerToProduct(CustomerToProductDto customerToProductDto)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProduct = _entityConverter.GetModelFromDto(customerToProductDto);

            await customerToProductRepository.Add(customerToProduct);
        }

        public async Task AddManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProducts = customerToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToProductRepository.AddRange(customerToProducts);
        }

        public async Task DeleteCustomerToProduct(CustomerToProductDto customerToProductDto)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var CustomerToProduct = _entityConverter.GetModelFromDto(customerToProductDto);

            await customerToProductRepository.Delete(CustomerToProduct);
        }

        public async Task DeleteManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var CustomerToProducts = customerToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToProductRepository.DeleteRange(CustomerToProducts);
        }

        public async Task<IEnumerable<CustomerToProductDto>> GetAllCustomerToProducts()
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProducts = await customerToProductRepository.GetAll();

            return customerToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<CustomerToProductDto> GetCustomerToProduct(Guid firstId, Guid secondId)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProduct = await customerToProductRepository.Get(firstId, secondId);

            return _entityConverter.GetDtoFromModel(customerToProduct);
        }

        public async Task<IEnumerable<CustomerToProductDto>> GetCustomerToProductsByFirstId(Guid firstId)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProducts = await customerToProductRepository.GetByFirstId(firstId);

            return customerToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<IEnumerable<CustomerToProductDto>> GetCustomerToProductsBySecondId(Guid secondId)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProducts = await customerToProductRepository.GetBySecondId(secondId);

            return customerToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task UpdateCustomerToProduct(CustomerToProductDto customerToProductDto)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var CustomerToProduct = _entityConverter.GetModelFromDto(customerToProductDto);

            await customerToProductRepository.Update(CustomerToProduct);
        }

        public async Task UpdateManyCustomerToProducts(IEnumerable<CustomerToProductDto> customerToProductDtos)
        {
            var customerToProductRepository = _repositoryProvider.GetRelationRepository<CustomerToProduct>();
            var customerToProducts = customerToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToProductRepository.UpdateRange(customerToProducts);
        }
    }
}
