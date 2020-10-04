using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities.BaseEntities
{
    public abstract class BaseEntity : BaseDto
    {
        public int Id { get; set; }
    }
}
