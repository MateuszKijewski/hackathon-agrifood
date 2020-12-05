using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface IFarmerPhotoService
    {
        Task AddFarmerPhoto(FarmerPhotoDto farmerPhotoDto);

        Task AddManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos);

        Task<FarmerPhotoDto> GetFarmerPhoto(Guid id);

        Task<IEnumerable<FarmerPhotoDto>> GetAllFarmerPhotos();

        Task UpdateFarmerPhoto(FarmerPhotoDto farmerPhotoDto);

        Task UpdateManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos);

        Task DeleteFarmerPhoto(FarmerPhotoDto farmerPhotoDto);

        Task DeleteManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos);
    }
}
