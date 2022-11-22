using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Repos;
using Dragonfly.Models;
using Dragonfly.Services.Helpers;

namespace Dragonfly.Services.Services
{
    public class IdeaService : IIdeaService
    {
        private readonly IIdeaRepository _ideaRepository;

        public IdeaService(IIdeaRepository ideaRepository)
        {
            _ideaRepository = ideaRepository;
        }

        public async Task SaveIdeaToDb(IdeaModel idea)
        {
            var dataToSave = MappingHelper.GetIdeaFromModel(idea);
            await _ideaRepository.SaveIdea(dataToSave);
        }

        public async Task UpdateIdea(IdeaModel idea)
        {
            var dataToUpdate = MappingHelper.GetIdeaFromModel(idea);
            await _ideaRepository.UpdateIdea(dataToUpdate);
        }
    }
}
