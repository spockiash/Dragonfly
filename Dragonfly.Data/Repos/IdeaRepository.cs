using Dragonfly.Data.Entities;
using Dragonfly.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Dragonfly.Data.Repos
{
    public class IdeaRepository : IIdeaRepository
    {
        private readonly MainContext _db;

        public IdeaRepository(MainContext db)
        {
            _db = db;
        }

        public async Task UpdateIdea(Idea idea)
        {
            _db.Ideas.Update(idea);
            await Save();
        }

        public async Task<IEnumerable<IdeaModel>> GetAllIdeas()
        {
            return await _db.Ideas.Select(o => new IdeaModel()
            {
                Description = o.Description,
                Done = o.Done,
                Id = o.Id,
                Name = o.Name,
                Scrapped = o.Scrapped,
                CreatedDate = o.CreatedDate,
                SetDoneDate = o.SetDoneDate,
                SetScrappedDate = o.SetScrappedDate
            }).ToListAsync();
        }

        public async Task<IEnumerable<IdeaModel>> GetBySearchString(string searchQuery)
        {
            var normalizedString = searchQuery.ToLowerInvariant();
            var dataFromDb =  await _db.Ideas.ToListAsync();

            return dataFromDb.Where(o => o.Name.Contains(searchQuery, StringComparison.InvariantCultureIgnoreCase)
                || o.Description.Contains(searchQuery, StringComparison.InvariantCultureIgnoreCase))
                .Select(o => new IdeaModel()
                {
                    Description = o.Description,
                    Done = o.Done,
                    Id = o.Id,
                    Name = o.Name,
                    Scrapped = o.Scrapped
                })
                .ToList();
        }

        public async Task<IdeaModel?> GetIdeaById(int id)
        {
            return await _db.Ideas //.Select(o => o)
                .Where(o => o.Id == id)
                .Select(o => new IdeaModel()
                {
                    Description = o.Description,
                    Done = o.Done,
                    Id = o.Id,
                    Name = o.Name,
                    Scrapped = o.Scrapped,
                    CreatedDate = o.CreatedDate,
                    SetDoneDate = o.SetDoneDate,
                    SetScrappedDate = o.SetScrappedDate,
                    Tags = o.Tags.Select(t => new IdeaTagModel()
                    {
                        Id = t.Id,
                        TagName = t.TagName
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task SaveIdea(Idea idea)
        {
            if (idea.Tags != null)
            {
                _db.AttachRange(idea.Tags);
                //var newTags = idea.Tags.Where(n => n.Id == 0);
                //idea.Tags = newTags;
            }
            await _db.AddAsync(idea);
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
