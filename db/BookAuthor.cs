using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class BookAuthor
    {
        public int Id { get; set; }
        public int? IdBook { get; set; }
        public int? IdAuthor { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Book IdBookNavigation { get; set; }
    }
}
