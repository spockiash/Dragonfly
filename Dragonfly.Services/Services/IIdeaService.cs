using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Entities;
using Dragonfly.Models;

namespace Dragonfly.Services.Services
{
    public interface IIdeaService
    {
        Task SaveIdeaToDb(IdeaModel idea);
        Task UpdateIdea(IdeaModel idea);
    }
}
