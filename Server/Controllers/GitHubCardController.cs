using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using RyanJagdfeld.Module.GitHubCard.Repository;
using Oqtane.Controllers;
using System.Net;

namespace RyanJagdfeld.Module.GitHubCard.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class GitHubCardController : ModuleControllerBase
    {
        private readonly IGitHubCardRepository _GitHubCardRepository;

        public GitHubCardController(IGitHubCardRepository GitHubCardRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _GitHubCardRepository = GitHubCardRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.GitHubCard> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _GitHubCardRepository.GetGitHubCards(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GitHubCard Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.GitHubCard Get(int id)
        {
            Models.GitHubCard GitHubCard = _GitHubCardRepository.GetGitHubCard(id);
            if (GitHubCard != null && IsAuthorizedEntityId(EntityNames.Module, GitHubCard.ModuleId))
            {
                return GitHubCard;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GitHubCard Get Attempt {GitHubCardId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.GitHubCard Post([FromBody] Models.GitHubCard GitHubCard)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, GitHubCard.ModuleId))
            {
                GitHubCard = _GitHubCardRepository.AddGitHubCard(GitHubCard);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "GitHubCard Added {GitHubCard}", GitHubCard);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GitHubCard Post Attempt {GitHubCard}", GitHubCard);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                GitHubCard = null;
            }
            return GitHubCard;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.GitHubCard Put(int id, [FromBody] Models.GitHubCard GitHubCard)
        {
            if (ModelState.IsValid && GitHubCard.GitHubCardId == id && IsAuthorizedEntityId(EntityNames.Module, GitHubCard.ModuleId) && _GitHubCardRepository.GetGitHubCard(GitHubCard.GitHubCardId, false) != null)
            {
                GitHubCard = _GitHubCardRepository.UpdateGitHubCard(GitHubCard);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "GitHubCard Updated {GitHubCard}", GitHubCard);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GitHubCard Put Attempt {GitHubCard}", GitHubCard);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                GitHubCard = null;
            }
            return GitHubCard;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.GitHubCard GitHubCard = _GitHubCardRepository.GetGitHubCard(id);
            if (GitHubCard != null && IsAuthorizedEntityId(EntityNames.Module, GitHubCard.ModuleId))
            {
                _GitHubCardRepository.DeleteGitHubCard(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "GitHubCard Deleted {GitHubCardId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized GitHubCard Delete Attempt {GitHubCardId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
