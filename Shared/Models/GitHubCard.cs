using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace RyanJagdfeld.Module.GitHubCard.Models
{
    [Table("GitHubCard")]
    public class GitHubCard : IAuditable
    {
        [Key]
        public int GitHubCardId { get; set; }
        public int ModuleId { get; set; }
        public string Username { get; set; }
        public string Repo { get; set; }
        public string Theme { get; set; } = "default";
        public int Height { get; set; } = 200;
        public int Width { get; set; } = 400;
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [NotMapped]
        public GitHubUser GitHubUser { get; set; }
        [NotMapped]
        public GitHubRepo GitHubRepo { get; set; }
    }
}
