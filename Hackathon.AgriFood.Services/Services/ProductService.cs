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
    public class ProductService : IProductService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public ProductService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var product = _entityConverter.GetModelFromDto(productDto);

            await productRepository.Add(product);
        }

        public async Task AddManyProducts(IEnumerable<ProductDto> productDtos)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var product = productDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await productRepository.AddRange(product);
        }

        public async Task DeleteProduct(ProductDto productDto)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var product = _entityConverter.GetModelFromDto(productDto);

            await productRepository.Delete(product);
        }

        public async Task DeleteManyProducts(IEnumerable<ProductDto> productDtos)
        {
            var productsepository = _repositoryProvider.GetRepository<Product>();
            var products = productDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await productsepository.DeleteRange(products);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var products = await productRepository.GetAll();

            return products.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var product = await productRepository.Get(id);

            return _entityConverter.GetDtoFromModel(product);
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var product = _entityConverter.GetModelFromDto(productDto);

            await productRepository.Update(product);
        }

        public async Task UpdateManyProducts(IEnumerable<ProductDto> productDtos)
        {
            var productRepository = _repositoryProvider.GetRepository<Product>();
            var products = productDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await productRepository.UpdateRange(products);
        }
    }
}
