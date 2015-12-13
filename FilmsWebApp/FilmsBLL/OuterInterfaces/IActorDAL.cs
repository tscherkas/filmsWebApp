﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL.OuterInterfaces
{
    public interface IActorDAL
    {
        IQueryable<Actor> getActorsIQueryable();
        Actor getActor(Guid ID);
        Actor createOrUpdateActor(Actor actor);
        void deleteActor(Actor actor);
    }
}
