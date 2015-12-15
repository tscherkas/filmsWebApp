using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FilmsDAL_EF.Services
{
    public class GenresDAL_EF : FilmsBLL.OuterInterfaces.IGenreDAL
    {
        public FilmModel model { get; set; }
        public GenresDAL_EF()
        {
            model = new FilmModel();
        }
        public FilmsBLL.Models.Genre createOrUpdateGenre(FilmsBLL.Models.Genre genre)
        {
            if (genre.ID != 0)
            {
                var g = model.Genre.Find(genre.ID);
                g.Name = genre.name;

                model.Entry(g).State = EntityState.Modified;
                model.SaveChanges();
            }
            else
            {
                var g = new Genre
                {
                    Name = genre.name

                };
                model.Genre.Add(g);
                model.SaveChanges();
                genre.ID = g.GenreId;
            }
            return genre;
        }

        public void deleteGenre(FilmsBLL.Models.Genre genre)
        {
            if (genre.ID != 0)
            {
                var g = model.Genre.Find(genre.ID);
                model.Genre.Remove(g);
                model.SaveChanges();
            }
        }

        public FilmsBLL.Models.Genre getGenre(int ID)
        {
            if (ID != 0)
            {
                var genre = model.Genre.Find(ID);
                return new FilmsBLL.Models.Genre
                {
                    ID = genre.GenreId,
                    name = genre.Name

                };
            }
            else
                return null;
        }

        public IQueryable<FilmsBLL.Models.Genre> getGenreIQueryable(string nameTemplate = "")
        {
            var ret = (from g in model.Genre select g);
            ret = ret.Where(g => g.Name.Contains(nameTemplate)).OrderByDescending(g => g.GenreId);
            return ret.Select(
                g => new FilmsBLL.Models.Genre { ID = g.GenreId, name = g.Name}
                );
        }
    }
}
