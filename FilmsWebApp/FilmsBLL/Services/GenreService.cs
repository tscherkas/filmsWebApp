using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;
using Ninject;

namespace FilmsBLL.Services
{
    public class GenreService
    {
        [Inject]
        public FilmsBLL.OuterInterfaces.IGenreDAL genresDAL { get; set; }
        
        public GenreService()
        {

        }
        public IQueryable<Genre> getGenresFromDAL(string nameTemplate="")
        {
            return genresDAL.getGenreIQueryable(nameTemplate);
        }
        public Genre getGenreFromDAL(int ID)
        {
            return genresDAL.getGenre(ID);
        }
        public Genre addOrEditGenreInDAL(Genre genre)
        {
            return genresDAL.createOrUpdateGenre(genre);
        }
        public void deleteGenreFromDAL(Genre genre)
        {
            genresDAL.deleteGenre(genre);
        }
    }
}
