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
    public class FarmerService : IFarmerService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public FarmerService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddFarmer(FarmerDto FarmerDto)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmer = _entityConverter.GetModelFromDto(FarmerDto);

            await farmerRepository.Add(farmer);
        }

        public async Task AddManyFarmers(IEnumerable<FarmerDto> farmerDtos)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmers = farmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerRepository.AddRange(farmers);
        }

        public async Task DeleteFarmer(FarmerDto farmerDto)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmer = _entityConverter.GetModelFromDto(farmerDto);

            await farmerRepository.Delete(farmer);
        }

        public async Task DeleteManyFarmers(IEnumerable<FarmerDto> farmerDtos)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmers = farmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerRepository.DeleteRange(farmers);
        }

        public async Task<IEnumerable<FarmerDto>> GetAllFarmers()
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmers = await farmerRepository.GetAll();

            return farmers.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<FarmerDto> GetFarmer(Guid id)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmer = await farmerRepository.Get(id);

            return _entityConverter.GetDtoFromModel(farmer);
        }

        public async Task UpdateFarmer(FarmerDto farmerDto)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmer = _entityConverter.GetModelFromDto(farmerDto);

            await farmerRepository.Update(farmer);
        }

        public async Task UpdateManyFarmers(IEnumerable<FarmerDto> farmerDtos)
        {
            var farmerRepository = _repositoryProvider.GetRepository<Farmer>();
            var farmers = farmerDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await farmerRepository.UpdateRange(farmers);
        }
    }
}