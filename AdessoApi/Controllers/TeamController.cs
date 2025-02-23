using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Request.Team;
using AdessoApi.Data.DTOs.Response.Group;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdessoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public TeamController(IServiceManager serviceManager) 
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.Name) || string.IsNullOrEmpty(dto.Code))
                    return BadRequest(new ServiceResponse<Team?>().SetRequestBodyError());

                ServiceResponse<Team?> responseDto = await _serviceManager.TeamService.AddTeamAsync(dto, "test");

                if (responseDto.Succeed)
                    return Ok(responseDto);

                return BadRequest(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("AssignTeamsToGroup")]
        public async Task<IActionResult> AssignTeamsToGroup([FromBody] AssignTeamDto dto)
        {
            try
            {
                if(string.IsNullOrEmpty(dto.DrawnBy))
                    return BadRequest(new ServiceResponse<GroupAssignmentDto>().SetRequestBodyError());

                if(dto.NumberOfGroup != 4 && dto.NumberOfGroup != 8)
                    return BadRequest(new ServiceResponse<GroupAssignmentDto>().SetRequestBodyError("Invalid Team Count. Count must be 4 or 8."));

                ServiceResponse<List<GroupAssignmentDto>> responseDto = await _serviceManager.TeamService.AssignTeamsToGroup(dto);

                if (responseDto.Succeed)
                    return Ok(responseDto);

                return BadRequest(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new ServiceResponse<GroupAssignmentDto>().SetError(ex.Message));
            }
        }
    }
}
