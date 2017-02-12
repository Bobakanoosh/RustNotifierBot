using Discord.Commands;
using System.Threading.Tasks;

namespace RustNotifierBot.InfoModule
{
    [Group("bot")]
    public class BotModule : ModuleBase
    {
        
        [Command("info"), Summary("Give basic info of the bot!")]
        public async Task Info(int number = 0)
        {
            await ReplyAsync($"**RustNotifierBot V.0.1.1 by Bobakanoosh.**\n" +
                "**Features:**\n" +
                "- Send info from in-game to discord via the /report command\n" +
                "- **Upcoming:**\n" +
                "- Livefeed of dev Twitter\n" +
                "- Announcement on Devblog release\n" +
                "- More?\n");

        }

    }
    
}
