using Dragonfly.Data.Repos;
using Dragonfly.Models;
using Dragonfly.Services.Helpers;
using Dragonfly.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dragonfly.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly ITagRepository _tagRepository;

        public TagsController( ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [HttpGet]
        public async Task<IdeaTagModel[]> Get()
        {
            var data = await _tagRepository.GetAllTags();
            return data.ToArray();
        }
    }
}
