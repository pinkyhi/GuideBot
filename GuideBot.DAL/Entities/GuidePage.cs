using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Entities
{
    public class GuidePage
    {
        public int GuideId { get; set; }

        public Guide Guide { get; set; }

        public int PageId { get; set; }

        public Page Page { get; set; }

        public int Position { get; set; }
    }
}
