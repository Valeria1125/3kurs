using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class BookPublish
    {
        public int Id { get; set; }
        public string YearOfPublication { get; set; }
        public int? IdBook { get; set; }
        public int? IdPublish { get; set; }

        public virtual Book IdBookNavigation { get; set; }
        public virtual Publishing IdPublishNavigation { get; set; }
    }
}
