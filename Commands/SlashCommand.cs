using Discord.WebSocket;
using DiscordBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class SlashCommand
    {
        public QuoteService quoteService = new QuoteService(); 

        public async Task SlashCommandHandler(SocketSlashCommand command)
        {
            if (command.Data.Name == "give-me-quote")
            {
                await command.RespondAsync(quoteService.GetQuote());
            }
        }
    }
}
