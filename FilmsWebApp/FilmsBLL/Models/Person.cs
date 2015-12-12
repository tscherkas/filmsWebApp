using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    class Person
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<Film> films { get; set; }
    }
}
