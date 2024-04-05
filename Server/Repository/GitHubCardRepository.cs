using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard.Repository
{
    public class GitHubCardRepository : IGitHubCardRepository, ITransientService
    {
        private readonly IDbContextFactory<GitHubCardContext> _factory;

        public GitHubCardRepository(IDbContextFactory<GitHubCardContext> factory)
        {
            _factory = factory;
        }

        public IEnumerable<Models.GitHubCard> GetGitHubCards(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.GitHubCard.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.GitHubCard GetGitHubCard(int GitHubCardId)
        {
            return GetGitHubCard(GitHubCardId, true);
        }

        public Models.GitHubCard GetGitHubCard(int GitHubCardId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.GitHubCard.Find(GitHubCardId);
            }
            else
            {
                return db.GitHubCard.AsNoTracking().FirstOrDefault(item => item.GitHubCardId == GitHubCardId);
            }
        }

        public Models.GitHubCard AddGitHubCard(Models.GitHubCard GitHubCard)
        {
            using var db = _factory.CreateDbContext();
            db.GitHubCard.Add(GitHubCard);
            db.SaveChanges();
            return GitHubCard;
        }

        public Models.GitHubCard UpdateGitHubCard(Models.GitHubCard GitHubCard)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(GitHubCard).State = EntityState.Modified;
            db.SaveChanges();
            return GitHubCard;
        }

        public void DeleteGitHubCard(int GitHubCardId)
        {
            using var db = _factory.CreateDbContext();
            Models.GitHubCard GitHubCard = db.GitHubCard.Find(GitHubCardId);
            db.GitHubCard.Remove(GitHubCard);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.GitHubCard>> GetGitHubCardsAsync(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return await db.GitHubCard.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.GitHubCard> GetGitHubCardAsync(int GitHubCardId)
        {
            return await GetGitHubCardAsync(GitHubCardId, true);
        }

        public async Task<Models.GitHubCard> GetGitHubCardAsync(int GitHubCardId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.GitHubCard.FindAsync(GitHubCardId);
            }
            else
            {
                return await db.GitHubCard.AsNoTracking().FirstOrDefaultAsync(item => item.GitHubCardId == GitHubCardId);
            }
        }

        public async Task<Models.GitHubCard> AddGitHubCardAsync(Models.GitHubCard GitHubCard)
        {
            using var db = _factory.CreateDbContext();
            db.GitHubCard.Add(GitHubCard);
            await db.SaveChangesAsync();
            return GitHubCard;
        }

        public async Task<Models.GitHubCard> UpdateGitHubCardAsync(Models.GitHubCard GitHubCard)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(GitHubCard).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return GitHubCard;
        }

        public async Task DeleteGitHubCardAsync(int GitHubCardId)
        {
            using var db = _factory.CreateDbContext();
            Models.GitHubCard GitHubCard = db.GitHubCard.Find(GitHubCardId);
            db.GitHubCard.Remove(GitHubCard);
            await db.SaveChangesAsync();
        }
    }
}
