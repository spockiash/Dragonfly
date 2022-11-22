using Dragonfly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Entities;

namespace Dragonfly.Data.Repos
{
    public interface ITagRepository
    {
        Task<IEnumerable<IdeaTagModel>> GetBySearchString(string searchQuery);
        Task<IEnumerable<IdeaTagModel>> GetAllTags();
        Task InsertNewTagList(IEnumerable<Tag> tagsToInsert);
    }
}
