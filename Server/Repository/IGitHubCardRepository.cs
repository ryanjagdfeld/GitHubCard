using System.Collections.Generic;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard.Repository
{
    public interface IGitHubCardRepository
    {
        IEnumerable<Models.GitHubCard> GetGitHubCards(int ModuleId);
        Models.GitHubCard GetGitHubCard(int GitHubCardId);
        Models.GitHubCard GetGitHubCard(int GitHubCardId, bool tracking);
        Models.GitHubCard AddGitHubCard(Models.GitHubCard GitHubCard);
        Models.GitHubCard UpdateGitHubCard(Models.GitHubCard GitHubCard);
        void DeleteGitHubCard(int GitHubCardId);

        Task<IEnumerable<Models.GitHubCard>> GetGitHubCardsAsync(int ModuleId);
        Task<Models.GitHubCard> GetGitHubCardAsync(int GitHubCardId);
        Task<Models.GitHubCard> GetGitHubCardAsync(int GitHubCardId, bool tracking);
        Task<Models.GitHubCard> AddGitHubCardAsync(Models.GitHubCard GitHubCard);
        Task<Models.GitHubCard> UpdateGitHubCardAsync(Models.GitHubCard GitHubCard);
        Task DeleteGitHubCardAsync(int GitHubCardId);
    }
}
