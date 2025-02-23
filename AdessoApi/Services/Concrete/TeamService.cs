using AdessoApi.Data;
using AdessoApi.Data.DTOs.Request.Country;
using AdessoApi.Data.DTOs.Request.Team;
using AdessoApi.Data.DTOs.Response.Group;
using AdessoApi.Data.DTOs.Response.Shared;
using AdessoApi.Data.DTOs.Response.Team;
using AdessoApi.Entities;
using AdessoApi.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdessoApi.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<Team?>> AddTeamAsync(AddTeamDto dto, string username)
        {
            try
            {
                Country? existedCountry = await _unitOfWork.Countries.GetByIdAsync(dto.CountryId);

                if(existedCountry == null)
                    return new ServiceResponse<Team?>().SetObjectNotFound("Country");

                Team team = new Team
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    CountryId = dto.CountryId,
                    CreatedBy = username,
                    UpdatedBy = username,
                    DrawnBy = username
                };

                return await _unitOfWork.Teams.AddAsync(team);


            }
            catch (Exception ex)
            {
                return new ServiceResponse<Team?>().SetErrorAdd("Team", ex.Message);
            }
        }

        public async Task<ServiceResponse<List<GroupAssignmentDto>>> AssignTeamsToGroup(AssignTeamDto dto)
        {
            try
            {
                var groups = new List<Group>();

                // Create groups (A, B, C, etc.)
                for (char groupName = 'A'; groupName < 'A' + dto.NumberOfGroup; groupName++)
                {
                    groups.Add(new Group { Name = groupName.ToString(), CreatedBy = dto.DrawnBy, UpdatedBy = dto.DrawnBy });
                }

                // Add groups to the database
                await _unitOfWork.Groups.AddRangeAsync(groups);

                var allTeams = await _unitOfWork.Teams.Find(x => x.GroupId == null && !x.IsDeleted).ToListAsync();

                int groupIndex = 0;

                while (allTeams.Count > 0)
                {
                    foreach (var group in groups)
                    {
                        // Get all teams that are not yet assigned to a group and do not have the same country as teams already in the group
                        var availableTeams = allTeams.Where(team =>
                                team.GroupId == null &&
                                !group.Teams.Any(t => t.CountryId == team.CountryId))
                            .ToList();

                        // Randomly shuffle the available teams
                        var random = new Random();
                        var randomTeam = availableTeams.OrderBy(x => random.Next()).First();

                        // Assign the team to the current group
                        randomTeam.GroupId = group.Id;
                        group.Teams.Add(randomTeam);

                        // Update the team in the database
                        _unitOfWork.Teams.Update(randomTeam);

                        // Remove the assigned team from the list of unassigned teams
                        allTeams.Remove(randomTeam);

                        // If the group index reaches the last group, reset it
                        groupIndex++;
                        if (groupIndex >= groups.Count)
                        {
                            groupIndex = 0; // Reset the group index to loop through the groups again
                        }
                    }
                }

                // Create response for API: Group assignments
                var groupAssignments = groups.Select(group => new GroupAssignmentDto
                {
                    GroupName = group.Name,
                    Teams = group.Teams.Select(t => new TeamAssignmentDto { Name = t.Name }).ToList()
                }).ToList();

                // Save all changes to the database
                await _unitOfWork.SaveChangesAsync();

                return new ServiceResponse<List<GroupAssignmentDto>>().SetSuccessData(groupAssignments);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<GroupAssignmentDto>>().SetErrorAdd("Group Assignment", ex.Message);
            }
        }
    }
}
