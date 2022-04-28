using couse_work_web.ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cousework_3_kurs.db
{
    public partial class Author
    {
        public static explicit operator AuthorApi(Author author)
        {
            return new AuthorApi { Id = author.Id, Author = author.Fio };
        }

        public static explicit operator Author(AuthorApi author)
        {
            return new Author { Id = author.Id, Fio = author.Author };
        }

       
    }
}

