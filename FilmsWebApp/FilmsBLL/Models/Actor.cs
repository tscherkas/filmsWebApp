﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    class Actor : Person
    {
        public IEnumerable<Film> filmsAsActor { get; set; }
    }
}
