using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_01
{
    public class ManshowBot
    {
        private DiscordClient bot;

        public ManshowBot()
        {
            bot = new DiscordClient();



            bot.ExecuteAndWait(async () =>
            {
                bot.MessageReceived += Bot_MessageReceived;
                await bot.Connect("treeforge2.al@gmail.com", "Zninern4");
            });
        }

        private void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;

            if(e.Message.Text == "!help")
            {
                e.Channel.SendMessage(e.User.Mention + "Commands:\n1d4\n!help");
            }
            if (e.Message.Text == "1d4")
            {
                DiceRoll var = new DiscordBot_01.DiceRoll();
              e.Channel.SendMessage("Rolled .. " + DiceRoll.OneDieFour);
            }

        }
    }
}
