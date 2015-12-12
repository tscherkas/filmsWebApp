using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL.Services
{
    class MyFilmRecommendService : IFilmRecommendService
    {
        public ICollection<Film> recommend(ICollection<Film> precondition, ICollection<Film> yetRecommended, int maximumNumber)
        {
            if(precondition==null|| precondition.Count<1)
                return new List<Film>();
            var retList = new List<Film>();
            for (int i = 0; i < (maximumNumber>0?maximumNumber+10:10); i++)
            {
                var tmp_film = precondition.ElementAt(new Random().Next(0, precondition.Count()-1));
                if(tmp_film.actors.Count()>0)
                {
                    var tmp_actor = tmp_film.actors.ElementAt(new Random().Next(0, tmp_film.actors.Count()-1));
                    var rec_film = tmp_actor.films.ElementAt(new Random().Next(0, tmp_actor.films.Count() - 1));
                    if(!yetRecommended.Contains(rec_film)&&!retList.Contains(rec_film))
                        retList.Add(rec_film);
                }
            }
            return retList;
        }
    }
}
