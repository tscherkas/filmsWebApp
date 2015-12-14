using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL.OuterInterfaces
{
    public interface IFilmDAL
    {
        IQueryable<Film> getFilmsIQueryable(string nameTemplate="");
        Film getFilm(Guid ID);
        Film createOrUpdateFilm(Film film);
        void deleteFilm(Film film);
    }
}
