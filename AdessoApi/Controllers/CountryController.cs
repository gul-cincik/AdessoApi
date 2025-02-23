using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CountryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Code))
                    return BadRequest(new ServiceResponse<Team?>().SetRequestBodyError());

                ServiceResponse<Country?> responseDto = await _serviceManager.CountryService.AddCountryAsync(dto, "test");

                if (responseDto.Succeed)
                    return Ok(responseDto);

                return BadRequest(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
