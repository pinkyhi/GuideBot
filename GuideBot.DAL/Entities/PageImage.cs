using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class PageImage : BaseEntity
    {
        public int Position { get; set;  }

        public string Image { get; set; }
    }
}
