using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
