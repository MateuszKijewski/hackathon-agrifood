using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IShopPhotoService
    {
        Task AddShopPhoto(ShopPhotoDto shopPhotoDto);

        Task AddManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos);

        Task<ShopPhotoDto> GetShopPhoto(Guid id);

        Task<IEnumerable<ShopPhotoDto>> GetAllShopPhotos();

        Task UpdateShopPhoto(ShopPhotoDto shopPhotoDto);

        Task UpdateManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos);

        Task DeleteShopPhoto(ShopPhotoDto shopPhotoDto);

        Task DeleteManyShopPhotos(IEnumerable<ShopPhotoDto> shopPhotoDtos);
    }
}
