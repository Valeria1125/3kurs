using couse_work_web.ModelsApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cousework_3_kurs.db
{
    public partial class Publishing
    {
        public static explicit operator PublishingApi(Publishing author)
        {
            return new PublishingApi { Id = author.Id,  PublishingHouse = author.PublishingHouse };
        }

        public static explicit operator Publishing(PublishingApi author)
        {
            return new Publishing { Id = author.Id, PublishingHouse = author.PublishingHouse };
        }
    }
}
