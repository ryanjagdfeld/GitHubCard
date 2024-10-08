using Oqtane.Models;
using Oqtane.Modules;

namespace RyanJagdfeld.Module.GitHubCard
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "GitHubCard",
            Description = "A module for displaying GitHub cards by lepture.",
            Version = "1.0.1",
            ServerManagerType = "RyanJagdfeld.Module.GitHubCard.Manager.GitHubCardManager, RyanJagdfeld.Module.GitHubCard.Server.Oqtane",
            ReleaseVersions = "1.0.0,1.0.1",
            Dependencies = "RyanJagdfeld.Module.GitHubCard.Shared.Oqtane",
            PackageName = "RyanJagdfeld.Module.GitHubCard" 
        };
    }
}
