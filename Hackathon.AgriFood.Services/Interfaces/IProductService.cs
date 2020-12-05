using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(ProductDto productDto);

        Task AddManyProducts(IEnumerable<ProductDto> productDtos);

        Task<ProductDto> GetProduct(Guid id);

        Task<IEnumerable<ProductDto>> GetAllProducts();

        Task UpdateProduct(ProductDto productDto);

        Task UpdateManyProducts(IEnumerable<ProductDto> productDtos);

        Task DeleteProduct(ProductDto productDto);

        Task DeleteManyProducts(IEnumerable<ProductDto> productDtos);
    }
}
