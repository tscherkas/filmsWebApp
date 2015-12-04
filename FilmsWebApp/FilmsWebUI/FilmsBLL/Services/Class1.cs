using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsBLL.Models;

namespace FilmsBLL
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Class1
    {
        public Class1()
        {
        }
        public FilmModel getFilm()
        {
            return new FilmModel()
            {
                name = "Terminator",
                genres = new List<GenreModel>()
                {
                    new GenreModel()
                    {
                        name = "Action"
                    },
                    new GenreModel()
                    {
                        name = "Triller"
                    }
                },
                actors = new List<PersonModel>()
                {
                    new PersonModel()
                    {
                        name = "Schwarzenegger"
                    }
                }
            };
        }
    }
}
