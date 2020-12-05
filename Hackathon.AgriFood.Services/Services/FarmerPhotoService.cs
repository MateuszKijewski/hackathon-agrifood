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
    public class FarmerPhotoService : IFarmerPhotoService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public FarmerPhotoService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddFarmerPhoto(FarmerPhotoDto FarmerPhotoDto)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhoto = _entityConverter.GetModelFromDto(FarmerPhotoDto);

            await farmerPhotoRepository.Add(farmerPhoto);
        }

        public async Task AddManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhotos = farmerPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerPhotoRepository.AddRange(farmerPhotos);
        }

        public async Task DeleteFarmerPhoto(FarmerPhotoDto farmerPhotoDto)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhoto = _entityConverter.GetModelFromDto(farmerPhotoDto);

            await farmerPhotoRepository.Delete(farmerPhoto);
        }

        public async Task DeleteManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhotos = farmerPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerPhotoRepository.DeleteRange(farmerPhotos);
        }

        public async Task<IEnumerable<FarmerPhotoDto>> GetAllFarmerPhotos()
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhotos = await farmerPhotoRepository.GetAll();

            return farmerPhotos.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<FarmerPhotoDto> GetFarmerPhoto(Guid id)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhoto = await farmerPhotoRepository.Get(id);

            return _entityConverter.GetDtoFromModel(farmerPhoto);
        }

        public async Task UpdateFarmerPhoto(FarmerPhotoDto farmerPhotoDto)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhoto = _entityConverter.GetModelFromDto(farmerPhotoDto);

            await farmerPhotoRepository.Update(farmerPhoto);
        }

        public async Task UpdateManyFarmerPhotos(IEnumerable<FarmerPhotoDto> farmerPhotoDtos)
        {
            var farmerPhotoRepository = _repositoryProvider.GetRepository<FarmerPhoto>();
            var farmerPhotos = farmerPhotoDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerPhotoRepository.UpdateRange(farmerPhotos);
        }
    }
}
