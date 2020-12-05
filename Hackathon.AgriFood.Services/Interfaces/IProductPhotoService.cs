using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IProductPhotoService
    {
        Task AddProductPhoto(ProductPhotoDto productPhotoDto);

        Task AddManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDtos);

        Task<ProductPhotoDto> GetProductPhoto(Guid id);

        Task<IEnumerable<ProductPhotoDto>> GetAllProductPhotos();

        Task UpdateProductPhoto(ProductPhotoDto productPhotoDto);

        Task UpdateManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDtos);

        Task DeleteProductPhoto(ProductPhotoDto productPhotoDto);

        Task DeleteManyProductPhotos(IEnumerable<ProductPhotoDto> productPhotoDtos);
    }
}
