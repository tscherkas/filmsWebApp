using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;
using System.Data.Entity;

namespace FilmsDAL_EF.Services
{
    public class ActorsDAL_EF : FilmsBLL.OuterInterfaces.IActorDAL
    {
        public FilmModel  model { get; set; }
        public ActorsDAL_EF()
        {
            model = new FilmModel();
        }
        public Actor createOrUpdateActor(Actor actor)
        {
            if (actor.ID != null&& actor.ID!=new Guid("00000000-0000-0000-0000-000000000000"))
            {
                var person = new Person
                {
                    EnglishName = actor.name,
                    PersonId = actor.ID

                };
                model.Entry(person).State = EntityState.Modified;
                model.SaveChanges();
            }
            else
            {
                var person = new Person
                {
                    EnglishName = actor.name

                };
                model.Person.Add(person);
                model.SaveChanges();
                actor.ID = person.PersonId;
            }
            return actor;
        }

        public void deleteActor(Actor actor)
        {
            if(actor.ID != null )
            {
                var person = new Person
                {
                    PersonId = actor.ID
                };
                model.Person.Attach(person);
                model.Person.Remove(person);
                model.SaveChanges();
            }
        }

        public Actor getActor(Guid ID)
        {
            if (ID != null)
            {
                var person = model.Person.Find(ID);
                return new Actor
                {
                    ID = person.PersonId,
                    name = person.EnglishName
                   
                };
            }
            else
                return null;
        }

        public IQueryable<Actor> getActorsIQueryable()
        {
            var ret = (from p in model.Person select p).OrderByDescending(p => p.PersonId).Select(
                p => new Actor { ID = p.PersonId, name = p.EnglishName+" (" + p.RussianName??""+")"}
                );
            return ret;
        }
    }
}
