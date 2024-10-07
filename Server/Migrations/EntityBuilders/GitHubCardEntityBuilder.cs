using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;
using Oqtane.Models;
using Oqtane.Shared;

namespace RyanJagdfeld.Module.GitHubCard.Migrations.EntityBuilders
{
    public class GitHubCardEntityBuilder : AuditableBaseEntityBuilder<GitHubCardEntityBuilder>
    {
        private const string _entityTableName = "GitHubCard";
        private readonly PrimaryKey<GitHubCardEntityBuilder> _primaryKey = new("PK_GitHubCard", x => x.GitHubCardId);
        private readonly ForeignKey<GitHubCardEntityBuilder> _moduleForeignKey = new("FK_GitHubCard_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public GitHubCardEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override GitHubCardEntityBuilder BuildTable(ColumnsBuilder table)
        {
            GitHubCardId = AddAutoIncrementColumn(table,"GitHubCardId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Username = AddStringColumn(table, "Username", 255);
            Repo = AddStringColumn(table,"Repo", 255, true);
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> GitHubCardId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Username { get; set; }
        public OperationBuilder<AddColumnOperation> Repo { get; set; }

    }
}
