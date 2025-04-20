using Candidates.Core.Interfaces.IRepositories;
using Candidates.Core.Interfaces.IServices;
using Candidates.Core.Services;
using Candidates.Infrastructure.Repositories;

namespace Candidates.Api.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection RegisterService(this IServiceCollection services)
    {
        #region Services
        services.AddScoped<ICandidateService, CandidateService>();

        #endregion

        #region Repositories
        services.AddScoped<ICandidateRepository, CandidateRepository>();

        #endregion

        return services;
    }
}
