using Hackathon.AgriFood.Models.Dtos.Relations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces.Relations
{
    public interface IShopToFarmerService
    {
        Task AddShopToFarmer(ShopToFarmerDto shopToFarmerDto);

        Task AddManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos);

        Task<ShopToFarmerDto> GetShopToFarmer(Guid firstGuid, Guid secondId);

        Task<IEnumerable<ShopToFarmerDto>> GetShopToFarmersByFirstId(Guid firstId);

        Task<IEnumerable<ShopToFarmerDto>> GetShopToFarmersBySecondId(Guid secondId);

        Task<IEnumerable<ShopToFarmerDto>> GetAllShopToFarmers();

        Task UpdateShopToFarmer(ShopToFarmerDto shopToFarmerDto);

        Task UpdateManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos);

        Task DeleteShopToFarmer(ShopToFarmerDto shopToFarmerDto);

        Task DeleteManyShopToFarmers(IEnumerable<ShopToFarmerDto> shopToFarmerDtos);
    }
}