using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class BookGenre
    {
        public int Id { get; set; }
        public int? IdBook { get; set; }
        public int? IdGenre { get; set; }

        public virtual Book IdBookNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
    }
}
