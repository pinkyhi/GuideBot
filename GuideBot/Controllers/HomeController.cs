using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuideBot.BL.Bots;
using GuideBot.Core.Exceptions;
using GuideBot.DAL.Entities;
using GuideBot.DAL.Interfaces;
using GuideBot.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace GuideBot.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(GuideBotExceptionFilterAttribute))]
    public class HomeController : ControllerBase
    {
        private readonly IRepository repository;
        private readonly GuideBotClient guideBot;
        public HomeController(IRepository repository, GuideBotClient guideBot)
        {
            this.repository = repository;
            this.guideBot = guideBot;
        }

        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                if (update.Message.Text?.StartsWith('/') ?? false)
                {
                    await guideBot.BotClient.SendTextMessageAsync(update.Message.From.Id, $"Hi {update.Message.From.FirstName}");
                }
            }
            else if (update.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
            }
            return Ok();
        }
    }
}
