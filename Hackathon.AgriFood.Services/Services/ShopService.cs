using Hackathon.AgriFood.Models.Converters.Interfaces;
using Hackathon.AgriFood.Models.Dtos;
using Hackathon.AgriFood.Models.Models;
using Hackathon.AgriFood.Repositories.Providers;
using Hackathon.AgriFood.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Services
{
    public class ShopService : IShopService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public ShopService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddShop(ShopDto shopDto)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shop = _entityConverter.GetModelFromDto(shopDto);

            await shopRepository.Add(shop);
        }

        public async Task AddManyShops(IEnumerable<ShopDto> shopDtos)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shops = shopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopRepository.AddRange(shops);
        }

        public async Task DeleteShop(ShopDto shopDto)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shop = _entityConverter.GetModelFromDto(shopDto);

            await shopRepository.Delete(shop);
        }

        public async Task DeleteManyShops(IEnumerable<ShopDto> shopDtos)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shops = shopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopRepository.DeleteRange(shops);
        }

        public async Task<IEnumerable<ShopDto>> GetAllShops()
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shops = await shopRepository.GetAll();

            return shops.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<ShopDto> GetShop(Guid id)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shop = await shopRepository.Get(id);

            return _entityConverter.GetDtoFromModel(shop);
        }

        public async Task UpdateShop(ShopDto shopDto)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shop = _entityConverter.GetModelFromDto(shopDto);

            await shopRepository.Update(shop);
        }

        public async Task UpdateManyShops(IEnumerable<ShopDto> shopDtos)
        {
            var shopRepository = _repositoryProvider.GetRepository<Shop>();
            var shops = shopDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopRepository.UpdateRange(shops);
        }
    }
}
