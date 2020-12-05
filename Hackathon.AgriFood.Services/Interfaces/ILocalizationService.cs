using Hackathon.AgriFood.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.Services.Interfaces
{
    public interface ILocalizationService
    {
        Task AddLocalization(LocalizationDto localizationDto);

        Task AddManyLocalizations(IEnumerable<LocalizationDto> localizationDtos);

        Task<LocalizationDto> GetLocalization(Guid id);

        Task<IEnumerable<LocalizationDto>> GetAllLocalizations();

        Task UpdateLocalization(LocalizationDto localizationDto);

        Task UpdateManyLocalizations(IEnumerable<LocalizationDto> localizationDtos);

        Task DeleteLocalization(LocalizationDto localizationDto);

        Task DeleteManyLocalizations(IEnumerable<LocalizationDto> localizationDtos);
    }
}