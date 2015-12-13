using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    public class Person
    {
        public Guid ID { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public IEnumerable<Film> films { get; set; }
    }
}
