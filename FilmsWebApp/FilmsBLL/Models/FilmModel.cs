using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    public class FilmModel
    {
        public string name { get; set; }
        public ICollection<GenreModel> genres { get; set; }
        public ICollection<PersonModel> actors { get; set; }
    }
}
