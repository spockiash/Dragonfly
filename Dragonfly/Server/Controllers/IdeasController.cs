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
    public class IdeasController : ControllerBase
    {
        private readonly IIdeaService _ideaService;
        private readonly IIdeaRepository _ideaRepository;

        public IdeasController(IIdeaService ideaService, IIdeaRepository ideaRepository)
        {
            _ideaService = ideaService;
            _ideaRepository = ideaRepository;
        }
        //Sample routing
        //[HttpGet]
        //[Route("[controller]/getrandomint")]
        //public async Task<int> GetMeNumber()
        //{
        //    Random r = new Random();
        //    return r.Next(0, 100);
        //}

        [HttpPut]
        public async Task Put([FromBody] IdeaModel idea)
        {
            await _ideaService.SaveIdeaToDb(idea);
        }

        [HttpPut]

        [Route("PutUpdate")]
        public async Task PutUpdate([FromBody] IdeaModel idea)
        {
            await _ideaService.UpdateIdea(idea);
        }

        [HttpGet]
        public async Task<IdeaModel[]> Get()
        {
            var data = await _ideaRepository.GetAllIdeas();

            return data.ToArray();
        }

        [HttpGet("{id:int}")]
        public async Task<IdeaModel?> Get(int id)
        {
            var data = await _ideaRepository.GetIdeaById(id);

            return data;
        }
        [HttpGet("{searchQuery}")]
        public async Task<IEnumerable<IdeaModel>> Get(string searchQuery)
        {
            var data = await _ideaRepository.GetBySearchString(searchQuery);
            foreach (var idea in data)
            {
                idea.Description = SearchTermTextHelper.GetSearchSnippet(idea.Description, searchQuery);
            }
            return data;
        }
    }
}
