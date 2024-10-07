using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using RyanJagdfeld.Module.GitHubCard.Repository;

namespace RyanJagdfeld.Module.GitHubCard.Manager
{
    public class GitHubCardManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly IGitHubCardRepository _GitHubCardRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public GitHubCardManager(IGitHubCardRepository GitHubCardRepository, IDBContextDependencies DBContextDependencies)
        {
            _GitHubCardRepository = GitHubCardRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new GitHubCardContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new GitHubCardContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.GitHubCard> GitHubCards = _GitHubCardRepository.GetGitHubCards(module.ModuleId).ToList();
            if (GitHubCards != null)
            {
                content = JsonSerializer.Serialize(GitHubCards);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.GitHubCard> GitHubCards = null;
            if (!string.IsNullOrEmpty(content))
            {
                GitHubCards = JsonSerializer.Deserialize<List<Models.GitHubCard>>(content);
            }
            if (GitHubCards != null)
            {
                foreach(var GitHubCard in GitHubCards)
                {
                    _GitHubCardRepository.AddGitHubCard(new Models.GitHubCard { ModuleId = module.ModuleId, Username = GitHubCard.Username, Repo = GitHubCard.Repo });
                }
            }
        }
    }
}
