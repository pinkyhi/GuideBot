using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class Guide : BaseEntity
    {
        public string Title { get; set; }

        public string Descripton { get; set; }

        public string Requisites { get; set; }
    }
}
