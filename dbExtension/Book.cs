using couse_work_web.ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cousework_3_kurs.db
{
    public partial class Book
    {
        public static explicit operator BookApi(Book book)
        {
            return new BookApi { Id = book.Id, TitleBook = book.TitleBook };
        }

        public static explicit operator Book(BookApi book)
        {
            return new Book { Id = book.Id, TitleBook = book.TitleBook };
        }
    }
}
