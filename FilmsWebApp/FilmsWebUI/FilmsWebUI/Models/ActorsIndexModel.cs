using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmsWebUI.Models
{
    public class ActorsIndexModel
    {
        public int page { get; set; }
        public string searchTemplate { get; set; }
        public IPagedList<FilmsBLL.Models.Actor> actors { get; set; }
    }
}