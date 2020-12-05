using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IFarmerService
    {
        Task AddFarmer(FarmerDto farmerDto);

        Task AddManyFarmers(IEnumerable<FarmerDto> farmerDtos);

        Task<FarmerDto> GetFarmer(Guid id);

        Task<IEnumerable<FarmerDto>> GetAllFarmers();

        Task UpdateFarmer(FarmerDto farmerDto);

        Task UpdateManyFarmers(IEnumerable<FarmerDto> farmerDtos);

        Task DeleteFarmer(FarmerDto farmerDto);

        Task DeleteManyFarmers(IEnumerable<FarmerDto> farmerDtos);
    }
}
