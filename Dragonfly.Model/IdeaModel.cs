using System.ComponentModel.DataAnnotations;

namespace Dragonfly.Models
{
    public class IdeaModel
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
        public bool Scrapped { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? SetDoneDate { get; set; }
        public DateTime? SetScrappedDate { get; set; }
        public ICollection<IdeaTagModel>? Tags { get; set; }
    }
}