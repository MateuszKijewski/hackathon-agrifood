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
    public class ShopToFarmerService : IShopToFarmerService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public ShopToFarmerService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddShopToFarmer(ShopToFarmerDto shopToFarmerDto)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmer = _entityConverter.GetModelFromDto(shopToFarmerDto);

            await shopToFarmerRepository.Add(shopToFarmer);
        }

        public async Task AddManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = shopToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopToFarmerRepository.AddRange(shopToFarmers);
        }

        public async Task DeleteShopToFarmer(ShopToFarmerDto shopToFarmerDto)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmer = _entityConverter.GetModelFromDto(shopToFarmerDto);

            await shopToFarmerRepository.Delete(shopToFarmer);
        }

        public async Task DeleteManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = shopToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopToFarmerRepository.DeleteRange(shopToFarmers);
        }

        public async Task<IEnumerable<ShopToFarmerDto>> GetAllShopToFarmers()
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = await shopToFarmerRepository.GetAll();

            return shopToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<ShopToFarmerDto> GetShopToFarmer(Guid firstId, Guid secondId)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmer = await shopToFarmerRepository.Get(firstId, secondId);

            return _entityConverter.GetDtoFromModel(shopToFarmer);
        }

        public async Task<IEnumerable<ShopToFarmerDto>> GetShopToFarmersByFirstId(Guid firstId)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = await shopToFarmerRepository.GetByFirstId(firstId);

            return shopToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<IEnumerable<ShopToFarmerDto>> GetShopToFarmersBySecondId(Guid secondId)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = await shopToFarmerRepository.GetBySecondId(secondId);

            return shopToFarmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task UpdateShopToFarmer(ShopToFarmerDto shopToFarmerDto)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmer = _entityConverter.GetModelFromDto(shopToFarmerDto);

            await shopToFarmerRepository.Update(shopToFarmer);
        }

        public async Task UpdateManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos)
        {
            var shopToFarmerRepository = _repositoryProvider.GetRelationRepository<ShopToFarmer>();
            var shopToFarmers = shopToFarmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopToFarmerRepository.UpdateRange(shopToFarmers);
        }
    }
}
