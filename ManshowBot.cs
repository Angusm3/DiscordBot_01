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
                await bot.Connect("treeforge2.al@gmail.com", "superbotpassword");
            });
        }

        private void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;

            if(e.Message.Text == "!help")
            {
                e.Channel.SendMessage(e.User.Mention + "Commands:\n!help\n!roll XdY+Z");
            }




            if (e.Message.Text.Contains ("!roll "))
            {








                string text = e.Message.Text;

                text = text.Replace("!roll ", "");


                char[] delimiterChars = { 'd', '+' };




//                e.Channel.SendMessage("Original text: " + text);

                string[] words = text.Split(delimiterChars);
                //                e.Channel.SendMessage("numbers in roll:" + words.Length);
                if (text)

                int mod = 0;
                int[] DieArray;
                DieArray = new int[3];
                DieArray[0] = 0;
                DieArray[1] = 0;
                DieArray[2] = 0;

                DieArray = text.Split('d', '+').Select(str => int.Parse(str)).ToArray();


                if (e.Message.Text.Contains("+"))
                {
                    mod = 0;
                    if (DieArray[2] != 0)
                    {
                        mod = mod + DieArray[2];
                    }
                }
                if (DieArray[1] == 0)
                {
                    return;
                }




                var index = Array.FindIndex(DieArray, x => x == 2);
                Console.WriteLine(text);
                if (DieArray[1] > 1000)
                    DieArray[1] = 1000;

                string[] DieString = DieArray.Select(x => x.ToString()).ToArray();

                e.Channel.SendMessage("Dice Rolled: " + DieString[0] + "d" + DieString[1]);





                for (int i = 0; i < DieArray[0]; ++i)
                {
                    Random rnd = new Random();
                    DiceRoll var = new DiscordBot_01.DiceRoll();

                    int roll = rnd.Next(1, DieArray[1] + 1);

                    
                    int total = roll + mod;
                    if (mod == 0)
                    {
                        e.Channel.SendMessage("Rolled .. " + roll );
                    }
                    else
                    e.Channel.SendMessage("Rolled .. " + roll + " + " + mod + " = " + total);
 
                    
                    
                    
                    
                }

             // e.Channel.SendMessage(DieString[2]);





            }
            if (e.Message.Text == "!reaction")
            {
                e.Channel.SendMessage("http://i.imgur.com/0SZIUqA.gif");
            }

        }
    }
}
