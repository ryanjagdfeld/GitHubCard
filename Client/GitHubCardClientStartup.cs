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
            services.AddScoped(implementationFactory => new GitHubRepoService(new System.Net.Http.HttpClient(), "<Your GitHub Personal Access Token Here>")); // only use in development or server side code
            services.AddScoped(implementationFactory => new GitHubUserService(new System.Net.Http.HttpClient(), "<Your GitHub Personal Access Token Here>")); // only use in development or server side code
        }
    }
}
