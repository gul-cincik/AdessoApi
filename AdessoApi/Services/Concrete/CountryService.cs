using AdessoApi.Data;
using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;

namespace AdessoApi.Services.Concrete
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Country?>> AddCountryAsync(AddCountryDto dto, string username)
        {
            try
            {   
                Country country = new Country
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    CreatedBy = username,
                    UpdatedBy = username
                };

                return await _unitOfWork.Countries.AddAsync(country);


            }
            catch (Exception ex)
            {
                return new ServiceResponse<Country?>().SetErrorAdd("Country", ex.Message);
            }
        }
    }
}
