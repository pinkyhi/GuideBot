using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class Page : BaseEntity
    {
        public string Text { get; set; }

        [Required]
        public int ParseMode { get; set; }

        public IEnumerable<GuidePage> GuidePages { get; set; }
    }
}
