using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using RustNotifierBot.CommandHandler;
using System.IO;
using RustNotifierBot.Configuration;
using System;

namespace ConsoleApplication1
{
    class DiscordBot
    {

        public static void Main(string[] args) =>
            new DiscordBot().Start().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        private CommandHandler handler;

        public async Task Start()
        {
            EnsureConfigExists();

            // Define the DiscordSocketClient
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                WebSocketProvider = Discord.Net.Providers.WS4Net.WS4NetProvider.Instance
            });

            // Login and connect to Discord.
            await client.LoginAsync(TokenType.Bot, Configuration.Load().Token);
            await client.ConnectAsync();

            var map = new DependencyMap();
            map.Add(client);

            handler = new CommandHandler();
            await handler.Install(map);


            // Block this program until it is closed.
            await Task.Delay(-1);
        }

        private void EnsureConfigExists()
        {

            if (!Directory.Exists("data"))                      // Check if the data folder exists.
                Directory.CreateDirectory("data");              // Create the data folder.

            string loc = "data/configuration.json";             // Save the file location of the configuration to a string.

            if (!File.Exists(loc))                              // Check if the configuration file exists.
            {
                var config = new Configuration();               // Create a new configuration object.

                Console.WriteLine("The configuration file has been created at 'data\\configuration.json', " +
                              $"please enter your information and restart {config.BotName}.");
                Console.Write("Token: ");
                config.Token = Console.ReadLine();              // Read the bot token from console.

                Console.Write("Bot Name: ");
                config.BotName = Console.ReadLine();

                config.Save();                                  // Save the new configuration object to file.
            }
            Console.WriteLine("Configuration Loaded...");
        }

    }
}
