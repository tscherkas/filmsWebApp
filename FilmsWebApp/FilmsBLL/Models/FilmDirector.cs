﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsBLL.Models
{
    public class FilmDirector : Person
    {
        public IEnumerable<Film> filmsAsDirector { get; set; }
    }
}
