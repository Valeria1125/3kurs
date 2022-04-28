using couse_work_web.ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cousework_3_kurs.db
{
    public partial class Genre
    {
        public static explicit operator GenreApi(Genre author)
        {
            return new GenreApi { Id = author.Id, Genre = author.Genre1 };
        }

        public static explicit operator Genre(GenreApi author)
        {
            return new Genre { Id = author.Id, Genre1 = author.Genre };
        }
    }
}
