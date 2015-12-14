using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    public class Film
    {
        public Guid ID { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public IEnumerable<Actor> actors { get; set; }
    }
}
