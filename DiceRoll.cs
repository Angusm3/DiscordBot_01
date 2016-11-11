using Discord;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Discord.Audio;
using System.Net;
using System.Globalization;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Web;
using System.Threading;



namespace DiscordBot_01
{
    public class DiceRoll
    {
        private DiscordClient DR;

        public DiceRoll()
        {
            DR = new DiscordClient();

            DR.ExecuteAndWait(async () =>
            {
                DR.MessageReceived += Bot_MessageReceived;
                await DR.Connect("treeforge2.al@gmail.com", "superbotpassword");
            });



        }

        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;





            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //WIKI
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

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
            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //PCLIST
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------


            if (e.Message.Text.StartsWith("PClist"))
            {
                string text = e.Message.Text;

                if (text.EndsWith("PClist"))
                {
                    e.Channel.SendMessage("PClist + Character Name");
                    e.Channel.SendMessage("Pompadour\nSuzie\nValyr\nFreidrich\nGrimm");

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
            if (e.Message.Text.StartsWith("roll "))

            {



                string text = e.Message.Text;
                string DCres = "";
                text = text.Replace("roll ", "");
                text = text.Trim();
                bool DCexists = false;

                if (text.Contains("DC"))
                {

                    string[] DC = text.Split(new[] { "DC" }, StringSplitOptions.None);
                    DCexists = true;
                    //e.Channel.SendMessage(DC[0] + ", " + "DC: " + DC[1]);

                    text = DC[0];
                    DCres = DC[1];
                }

                text = text.Trim();


                if (text.Contains("k"))
                {
                    char[] KeepList = { 'd', 'k' };

                    string[] words2 = text.Split(KeepList);

                    int[] DieArray = new int[3];
                    DieArray[0] = 0;
                    DieArray[1] = 0;
                    DieArray[2] = 0;


                    string[] IMDARRAY;
                    IMDARRAY = new string[3];
                    IMDARRAY[0] = "";
                    IMDARRAY[1] = "";
                    IMDARRAY[2] = "0";




                    // IMDARRAY = text.Split('d', '+', '-').ToArray(IMDARRAY);

                    char[] charSeparators;
                    charSeparators = new char[3];
                    charSeparators[0] = 'd';
                    charSeparators[1] = '+';
                    charSeparators[2] = '-';



                    IMDARRAY = text.Split(charSeparators, StringSplitOptions.None);

                    if (IMDARRAY[0].Length > 9)
                    {
                        e.Channel.SendMessage("die amount exceeds int range");
                        return;
                    }
                    if (IMDARRAY[1].Length > 9)
                    {
                        e.Channel.SendMessage("die value exceeds int range");
                        return;
                    }




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
                    //e.Channel.SendMessage("Rolling KeepDice Function ..  Amount .. " + DieString[0] + " |Die ..  " + DieString[1] + " |Keep .. " + DieString[2]);

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
                    string ElementString = "";
                    string finaloutput = "";
                    foreach (int Element in DieResult)
                    {
                        ElementString = Element.ToString();
                        finaloutput = finaloutput + ElementString + ", ";

                    }
                    if (finaloutput.Length > 1950)
                    {
                        e.Channel.SendMessage("string length exceeds 2000 characters");
                    }
                    if (finaloutput.Length < 1950)
                    {
                        e.Channel.SendMessage(finaloutput);
                    }

                    int KeepSum = 0;
                    Array.Sort(DieResult);
                    Array.Reverse(DieResult);
                    for (int i = 0; i < Keep; ++i)
                    {
                        try
                        {
                            KeepSum = KeepSum + DieResult[i];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            break;
                        }
                    }

                    e.Channel.SendMessage("Keeping (" + Keep + ") Sum.. " + KeepSum);
                }

                else

                {
                    char[] DieList = { 'd', '+', '-' };


                    string[] words = text.Split(DieList);
                    //                e.Channel.SendMessage("numbers in roll:" + words.Length);

                    int mod = 0;
                    int[] DieArray;
                    DieArray = new int[3];
                    DieArray[0] = 0;
                    DieArray[1] = 0;
                    DieArray[2] = 0;

                    string[] IMDARRAY;
                    IMDARRAY = new string[3];
                    IMDARRAY[0] = "";
                    IMDARRAY[1] = "";
                    IMDARRAY[2] = "0";



                    try
                    {

                        // IMDARRAY = text.Split('d', '+', '-').ToArray(IMDARRAY);

                        char[] charSeparators;
                        charSeparators = new char[3];
                        charSeparators[0] = 'd';
                        charSeparators[1] = '+';
                        charSeparators[2] = '-';



                        IMDARRAY = text.Split(charSeparators, StringSplitOptions.None);

                        if (IMDARRAY[0].Length > 9)
                        {
                            e.Channel.SendMessage("die amount exceeds int range");
                            return;
                        }
                        if (IMDARRAY[1].Length > 9)
                        {
                            e.Channel.SendMessage("die value exceeds int range");
                            return;
                        }
                        try
                        {
                            if (IMDARRAY[2].Length > 9)
                            {
                            }
                        }
                        catch
                        {
                        }

                        DieArray = text.Split('d', '+', '-').Select(str => int.Parse(str)).ToArray();
                    }
                    catch (FormatException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }
                    //
                    // Positive Modifier
                    //
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
                        if (DieArray[0] > 500)
                            DieArray[0] = 500;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }
                    //
                    // Negative Modifier
                    //

                    try
                    {
                        if (e.Message.Text.Contains("-"))
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
                        if (DieArray[0] > 500)
                            DieArray[0] = 500;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //                   e.Channel.SendMessage("invalid die");
                        return;
                    }

                    string[] DieString = DieArray.Select(x => x.ToString()).ToArray();
                    string OutputMessage = "";
                    if (mod == 0)
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + ", DC: " + DCres;
                    }
                    else if (mod > 0 && text.Contains("+"))
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + "+" + DieString[2] + ", DC: " + DCres;
                    }
                    else if (mod > 0 && text.Contains("-"))
                    {
                        OutputMessage = "Dice Rolled: " + DieString[0] + "d" + DieString[1] + "-" + DieString[2] + ", DC: " + DCres;
                    }



                    if (DCexists == false)
                    {
                        OutputMessage = OutputMessage.Replace("DC:", "");
                    }
                    e.Channel.SendMessage(OutputMessage);


                    Random rnd = new Random();

                    int roll = 0;
                    int rollSum = 0;
                    int total = 0;
                    int ismodified = 0;
                    int ismultiple = 0;
                    string DieOutput = "";
                    for (int i = 0; i < DieArray[0]; ++i)
                    {
                        try
                        {
                            roll = rnd.Next(1, DieArray[1] + 1);

                            total = roll + mod;
                            if (DieArray[0] == 1 && mod == 0)
                            {

                                e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 0;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] == 1 && mod > 0 && text.Contains("+"))
                            {
                                rollSum = rollSum + roll;
                                e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] > 1 && mod > 0 && text.Contains("+"))
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 1;
                            }
                            else if (DieArray[0] == 1 && mod > 0 && text.Contains("-"))
                            {
                                rollSum = roll - mod;
                                e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 0;
                            }
                            else if (DieArray[0] > 1 && mod > 0 && text.Contains("-"))
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
                                ismodified = 1;
                                ismultiple = 1;
                            }
                            else if (DieArray[0] > 1 && mod == 0)
                            {
                                rollSum = rollSum + roll;
                                DieOutput = DieOutput + roll + ", ";
                                //e.Channel.SendMessage("Rolled .. " + roll);
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
                    try
                    {
                        if (DieOutput.EndsWith(", "))
                        {
                            DieOutput = DieOutput.Remove(DieOutput.Length - 2);
                        }
                        e.Channel.SendMessage(DieOutput);
                    }
                    catch
                    {

                    }
                    int rollTotal = 0;
                    if (ismodified == 1 && ismultiple == 1 && text.Contains("+"))
                    {
                        rollTotal = rollSum + mod;
                        e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + "(" + rollSum + ")" + " + " + DieArray[2] + " = " + rollTotal);
                    }
                    else if (ismodified == 1 && ismultiple == 0 && text.Contains("+"))
                    {
                        rollSum = total;
                        e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + " + " + DieArray[2] + " = " + rollSum);
                    }
                    else if (ismodified == 1 && ismultiple == 1 && text.Contains("-"))
                    {
                        rollTotal = rollSum - mod;
                        e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + "(" + rollSum + ")" + " - " + DieArray[2] + " = " + rollTotal);
                    }
                    else if (ismodified == 1 && ismultiple == 0 && text.Contains("-"))
                    {
                        //rollSum = total;
                        e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + " - " + DieArray[2] + " = " + rollSum);
                    }
                    else if (ismodified == 0 && ismultiple == 1)
                    {
                        e.Channel.SendMessage("Sum .. " + DieString[0] + "d" + DieArray[1] + " = " + rollSum);
                    }
                    //else if (ismodified == 0 && ismultiple == 0)
                    //{
                    //    return;
                    //}

                    int DCFinal = 0;
                    if (roll > 0)
                    {
                        DCFinal = roll;
                    }
                    if (rollSum > 0)
                    {
                        DCFinal = rollSum;
                    }
                    if (rollTotal > 0)
                    {
                        DCFinal = rollTotal;
                    }



                    //e.Channel.SendMessage("roll: " + roll + "\nrollSum: " + rollSum + "\nrollTotal: " + rollTotal + "\nDCFinal: " + DCFinal + "\nDC: " + DCres);
                    try
                    {

                        int DCn = Int32.Parse(DCres);
                        if (roll == 1)
                        {
                            e.Channel.SendMessage("Critical Failure");
                        }
                        else if (roll == DieArray[1])
                        {
                            e.Channel.SendMessage("Critical Success");
                        }
                        else if (DCFinal > DCn)
                        {
                            e.Channel.SendMessage("Passed");
                        }
                        else if (DCn > DCFinal && DCn > 1)
                        {
                            e.Channel.SendMessage("Failed");
                        }
                        else if (DCn == DCFinal)
                        {
                            e.Channel.SendMessage("Player Favour");
                        }

                    }
                    catch
                    { }





                }
                //-----------------------------------------------------------------------------------
                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                //
                //MISC
                //
                //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                //-----------------------------------------------------------------------------------

            }



            if (e.Message.Text == "gibnao")
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=3-0mdbo0Xo0");
            }

            if (e.Message.Text == "!reaction")
            {
                e.Channel.SendMessage("http://i.imgur.com/0SZIUqA.gif");
            }
            if (e.Message.Text.Equals("y tho"))
            {
                e.Channel.SendMessage("http://i.imgur.com/yNlQWRM.jpg");
            }
            if (e.Message.Text.Contains("there is no need to be upset"))
            {
                e.Channel.SendMessage("http://i.imgur.com/Uyzdxlu.gif");
            }
            if (e.Message.Text.Contains("maximum over rustle"))
            {
                e.Channel.SendMessage("https://media.giphy.com/media/MvS6aL7FX0Iz6/giphy.gif");
            }
            //if (e.Message.Text.Contains("pepe"))
            //{
            //    Random rnd = new Random();
            //    var files = Directory.GetFiles(@"pepe\");
            //    string image = files[rnd.Next(files.Length)];




            //    e.Channel.SendFile(image);
            //}
            if (e.Message.Text.Equals("salt"))
            {
                Random rnd = new Random();
                var files = Directory.GetFiles(@"salt\");
                string image = files[rnd.Next(files.Length)];

                e.Channel.SendFile(image);
            }

            //if (e.User.Name == "Onee-chan")
            //{
            //    //if (e.Message.Text.Contains("imgur"))
            //    //{
            //    //    return;
            //    //}
            //    string text = e.Message.Text;
            //    text = text.Replace("senpai", "");
            //    text = text.Replace("@Onee-chan", "Old Man Pompadour");
            //    e.Message.Delete();

            //    e.Channel.SendMessage(text);
            //}
        }
    }
}
