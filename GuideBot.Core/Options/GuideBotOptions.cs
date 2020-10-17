using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.Core.Options
{
    public class GuideBotOptions
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string WebHookUrl { get; set; } // Part of webhook url that gives ngrok. Command to get it for ssl in IIS Express: ngrok http https://localhost:44360 -host-header="localhost:44360" \\ ngrok http https://localhost:5001 -host-header="localhost:5001"

    }
}
