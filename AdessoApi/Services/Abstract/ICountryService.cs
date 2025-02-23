using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;

namespace AdessoApi.Services.Abstract
{
    public interface ICountryService
    {
        public Task<ServiceResponse<Country?>> AddCountryAsync(AddCountryDto dto, string username);
    }
}
