using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Data.Entities
{
    public class Idea
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
        public IEnumerable<Tag>? Tags { get; set; }
    }
}
