using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;
using Ninject;

namespace FilmsBLL.Services
{
    public class MyFilmRecommendService : IFilmRecommendService
    {
        [Inject]
        public ActorsService actorsservice { get; set; }
        public MyFilmRecommendService()
        {
            actorsservice = new ActorsService();
        }
        public ICollection<Film> recommend(ICollection<Film> precondition, ICollection<Film> yetRecommended, int Number)
        {
            if(precondition==null|| precondition.Count<1)
                return new List<Film>();
            var retList = new List<Film>();
            for (int i = 0; i < (Number>0?Number:10); i++)
            {
                var tmp_film = precondition.ElementAt(new Random().Next(0, precondition.Count()-1));
                if(tmp_film.actors!=null&&tmp_film.actors.Count()>0)
                {
                    var tmp_actor = tmp_film.actors.ElementAt(new Random().Next(0, tmp_film.actors.Count()-1));
                    if (tmp_actor != null)
                    {
                        tmp_actor = actorsservice.getActorWithFilmsFromDAL(tmp_actor.ID);
                        if (tmp_actor != null&&tmp_actor.films.Count()>0)
                        { 
                            var rec_film = tmp_actor.films.ElementAt(new Random().Next(0, tmp_actor.films.Count() - 1));
                            if (!yetRecommended.Contains(rec_film) && !retList.Contains(rec_film))
                                retList.Add(rec_film);
                        }
                    }
                }
            }
            return retList;
        }
    }
}
