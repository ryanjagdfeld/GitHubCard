using System.Collections.Generic;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard.Services
{
    public interface IGitHubCardService 
    {
        Task<List<Models.GitHubCard>> GetGitHubCardsAsync(int ModuleId);

        Task<Models.GitHubCard> GetGitHubCardAsync(int GitHubCardId, int ModuleId);

        Task<Models.GitHubCard> AddGitHubCardAsync(Models.GitHubCard GitHubCard);

        Task<Models.GitHubCard> UpdateGitHubCardAsync(Models.GitHubCard GitHubCard);

        Task DeleteGitHubCardAsync(int GitHubCardId, int ModuleId);
    }
}
