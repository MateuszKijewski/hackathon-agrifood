using Hackathon.AgriFood.Models.Dtos;
using Hackathon.AgriFood.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hackathon.AgriFood.WebApi.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly ILocalizationService _localizationService;
        public LocalizationController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        [HttpGet(ApiRoutes.Localization.Main)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var requestedLocalizations = await _localizationService.GetAllLocalizations();

                return Ok(requestedLocalizations);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost(ApiRoutes.Localization.Main)]
        public async Task<IActionResult> Add([FromBody] LocalizationDto localizationDto)
        {
            try
            {
                await _localizationService.AddLocalization(localizationDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
