using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dragonfly.Data.Entities;
using Dragonfly.Models;
using Microsoft.EntityFrameworkCore;

namespace Dragonfly.Data.Repos
{
    public class TagRepository : ITagRepository
    {
        private readonly MainContext _db;

        public TagRepository(MainContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<IdeaTagModel>> GetBySearchString(string searchQuery)
        {
            searchQuery = searchQuery.Trim();
            return await _db.Tags.Where(t => t.TagName == searchQuery).Select(t => new IdeaTagModel()
            {
                Id = t.Id,
                TagName  = t.TagName
            }).ToListAsync();
        }

        public async Task<IEnumerable<IdeaTagModel>> GetAllTags()
        {
            return await _db.Tags.Select(t => new IdeaTagModel()
            {
                Id = t.Id,
                TagName = t.TagName
            }).ToListAsync();
        }

        public async Task InsertNewTagList(IEnumerable<Tag> tagsToInsert)
        {
            await _db.Tags.AddRangeAsync(tagsToInsert);
            await Save();
        }

        private async Task Save()
        {
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await Task.FromException(e);
                throw;
            }
        }
    }
}
