using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RyanJagdfeld.Module.GitHubCard.Models;

namespace RyanJagdfeld.Module.GitHubCard.Services
{
    public class GitHubUserService
    {
        private readonly HttpClient _httpClient;

        public GitHubUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubCardApp");
        }

        public async Task<GitHubUser> GetGitHubUserAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";
            return await _httpClient.GetFromJsonAsync<GitHubUser>(url);
        }
    }
}
