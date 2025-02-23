namespace AdessoApi.Services.Abstract
{
    public interface IServiceManager
    {
        ICountryService CountryService { get; }
        IGroupService GroupService { get; }
        ITeamService TeamService { get; }
    }
}
