using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.WebSocket;
using DiscordBot.Commands;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Program
    {
        private static DiscordSocketClient _client;
        private static SlashCommand slashCommand = new SlashCommand();
        private const string token = "";
        public static async Task Main(string[] args)
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            _client.Ready += Client_Ready;
            _client.SlashCommandExecuted += slashCommand.SlashCommandHandler;

            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public static async Task Client_Ready()
        { 
            var globalCommand = new SlashCommandBuilder();
            globalCommand.WithName("give-me-quote");
            globalCommand.WithDescription("Returns quote from Game of Thrones.");

            try
            {
                await _client.CreateGlobalApplicationCommandAsync(globalCommand.Build());
   
            }
            catch (HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Message, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
}
