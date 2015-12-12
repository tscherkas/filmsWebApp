using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmsBLL.Models;
namespace FilmsBLL.Services
{
    interface IFilmRecommendService
    {
        ICollection<Film> recommend(ICollection<Film> precondition,ICollection<Film> yetRecommended, int maximumNumber);
    }
}
