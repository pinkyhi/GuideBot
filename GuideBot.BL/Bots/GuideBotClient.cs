using GuideBot.Core.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace GuideBot.BL.Bots
{
    public class GuideBotClient
    {
        public TelegramBotClient BotClient { get; private set; }

        public GuideBotClient(GuideBotOptions options)
        {
            this.BotClient = InitializeBot(options).Result;
        }

        private async Task<TelegramBotClient> InitializeBot(GuideBotOptions guideBotOptions)
        {
            TelegramBotClient telegramBotClient = new TelegramBotClient(guideBotOptions.Token);
            //using (FileStream fs = File.OpenRead(""))
            //{
                //InputFileStream ifs = new InputFileStream(fs);
                string hook = guideBotOptions.WebHookUrl;    // Setting the webhook for telegram
                Console.WriteLine(hook);
                await telegramBotClient.SetWebhookAsync(hook);
            //}
            return telegramBotClient;
        }
    }
}
