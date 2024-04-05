using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace RyanJagdfeld.Module.GitHubCard.Repository
{
    public class GitHubCardContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.GitHubCard> GitHubCard { get; set; }

        public GitHubCardContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.GitHubCard>().ToTable(ActiveDatabase.RewriteName("GitHubCard"));
        }
    }
}
