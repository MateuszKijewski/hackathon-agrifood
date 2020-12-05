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
    public class ProductPhotoService : IProductPhotoService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public ProductPhotoService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddProductPhoto(ProductPhotoDto productPhotoDto)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhoto = _entityConverter.GetModelFromDto(productPhotoDto);

            await productPhotoRepository.Add(productPhoto);
        }

        public async Task AddManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDtos)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhotos = productPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await productPhotoRepository.AddRange(productPhotos);
        }

        public async Task DeleteProductPhoto(ProductPhotoDto productPhotoDto)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhoto = _entityConverter.GetModelFromDto(productPhotoDto);

            await productPhotoRepository.Delete(productPhoto);
        }

        public async Task DeleteManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDto)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhotos = productPhotoDto.Select(x => _entityConverter.GetModelFromDto(x));

            await productPhotoRepository.DeleteRange(productPhotos);
        }

        public async Task<IEnumerable<ProductPhotoDto>> GetAllProductPhotos()
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhotos = await productPhotoRepository.GetAll();

            return productPhotos.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<ProductPhotoDto> GetProductPhoto(Guid id)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhoto = await productPhotoRepository.Get(id);

            return _entityConverter.GetDtoFromModel(productPhoto);
        }

        public async Task UpdateProductPhoto(ProductPhotoDto productPhotoDto)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhoto = _entityConverter.GetModelFromDto(productPhotoDto);

            await productPhotoRepository.Update(productPhoto);
        }

        public async Task UpdateManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDtos)
        {
            var productPhotoRepository = _repositoryProvider.GetRepository<ProductPhoto>();
            var productPhotos = productPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await productPhotoRepository.UpdateRange(productPhotos);
        }
    }
}
