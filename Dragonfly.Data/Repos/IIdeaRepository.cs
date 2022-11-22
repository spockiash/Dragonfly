using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Entities;
using Dragonfly.Models;

namespace Dragonfly.Data.Repos
{
    public interface IIdeaRepository
    {
        Task SaveIdea(Idea idea);
        Task UpdateIdea(Idea idea);
        Task<IEnumerable<IdeaModel>> GetAllIdeas();
        Task<IEnumerable<IdeaModel>> GetBySearchString(string searchQuery);
        Task<IdeaModel?> GetIdeaById(int id);


    }
}
