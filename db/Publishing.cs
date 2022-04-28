using System;
using System.Collections.Generic;

#nullable disable

namespace Cousework_3_kurs.db
{
    public partial class Publishing
    {
        public Publishing()
        {
            BookPublishes = new HashSet<BookPublish>();
        }

        public int Id { get; set; }
        public string PublishingHouse { get; set; }

        public virtual ICollection<BookPublish> BookPublishes { get; set; }
    }
}
