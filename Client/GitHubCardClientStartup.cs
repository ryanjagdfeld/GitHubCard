using Microsoft.Extensions.DependencyInjection;
using Oqtane.Services;
using RyanJagdfeld.Module.GitHubCard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard.Startup
{
    public class GitHubCardClientStartup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGitHubCardService, GitHubCardService>();
        }
    }
}
