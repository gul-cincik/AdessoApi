using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Request.Team;
using AdessoApi.Data.DTOs.Response.Group;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;

namespace AdessoApi.Services.Abstract
{
    public interface ITeamService
    {
        public Task<ServiceResponse<Team?>> AddTeamAsync(AddTeamDto dto, string username);
        public Task<ServiceResponse<List<GroupAssignmentDto>>> AssignTeamsToGroup(AssignTeamDto dto);
    }
}
