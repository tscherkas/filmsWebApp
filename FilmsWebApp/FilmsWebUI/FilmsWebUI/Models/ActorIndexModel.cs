using FilmsBLL.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmsWebUI.Models
{
    public class ActorIndexModel
    {
        public int page { get; set; }
        public string searchTemplate { get; set; }
        public IPagedList<Actor> actors { get; set; }
    }
}