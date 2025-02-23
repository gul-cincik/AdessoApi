using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Request.Group;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;

namespace AdessoApi.Services.Abstract
{
    public interface IGroupService
    {
        public Task<ServiceResponse<Group?>> AddGroupAsync(AddGroupDto dto, string username);
    }
}
