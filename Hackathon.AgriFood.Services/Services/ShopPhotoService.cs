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
    public class ShopPhotoService : IShopPhotoService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public ShopPhotoService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddShopPhoto(ShopPhotoDto shopPhotoDto)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhoto = _entityConverter.GetModelFromDto(shopPhotoDto);

            await shopPhotoRepository.Add(shopPhoto);
        }

        public async Task AddManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhotos = shopPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopPhotoRepository.AddRange(shopPhotos);
        }

        public async Task DeleteShopPhoto(ShopPhotoDto shopPhotoDto)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhoto = _entityConverter.GetModelFromDto(shopPhotoDto);

            await shopPhotoRepository.Delete(shopPhoto);
        }

        public async Task DeleteManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhotos = shopPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopPhotoRepository.DeleteRange(shopPhotos);
        }

        public async Task<IEnumerable<ShopPhotoDto>> GetAllShopPhotos()
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhotos = await shopPhotoRepository.GetAll();

            return shopPhotos.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<ShopPhotoDto> GetShopPhoto(Guid id)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhoto = await shopPhotoRepository.Get(id);

            return _entityConverter.GetDtoFromModel(shopPhoto);
        }

        public async Task UpdateShopPhoto(ShopPhotoDto shopPhotoDto)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhoto = _entityConverter.GetModelFromDto(shopPhotoDto);

            await shopPhotoRepository.Update(shopPhoto);
        }

        public async Task UpdateManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos)
        {
            var shopPhotoRepository = _repositoryProvider.GetRepository<ShopPhoto>();
            var shopPhotos = shopPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await shopPhotoRepository.UpdateRange(shopPhotos);
        }
    }
}
