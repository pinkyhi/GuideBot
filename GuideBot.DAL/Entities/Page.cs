using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities
{
    class Page: BaseEntity
    {
        public string Text { get; set; }
        

        public int ParseMode { get; set; }



    }
}
