using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RyanJagdfeld.Module.GitHubCard.Models;

namespace RyanJagdfeld.Module.GitHubCard.Services
{
    public class GitHubRepoService
    {
        private readonly HttpClient _httpClient;

        public GitHubRepoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubCardApp");
        }

        public async Task<GitHubRepo> GetGitHubRepoAsync(string username, string repo)
        {
            var url = $"https://api.github.com/repos/{username}/{repo}";
            return await _httpClient.GetFromJsonAsync<GitHubRepo>(url);
        }
    }
}
