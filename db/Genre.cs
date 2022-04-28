using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class Genre
    {
        public Genre()
        {
            BookGenres = new HashSet<BookGenre>();
        }

        public int Id { get; set; }
        public string Genre1 { get; set; }

        public virtual ICollection<BookGenre> BookGenres { get; set; }
    }
}
