namespace AdessoApi.Data.DTOs.Request.Team
{
    public class AddTeamDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid CountryId { get; set; }
    }
}
