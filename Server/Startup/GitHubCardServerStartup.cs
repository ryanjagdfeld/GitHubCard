using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Oqtane.Infrastructure;
using RyanJagdfeld.Module.GitHubCard.Repository;
using RyanJagdfeld.Module.GitHubCard.Services;

namespace RyanJagdfeld.Module.GitHubCard.Startup
{
    public class GitHubCardServerStartup : IServerStartup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // not implemented
        }

        public void ConfigureMvc(IMvcBuilder mvcBuilder)
        {
            // not implemented
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGitHubCardService, ServerGitHubCardService>();
            services.AddDbContextFactory<GitHubCardContext>(opt => { }, ServiceLifetime.Transient);
        }
    }
}
