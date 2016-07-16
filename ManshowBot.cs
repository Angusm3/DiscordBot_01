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

            if(e.Message.Text == "!rules")
            {
                e.Channel.SendMessage(e.User.Mention + " Here's your stupid help asshole");
            }
            if (e.Message.Text == "help")
            {
                e.Channel.SendMessage(e.User.Mention + " Fack you");

            }
            if (e.Message.Text == "+roll 1d20")
            {
                e.Channel.SendMessage("30");

            }
        }
    }
}
