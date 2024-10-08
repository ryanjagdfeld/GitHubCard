using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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

        public async Task<GitHubRepo> GetGitHubRepoAsync(string username, string repo, string githubToken)
        {
            var url = $"https://api.github.com/repos/{username}/{repo}";
            if (!string.IsNullOrEmpty(githubToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", githubToken);
            }

            var response = await _httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<GitHubRepo>();
            }
            else
            {
                // Handle different status codes as needed
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Handle 404 Not Found
                    throw new HttpRequestException($"Repo '{username}/{repo}' not found.");
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
