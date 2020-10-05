using GuideBot.DAL.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class Guide : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Descripton { get; set; }

        public string Requisites { get; set; }

        public IEnumerable<GuidePage> GuidePages { get; set; }
    }
}
