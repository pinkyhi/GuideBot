using GuideBot.BL.Bots;
using GuideBot.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace GuideBot.Filters
{
    public class GuideBotExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger<GuideBotExceptionFilterAttribute> logger;
        private readonly GuideBotClient guideBot;

        public GuideBotExceptionFilterAttribute(ILogger<GuideBotExceptionFilterAttribute> logger, GuideBotClient guideBot)
        {
            this.logger = logger;
            this.guideBot = guideBot;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().IsSubclassOf(typeof(GuideBotException)))
            {
                int? chatId = (context.Exception as GuideBotException).ChatId;
                if (chatId != null)
                {
                    guideBot.BotClient.SendTextMessageAsync(chatId, context.Exception.Message);
                }
                ObjectResult result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status200OK
                };

                context.Result = result;
            }
            else
            {
                this.logger.LogError(context.Exception.Message, context.Exception.StackTrace);

                context.Result = new ObjectResult(context.Exception.Message)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }

            context.ExceptionHandled = true;
        }
    }
}
