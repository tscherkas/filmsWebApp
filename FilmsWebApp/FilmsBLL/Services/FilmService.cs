using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL.Services
{
    public class FilmService 
    {
        [Inject]
        public OuterInterfaces.IFilmDAL filmsDAL { get; set; }

        public Film createOrUpdateFilm(Film film)
        {
            return filmsDAL.createOrUpdateFilm(film);
        }

        public void deleteFilm(Film film)
        {
            filmsDAL.deleteFilm(film);
        }

        public Film getFilm(Guid ID)
        {
            return filmsDAL.getFilm(ID);
        }

        public IQueryable<Film> getFilmsIQueryable(string nameTemplate = "")
        {
            return filmsDAL.getFilmsIQueryable(nameTemplate);
        }
    }
}
