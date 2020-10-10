using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class PageImage : BaseEntity
    {
        public int PageId { get; set; }

        public int ImageId { get; set; }

        public int Position { get; set;  }

        public Image Image { get; set; }

        public Page Page { get; set; }
    }
}
