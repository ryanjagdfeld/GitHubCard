using Microsoft.AspNetCore.Components;
using RyanJagdfeld.Module.GitHubCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanJagdfeld.Module.GitHubCard
{
    public static class TemplateHelper
    {
        public static string TokenizeTemplate(string template, GitHubUser user, string hireableText)
        {
            return template
                .Replace("{AvatarUrl}", user.AvatarUrl)
                .Replace("{Name}", user.Name)
                .Replace("{HireableText}", hireableText)
                .Replace("{PublicRepos}", user.PublicRepos.ToString())
                .Replace("{PublicGists}", user.PublicGists.ToString())
                .Replace("{Followers}", user.Followers.ToString())
                .Replace("{Username}", user.Login)
                .Replace("{HtmlUrl}", user.HtmlUrl)
                .Replace("{Bio}", user.Bio)
                .Replace("{Location}", user.Location);
        }

        public static string DefaultTemplate()
        {
            return @"
            <div class='card p-3'>
                <div class='d-flex align-items-center'>
                    <div class='image'>
                        <img src='{AvatarUrl}' class='rounded' width='155'>
                    </div>
                    <div class='ms-3 w-100'>
                        <h4 class='mb-0 mt-0'>{Name}</h4>
                        <span>{HireableText}</span>
                        <div class='p-2 mt-2 bg-primary d-flex justify-content-between rounded text-white stats'>
                            <div class='d-flex flex-column'>
                                <span class='articles'>Repos</span>
                                <span class='text-center'>{PublicRepos}</span>
                            </div>
                            <div class='d-flex flex-column'>
                                <span class='followers'>Gists</span>
                                <span class='text-center'>{PublicGists}</span>
                            </div>
                            <div class='d-flex flex-column'>
                                <span class='rating'>Followers</span>
                                <span class='text-center'>{Followers}</span>
                            </div>
                        </div>
                        <div class='button mt-2 d-flex flex-row align-items-center'>
                            <a href='{HtmlUrl}' class='btn btn-sm btn-primary w-100 ml-2'>Follow</a>
                        </div>
                    </div>
                </div>
            </div>";
        }
    }
}
