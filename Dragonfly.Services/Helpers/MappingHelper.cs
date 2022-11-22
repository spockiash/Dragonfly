using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Entities;
using Dragonfly.Models;

namespace Dragonfly.Services.Helpers
{
    public static class MappingHelper
    {
        public static Idea GetIdeaFromModel(IdeaModel model)
        {
            return new Idea()
            {
                Id = model.Id,
                Description = model.Description,
                Done = model.Done,
                Name = model.Name,
                Scrapped = model.Scrapped,
                CreatedDate = model.CreatedDate,
                SetDoneDate = model.SetDoneDate,
                SetScrappedDate = model.SetScrappedDate,
                Tags = TagsFromModel(model.Tags)
            };
        }

        public static List<Tag>? TagsFromModel(ICollection<IdeaTagModel>? tags)
        {
            return tags?.Select(t => new Tag()
            {
                Id = t.Id,
                TagName = t.TagName,
            }).ToList();

        }
    }
}
