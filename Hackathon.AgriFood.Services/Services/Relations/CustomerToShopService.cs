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
    public class CustomerToShopService : ICustomerToShopService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public CustomerToShopService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddCustomerToShop(CustomerToShopDto customerToShopDto)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShop = _entityConverter.GetModelFromDto(customerToShopDto);

            await customerToShopRepository.Add(customerToShop);
        }

        public async Task AddManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = customerToShopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToShopRepository.AddRange(customerToShops);
        }

        public async Task DeleteCustomerToShop(CustomerToShopDto customerToShopDto)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShop = _entityConverter.GetModelFromDto(customerToShopDto);

            await customerToShopRepository.Delete(customerToShop);
        }

        public async Task DeleteManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = customerToShopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToShopRepository.DeleteRange(customerToShops);
        }

        public async Task<IEnumerable<CustomerToShopDto>> GetAllCustomerToShops()
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = await customerToShopRepository.GetAll();

            return customerToShops.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<CustomerToShopDto> GetCustomerToShop(Guid firstId, Guid secondId)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShop = await customerToShopRepository.Get(firstId, secondId);

            return _entityConverter.GetDtoFromModel(customerToShop);
        }

        public async Task<IEnumerable<CustomerToShopDto>> GetCustomerToShopsByFirstId(Guid firstId)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = await customerToShopRepository.GetByFirstId(firstId);

            return customerToShops.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<IEnumerable<CustomerToShopDto>> GetCustomerToShopsBySecondId(Guid secondId)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = await customerToShopRepository.GetBySecondId(secondId);

            return customerToShops.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task UpdateCustomerToShop(CustomerToShopDto customerToShopDto)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShop = _entityConverter.GetModelFromDto(customerToShopDto);

            await customerToShopRepository.Update(customerToShop);
        }

        public async Task UpdateManyCustomerToShops(IEnumerable<CustomerToShopDto> customerToShopDtos)
        {
            var customerToShopRepository = _repositoryProvider.GetRelationRepository<CustomerToShop>();
            var customerToShops = customerToShopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await customerToShopRepository.UpdateRange(customerToShops);
        }
    }
}
