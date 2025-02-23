using AdessoApi.Data;
using AdessoApi.Services.Abstract;
using AdessoApi.Services.Concrete;

namespace AdessoApi.Services
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IServiceManager, ServiceManager>()
                .AddScoped<ICountryService, CountryService>()
                .AddScoped<IGroupService, GroupService>()
                .AddScoped<ITeamService, TeamService>();

            return services;
        }
    }
}
