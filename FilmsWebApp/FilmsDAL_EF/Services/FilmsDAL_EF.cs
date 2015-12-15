using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;
using System.Data.Entity;

namespace FilmsDAL_EF.Services
{
    public class FilmsDAL_EF : FilmsBLL.OuterInterfaces.IFilmDAL
    {
        public FilmModel  model { get; set; }
        public FilmsDAL_EF()
        {
            model = new FilmModel();
        }


        /*
        var ret = (from p in model.Person select p);
            ret = ret.Where(p => p.EnglishName.Contains(nameTemplate)||p.RussianName.Contains(nameTemplate)).OrderByDescending(p => p.PersonId);    
            return ret.Select(
                p => new Actor { ID = p.PersonId, name = p.EnglishName + " (" + p.RussianName + ")" }
                ); 
        */

        public IQueryable<Film> getFilmsIQueryable(string nameTemplate = "")
        {
            var ret = (from m in model.Movie select m);
            if(nameTemplate.Length>0)
                ret = ret.Where(m => m.OriginalTitle.Contains(nameTemplate) || m.RussianTitle.Contains(nameTemplate));
            return ret.OrderByDescending(m => m.MovieId).Select(
                m => new Film {
                    ID = m.MovieId,
                    date = (DateTime)m.ReleaseDate,
                    name = m.OriginalTitle + " (" + m.RussianTitle + ")",
                    genres = m.Genre.Select( g => new FilmsBLL.Models.Genre { ID = g.GenreId, name = g.Name}),
                    actors = m.MovieToPerson.Where(m_to_p => m_to_p.DepartmentId==57).Select( a => new FilmsBLL.Models.Actor { ID = a.PersonId, name = a.Person.EnglishName+" ("+a.Person.RussianName+")"})
                });
        }

        
        public Film getFilm(Guid ID)
        {
            if (ID != null)
            {
                var movie = model.Movie.Find(ID);
                return new Film {
                    ID = movie.MovieId,
                    name = movie.OriginalTitle,
                    date = (DateTime)movie.ReleaseDate
                };
            }
            else
                return null;
        }

       
        public Film createOrUpdateFilm(Film film)
        {
            if(film.ID != null && film.ID != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                var movie = model.Movie.Find(film.ID);
                movie.OriginalTitle = film.name;
                movie.ReleaseDate = film.date;
                model.Entry(movie).State = EntityState.Modified;
                model.SaveChanges();
            }
            else
            {
                var movie = new Movie
                {
                    OriginalTitle = film.name,
                    RussianTitle = "",
                    ReleaseDate = film.date,
                    MovieId = Guid.NewGuid()
                };
                model.Movie.Add(movie);
                model.SaveChanges();
                film.ID = movie.MovieId;
            }
            return film;
        }
        public void deleteFilm(Film film)
        {
            if(film!=null)
            {
                var movie = model.Movie.Find(film.ID);
                model.Movie.Remove(movie);
                model.SaveChanges();
            }
        }
    }
}
