using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Discord.Audio;
using System.Net;
using System.Globalization;

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

            if(e.Message.Text == "gibnao")
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=3-0mdbo0Xo0");
            }

            if(e.Message.Text == "!start voice")
            {
                //IAudioClient.Join(bot);
            }


            if (e.Message.Text.StartsWith("wiki "))
            {
                string text = e.Message.Text;
                text = text.Replace("wiki ", "");
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;






                string text2 = ("http://www.dandwiki.com/wiki/SRD:" + myTI.ToTitleCase(text));






                text2 = text2.Replace(" ", "_");
                text2 = text2.Replace("Of", "of");


                e.Channel.SendMessage(text2);


                //e.Channel.SendMessage(text);






            }











            if (e.Message.Text.StartsWith("roll "))
                
            {








                string text = e.Message.Text;

 //               Regex DieTest = new Regex("(roll[0 - 9]d[0 - 9] +)");
//
//                Console.WriteLine("{0} {1} a valid die.",
//                           text,
//                           DieTest.IsMatch(text) ? "is" : "is not");



                text = text.Replace("roll ", "");



                char[] DieList = { 'd', '+' };




                //                e.Channel.SendMessage("Original text: " + text);

                string[] words = text.Split(DieList);
//                e.Channel.SendMessage("numbers in roll:" + words.Length);


                int mod = 0;
                int[] DieArray;
                DieArray = new int[3];
                DieArray[0] = 0;
                DieArray[1] = 0;
                DieArray[2] = 0;
                try
                {
                    DieArray = text.Split('d', '+').Select(str => int.Parse(str)).ToArray();
                }
                catch(FormatException)
                {
 //                   e.Channel.SendMessage("invalid die");
                        return;
                }

                try
                {
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
                if (DieArray[0] > 10)
                    DieArray[0] = 10;
                }
                catch (IndexOutOfRangeException)
                {
 //                   e.Channel.SendMessage("invalid die");
                    return;
                }

                string[] DieString = DieArray.Select(x => x.ToString()).ToArray();
                if (mod == 0)
                {
                    e.Channel.SendMessage("Dice Rolled: " + DieString[0] + "d" + DieString[1]);
                }
                else if (mod > 0)
                {
                    e.Channel.SendMessage("Dice Rolled: " + DieString[0] + "d" + DieString[1] + "+" + DieString[2]);
                }


                    



                Random rnd = new Random();

                int rollSum = 0;
                int total = 0;
                int ismodified = 0;
                int ismultiple = 0;
                for (int i = 0; i < DieArray[0]; ++i)
                {


                    try
                    {
                        int roll = rnd.Next(1, DieArray[1] + 1);


                        total = roll + mod;
                        if (DieArray[0] == 1 && mod == 0)
                        {
                            e.Channel.SendMessage("Rolled 1 die .. " + roll);
                            ismodified = 0;
                            ismultiple = 0;
                        }
                        else if (DieArray[0] == 1 && mod > 0)
                        {
                            rollSum = rollSum + roll;
                            e.Channel.SendMessage("Rolled single modified die .. " + roll);
                            ismodified = 1;
                            ismultiple = 0;
                        }
                        else if (DieArray[0] > 1 && mod > 0)
                        {
                            rollSum = rollSum + roll;
                            e.Channel.SendMessage("Rolled multiple modified dice .. " + roll);
                            ismodified = 1;
                            ismultiple = 1;
                        }
                        else if (DieArray[0] > 1 && mod == 0)
                        {

                            e.Channel.SendMessage("Rolled multiple dice .. " + roll);
                            ismodified = 0;
                            ismultiple = 1;
                        }

                    }

                    catch (ArgumentOutOfRangeException)
                    {
                        e.Channel.SendMessage("pesky bee! " + DieArray[1] + " is not a die!");
                        return;
                    }




                }


                if (ismodified == 1 && ismultiple == 1)
                {
                    int rollTotal = rollSum + mod;
                    e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + " + " + DieArray[2] + " = " + rollTotal);
                }
                else if (ismodified == 1 && ismultiple == 0)
                {
                    rollSum = total;
                    e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + " + " + DieArray[2] + " = " + rollSum);
                }
                else if (ismodified == 0)
                {
                    return;
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
