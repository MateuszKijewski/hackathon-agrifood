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
    public class TagToProductService : ITagToProductService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public TagToProductService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddTagToProduct(TagToProductDto tagToProductDto)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProduct = _entityConverter.GetModelFromDto(tagToProductDto);

            await tagToProductRepository.Add(tagToProduct);
        }

        public async Task AddManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = tagToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await tagToProductRepository.AddRange(tagToProducts);
        }

        public async Task DeleteTagToProduct(TagToProductDto tagToProductDto)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProduct = _entityConverter.GetModelFromDto(tagToProductDto);

            await tagToProductRepository.Delete(tagToProduct);
        }

        public async Task DeleteManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = tagToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await tagToProductRepository.DeleteRange(tagToProducts);
        }

        public async Task<IEnumerable<TagToProductDto>> GetAllTagToProducts()
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = await tagToProductRepository.GetAll();

            return tagToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<TagToProductDto> GetTagToProduct(Guid firstId, Guid secondId)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProduct = await tagToProductRepository.Get(firstId, secondId);

            return _entityConverter.GetDtoFromModel(tagToProduct);
        }

        public async Task<IEnumerable<TagToProductDto>> GetTagToProductsByFirstId(Guid firstId)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = await tagToProductRepository.GetByFirstId(firstId);

            return tagToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<IEnumerable<TagToProductDto>> GetTagToProductsBySecondId(Guid secondId)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = await tagToProductRepository.GetBySecondId(secondId);

            return tagToProducts.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task UpdateTagToProduct(TagToProductDto tagToProductDto)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProduct = _entityConverter.GetModelFromDto(tagToProductDto);

            await tagToProductRepository.Update(tagToProduct);
        }

        public async Task UpdateManyTagToProducts(IEnumerable<TagToProductDto> tagToProductDtos)
        {
            var tagToProductRepository = _repositoryProvider.GetRelationRepository<TagToProduct>();
            var tagToProducts = tagToProductDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await tagToProductRepository.UpdateRange(tagToProducts);
        }
    }
}
