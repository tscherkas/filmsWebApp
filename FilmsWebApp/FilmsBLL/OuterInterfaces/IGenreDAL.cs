using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL.OuterInterfaces
{
    public interface IGenreDAL
    {
        IQueryable<Genre> getGenreIQueryable(string nameTemplate="");
        Genre getGenre(int ID);
        Genre createOrUpdateGenre(Genre genre);
        void deleteGenre(Genre genre);
    }
}
