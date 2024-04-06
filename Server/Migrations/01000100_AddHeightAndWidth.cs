using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;
using RyanJagdfeld.Module.GitHubCard.Migrations.EntityBuilders;
using RyanJagdfeld.Module.GitHubCard.Repository;

namespace RyanJagdfeld.Module.GitHubCard.Migrations
{
    [DbContext(typeof(GitHubCardContext))]
    [Migration("RyanJagdfeld.Module.GitHubCard.01.00.01.00")]
    public class AddHeightAndWidth : MultiDatabaseMigration
    {
        public AddHeightAndWidth(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new GitHubCardEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.AddIntegerColumn("Height", false, 200);
            entityBuilder.AddIntegerColumn("Width", false, 400);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // not implemented

        }
    }
}
