using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.Core.Exceptions
{
    public abstract class GuideBotException : Exception
    {
        public int? ChatId { get; set; }

        public GuideBotException(string message, int? chatId = null) : base(message)
        {
            ChatId = chatId;
        }
    }
}
