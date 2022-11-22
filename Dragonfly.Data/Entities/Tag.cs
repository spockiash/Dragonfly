using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Data.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? TagName { get; set; }
        public IEnumerable<Idea>? Ideas { get; set; }
    }
}
