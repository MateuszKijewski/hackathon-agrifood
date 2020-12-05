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
    public class LocalizationService : ILocalizationService
    {
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly IEntityConverter _entityConverter;

        public LocalizationService(IRepositoryProvider repositoryProvider,
            IEntityConverter entityConverter)
        {
            _repositoryProvider = repositoryProvider;
            _entityConverter = entityConverter;
        }

        public async Task AddLocalization(LocalizationDto localizationDto)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localization = _entityConverter.GetModelFromDto(localizationDto);

            await localizationRepository.Add(localization);
        }

        public async Task AddManyLocalizations(IEnumerable<LocalizationDto> localizationDtos)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localizations = localizationDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await localizationRepository.AddRange(localizations);
        }

        public async Task DeleteLocalization(LocalizationDto localizationDto)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localization = _entityConverter.GetModelFromDto(localizationDto);

            await localizationRepository.Delete(localization);
        }

        public async Task DeleteManyLocalizations(IEnumerable<LocalizationDto> localizationDtos)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localizations = localizationDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await localizationRepository.DeleteRange(localizations);
        }

        public async Task<IEnumerable<LocalizationDto>> GetAllLocalizations()
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localizations = await localizationRepository.GetAll();

            return localizations.Select(x => _entityConverter.GetDtoFromModel(x));
        }

        public async Task<LocalizationDto> GetLocalization(Guid id)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localization = await localizationRepository.Get(id);

            return _entityConverter.GetDtoFromModel(localization);
        }

        public async Task UpdateLocalization(LocalizationDto localizationDto)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localization = _entityConverter.GetModelFromDto(localizationDto);

            await localizationRepository.Update(localization);
        }

        public async Task UpdateManyLocalizations(IEnumerable<LocalizationDto> localizationDtos)
        {
            var localizationRepository = _repositoryProvider.GetRepository<Localization>();
            var localizations = localizationDtos.Select(x => _entityConverter.GetModelFromDto(x));

            await localizationRepository.UpdateRange(localizations);
        }
    }
}
