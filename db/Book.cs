using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
            BookGenres = new HashSet<BookGenre>();
            BookPublishes = new HashSet<BookPublish>();
        }

        public int Id { get; set; }
        public string TitleBook { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
        public virtual ICollection<BookGenre> BookGenres { get; set; }
        public virtual ICollection<BookPublish> BookPublishes { get; set; }
    }
}
