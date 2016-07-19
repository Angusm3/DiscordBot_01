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

            if (e.Message.Text.EndsWith("dour?"))
            {
                e.Channel.SendMessage("Of course Sir.");
            }
            if (e.Message.Text.Contains("Pompadour "))
            {
                e.Channel.SendMessage("You rang?");
            }






            if (e.Message.Text.StartsWith("wiki "))
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                string text = e.Message.Text;
                text = text.Replace("wiki ", "srd");


                if (text.StartsWith("srd5e "))
                {
                    text = text.Replace("srd5e ", "");
                    string text5e = ("http://www.dandwiki.com/wiki/5e_SRD:" + myTI.ToTitleCase(text));

                    text5e = text5e.Replace("E" + " ", "e" + " ");
                    text5e = text5e.Replace(" ", "_");
                    text5e = text5e.Replace("Of", "of");
                    text5e = text5e.Replace("The", "the");

                    e.Channel.SendMessage(text5e);
                }
                else if (text.StartsWith("srd4e"))
                {
                    text = text.Replace("srd4e", "");
                    string text4e = ("http://www.dandwiki.com/wiki/4e_Homebrew" + myTI.ToTitleCase(text));

                    text4e = text4e.Replace("E" + " ", "e" + " ");
                    text4e = text4e.Replace(" ", "_");
                    text4e = text4e.Replace("Of", "of");
                    text4e = text4e.Replace("The", "the");

                    e.Channel.SendMessage(text4e);
                }
                else if (text.StartsWith("srd3.5e "))
                {
                    text = text.Replace("srd3.5e ", "");
                    string text35e = ("http://www.dandwiki.com/wiki/" + myTI.ToTitleCase(text) + "_(3.5e_Class)");

                    text35e = text35e.Replace("E" + " ", "e" + " ");
                    text35e = text35e.Replace(" ", "_");
                    text35e = text35e.Replace("Of", "of");
                    text35e = text35e.Replace("The", "the");

                    e.Channel.SendMessage(text35e);
                }
                else if (text.StartsWith("srd"))
                {
                    text = text.Replace("srd", "");
                    string textsrd = ("http://www.dandwiki.com/wiki/SRD:" + myTI.ToTitleCase(text));

                    textsrd = textsrd.Replace("E" + " ", "e" + " ");
                    textsrd = textsrd.Replace(" ", "_");
                    textsrd = textsrd.Replace("Of", "of");
                    textsrd = textsrd.Replace("The", "the");

                    e.Channel.SendMessage(textsrd);
                }




            }

            //if (e.Message.Text.StartsWith("list"))
            //{
            //    string text = e.messa
            //}

            if (e.Message.Text.StartsWith("PClist"))
            {
                string text = e.Message.Text;

                if (text.EndsWith("PClist"))
                {
                    e.Channel.SendMessage("Pompadour");
                    e.Channel.SendMessage("Suzie");
                    e.Channel.SendMessage("Valyr");
                    e.Channel.SendMessage("Freidrich");
                    e.Channel.SendMessage("Grimm");
                }


                text = text.Replace("PClist", "");
                text = text.Replace(" ", "");

                if (text.StartsWith("Pompadour"))
                {
                    e.Channel.SendMessage("https://docs.google.com/document/d/1fweHOOAdBHhP41BeLmouRmlhVRSTiS2mHjxovaeWO6M/edit");
                }
                else if (text.StartsWith("Suzie"))
                {
                    e.Channel.SendMessage("https://docs.google.com/document/d/1tEPd1eFeoLDIsS7MWlp2zt5EthLtBGImXzpnROPzQtE/edit");
                }
                else if (text.StartsWith("Valyr"))
                {
                    e.Channel.SendMessage("https://docs.google.com/document/d/1beXrXt5AW4snbSUgcO4SH3kRo3xYqGlo8MWryDM5M-A/edit");
                }
                else if (text.StartsWith("Freidrich"))
                {
                    e.Channel.SendMessage("https://docs.google.com/document/d/1CIouYRPvT_CVMYwR2XL4tn4MD_6OUNS7X3uJzoTh_Is/edit");
                }
                else if (text.StartsWith("Grimm"))
                {
                    e.Channel.SendMessage("https://docs.google.com/document/d/19N5DjpWPbiAha0n8nkYdXoayzrHh-3xI1f0-DgrpBR0/edit");
                }

                
                
                

            }




            if (e.Message.Text.Contains("y tho"))
            {
                e.Channel.SendMessage("http://i.imgur.com/yNlQWRM.jpg");
            }



            if (e.Message.Text.StartsWith("roll "))
                
            {

                string text = e.Message.Text;
                text = text.Replace("roll ", "");



                if (text.Contains("k"))
                {
                    char[] KeepList = { 'd', 'k' };

                    string[] words2 = text.Split(KeepList);

                    int[] DieArray = new int[3];
                    DieArray[0] = 0;
                    DieArray[1] = 0;
                    DieArray[2] = 0;
                    try
                    {
                        DieArray = text.Split('d', 'k').Select(str => int.Parse(str)).ToArray();
                    }
                    catch (FormatException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }
                    string[] DieString = DieArray.Select(x => x.ToString()).ToArray();
                    e.Channel.SendMessage("Rolling KeepDice Function ..  Amount .. " + DieString[0] + " |Die ..  " + DieString[1] + " |Keep .. " + DieString[2]);

                    int Die = DieArray[0];
                    int Roll = DieArray[1];
                    int Keep = DieArray[2];



                    Random rnd = new Random();
                    int[] DieResult = new int[Die];
                    try
                    {
                        for (int i = 0; i < Die; ++i)
                        {
                            int Result = rnd.Next(1, DieArray[1] + 1);
                            DieResult[i] = Result;

                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        return;
                    }

                    foreach (int Element in DieResult)
                    {
                        string ElementString = Element.ToString();
                        e.Channel.SendMessage(ElementString);
                    }



                    int KeepSum = 0;
                    Array.Sort(DieResult);
                    Array.Reverse(DieResult);
                    for (int i = 0; i < Keep; ++i)
                    {
                        try
                        {
                            e.Channel.SendMessage(".." + DieResult[i]);

                            KeepSum = KeepSum + DieResult[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }


                    }

                    e.Channel.SendMessage("Sum.. " + KeepSum);




                }




                else
                    
                {
                    char[] DieList = { 'd', '+' };

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
                    catch (FormatException)
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
