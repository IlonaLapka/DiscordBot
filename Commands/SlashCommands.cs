using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using DiscordBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Commands
{
    public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService Commands { get; set; }
        private CommandHandler _handler;
        public QuoteService quoteService = new QuoteService();

        public SlashCommands(CommandHandler handler)
        {
            _handler = handler;
        }
        

        [SlashCommand("quote", "Returns quote from Game of Thrones.")]
        public async Task ReturnQuote()
        {
            await RespondAsync(quoteService.GetQuote());
        }

        [SlashCommand("echo", "Returns passing text.")]
        public async Task Repeat(string text, bool mention)
        {
            await RespondAsync((mention ? Context.User.Mention + " " : String.Empty) + text);
        }

        [UserCommand("greet")]
        public async Task GreetUserAsync(IUser user)
        {
            await RespondAsync(text: $"Cheers  <@{user.Id}>! :wine_glass:");
        }
    }
}
