using AdessoApi.Data;
using AdessoApi.Services.Abstract;
using static AdessoApi.Services.Concrete.ServiceManager;

namespace AdessoApi.Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICountryService _countryService;
        private readonly IGroupService _groupService;
        private readonly ITeamService _teamService;

        public ServiceManager(ICountryService countryService, IGroupService groupService, ITeamService teamService)
        {
            _countryService = countryService;
            _groupService = groupService;
            _teamService = teamService;
        }

        public ICountryService CountryService => _countryService;
        public IGroupService GroupService => _groupService;
        public ITeamService TeamService => _teamService;

        public void Dispose()
        {

        }
    }
}
