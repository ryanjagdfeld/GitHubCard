using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using RyanJagdfeld.Module.GitHubCard.Services;

namespace RyanJagdfeld.Module.GitHubCard.Startup
{
    public class GitHubCardClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGitHubCardService, GitHubCardService>();
            services.AddScoped(implementationFactory => new GitHubService(new System.Net.Http.HttpClient()));
        }
    }
}
