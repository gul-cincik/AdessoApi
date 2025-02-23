using AdessoApi.Data.DTOs.Response.Team;

namespace AdessoApi.Data.DTOs.Response.Group
{
    public class GroupAssignmentDto
    {
        public string GroupName { get; set; }
        public List<TeamAssignmentDto> Teams { get; set; }
    }
}
