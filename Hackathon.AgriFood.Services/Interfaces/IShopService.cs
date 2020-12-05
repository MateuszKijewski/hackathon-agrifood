using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IShopService
    {
        Task AddShop(ShopDto shopDto);

        Task AddManyShops(IEnumerable<ShopDto> shopDtos);

        Task<ShopDto> GetShop(Guid id);

        Task<IEnumerable<ShopDto>> GetAllShops();

        Task UpdateShop(ShopDto shopDto);

        Task UpdateManyShops(IEnumerable<ShopDto> shopDtos);

        Task DeleteShop(ShopDto shopDto);

        Task DeleteManyShops(IEnumerable<ShopDto> shopDtos);
    }
}
