using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RyanJagdfeld.Module.GitHubCard.Models;

namespace RyanJagdfeld.Module.GitHubCard.Services
{
    public class GitHubUserService
    {
        private readonly HttpClient _httpClient;

        public GitHubUserService(HttpClient httpClient, string githubToken)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubCardApp");
            if (!string.IsNullOrEmpty(githubToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", githubToken);
            }
        }

        public async Task<GitHubUser> GetGitHubUserAsync(string username)
        {
            var url = $"https://api.github.com/users/{username}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GitHubUser>();
            }
            else
            {
                // Handle different status codes as needed
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Handle 404 Not Found
                    throw new HttpRequestException($"User '{username}' not found.");
                }
                else
                {
                    // Handle other errors
                    throw new HttpRequestException($"Request to GitHub API failed with status code {response.StatusCode}.");
                }
            }
        }
    }
}
