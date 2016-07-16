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




            if (e.Message.Text.Contains ("roll "))
            {
                
                string text = e.Message.Text;

                text = text.Replace("roll ", "");


                char[] delimiterChars = { 'd', ' ' };


//                e.Channel.SendMessage("Original text: " + text);

                string[] words = text.Split(delimiterChars);
//                e.Channel.SendMessage("numbers in roll:" + words.Length);




                int[] DieArray = text.Split('d').Select(str => int.Parse(str)).ToArray();
                Console.WriteLine(text);
                if (DieArray[1] > 1000)
                    DieArray[1] = 1000;

                string[] DieString = DieArray.Select(x => x.ToString()).ToArray();

                e.Channel.SendMessage("Dice Rolled: " + DieString[0] + "d" + DieString[1]);




                for (int i = 0; i < DieArray[0]; ++i)
                {
                    Random rnd = new Random();
                    DiceRoll var = new DiscordBot_01.DiceRoll();
                    e.Channel.SendMessage("Rolled .. " + rnd.Next(1, DieArray[1] + 1));

                    
                }

//              e.Channel.SendMessage(DieString[1]);





            }
            if (e.Message.Text == "!reaction")
            {
                e.Channel.SendMessage("http://i.imgur.com/0SZIUqA.gif");
            }

        }
    }
}
