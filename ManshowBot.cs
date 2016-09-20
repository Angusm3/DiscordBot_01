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
    public class ManshowBot
    {
        private DiscordClient bot;

        public ManshowBot()
        {
            bot = new DiscordClient();



            try
            {

                bot.ExecuteAndWait(async () =>
                {
                    bot.MessageReceived += Bot_MessageReceived;
                    await bot.Connect("treeforge2.al@gmail.com", "superbotpassword");




                //bot.UsingAudio(x =>
                //{
                //    x.Mode = AudioMode.Outgoing;
                //});
                //var VoiceChannel = bot.FindServers("Manshow 2X").FirstOrDefault().VoiceChannels.FirstOrDefault();
                //var vbot = await bot.GetService<AudioService>()
                //    .Join(VoiceChannel);


            });
            }
            catch {
                Console.WriteLine("Strange Error");
                    }

        }


        public struct Data
        {
            public Data(int row, string title, string value)
            {
                IntegerData = row;
                StringData = title;
                StringData2 = value;
            }

            public int IntegerData { get; private set; }
            public string StringData { get; private set; }
            public string StringData2 { get; private set; }
        }
        string LoadedFile = "Character not found";
        int msgchance = 12;


        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            if (e.Message.IsAuthor) return;


            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //HELP
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------


            if (e.Message.Text == "!help")
            {
                e.Channel.SendMessage(e.User.Mention + "\nCurrent Command List:\n!help\nroll XdY+Z or XdYkZ\nPClist\nPC *command*\nwiki |edition, if none leave out| *page name*\nPClist\n+ some hidden commands");
            }


            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //CHARACTERS
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------



            if (e.Message.Text.StartsWith("PC "))
            {
                string text = e.Message.Text;

                //if text contains 'change'  'add'  'whatever'  then string function then remove it and use function for string starts after finding name
                //string function;

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Initializing files array profiles[]
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string path = @"Files\";
                int ProfileCount;

                int q = 0;
                var charfiles = Directory.EnumerateFiles(path, "*.*");
                foreach (string currentFile in charfiles)
                {
                    string fileName = currentFile.Substring(path.Length);

                    q += 1;
                }

                string[] profiles = new string[q];
                q = 0;
                foreach (string currentFile in charfiles)
                {
                    string fileName = currentFile.Substring(path.Length);
                    profiles[q] = fileName;
                    q += 1;
                }

                ProfileCount = profiles.Length;

                for (int i = 0; i < ProfileCount; i++)
                {
                    profiles[i] = profiles[i].Replace(".csv", "");

                }
                string FileMessage = "";
                for (int i = 0; i < ProfileCount; i++)
                {

                    if (text.Contains(profiles[i]))
                    {

                        LoadedFile = profiles[i];
                        FileMessage = "Loaded .. ";

                    }
  
                }



                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //LoadedFile Exceptions
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string NewFileMessage = FileMessage;
                string NewLoadedFile = LoadedFile;
                string CharacterName = LoadedFile;
                if (text.Contains("list"))
                {

                    NewFileMessage = "";
                    NewLoadedFile = "Character List:";
                }
                if (text.Contains("stats"))
                {

                    NewFileMessage = "";
                    NewLoadedFile = "Stats for " + NewLoadedFile;
                }
                string FinalMessage = FileMessage + NewLoadedFile;
                if (!(FinalMessage.Contains("Character")))
                {
                    e.Channel.SendMessage(FileMessage + NewLoadedFile);
                }









                TextInfo Adjust = new CultureInfo("en-US", false).TextInfo;

                text = text.Replace("PC ", "");


                string[] Character =
                {
                    "Name", "level", "exp", "str", "int", "dex", "wis", "con", "cha"
                };


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Stats
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (text.Contains("stats") && text.Contains(CharacterName))
                {

                    //===========================
                    //Initializing File Read
                    //===========================
                    string[] CharacterFile = File.ReadAllLines(path + CharacterName + ".csv");
                    foreach (string s in CharacterFile)
                    {
                        Console.WriteLine(s);
                    }















                    text = text.Replace("stats", "");
                    text = text.Replace(" ", "");
                    text = text.Replace(CharacterName, "");

                    // name = 0, level = 1, exp = 2,

                    string[] CharacterStats = new string[9];
                    string CharacterText;
                    int StatLine = 0;
                    int StatTake = 1;
                    int overflowstopper = 0;

                            string CharacterTextAll = System.IO.File.ReadAllText(path + CharacterName + ".csv");
                            e.Channel.SendMessage(CharacterTextAll);
                            overflowstopper = 1;




                    CharacterText = System.IO.File.ReadLines(path + CharacterName + ".csv").Skip(StatLine).Take(StatTake).First();
                    if (overflowstopper == 0)
                    {
                        e.Channel.SendMessage(CharacterText);
                    }







                    if (text.Contains("write"))
                    {


                        string FileName = path + CharacterName + ".csv";
                        text = text.Replace("write", "");



                        //NAME
                        string NewName = "";
                        if (text.Contains("name"))
                        {
                            NewName = text.Replace("name", "");
                            text = text.Replace(NewName, "");
                        }
                        //LEVEL
                        string NewLevel = "";
                        if (text.Contains("level"))
                        {
                            NewLevel = text.Replace("level", "");
                            text = text.Replace(NewLevel, "");
                        }
                        //EXP
                        string NewExp = "";
                        if (text.Contains("exp"))
                        {
                            NewExp = text.Replace("exp", "");
                            text = text.Replace(NewExp, "");
                        }
                        //STR
                        string NewStr = "";
                        if (text.Contains("str"))
                        {
                            NewStr = text.Replace("str", "");
                            text = text.Replace(NewStr, "");
                        }
                        //INT
                        string NewInt = "";
                        if (text.Contains("int"))
                        {
                            NewInt = text.Replace("int", "");
                            text = text.Replace(NewInt, "");
                        }
                        //DEX
                        string NewDex = "";
                        if (text.Contains("dex"))
                        {
                            NewDex = text.Replace("dex", "");
                            text = text.Replace(NewDex, "");
                        }
                        //WIS
                        string NewWis = "";
                        if (text.Contains("wis"))
                        {
                            NewWis = text.Replace("wis", "");
                            text = text.Replace(NewWis, "");
                        }
                        //CON
                        string NewCon = "";
                        if (text.Contains("con"))
                        {
                            NewCon = text.Replace("con", "");
                            text = text.Replace(NewCon, "");
                        }
                        //CHA
                        string NewCha = "";
                        if (text.Contains("cha"))
                        {
                            NewCha = text.Replace("cha", "");
                            text = text.Replace(NewCha, "");
                        }
                        //e.Channel.SendMessage("current string .. " + text);



                        switch (text)
                        {
                            case "name":

                                CharacterFile[0] = "Name: " + NewName;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "level":
                                CharacterFile[1] = "Level: " + NewLevel;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "exp":
                                CharacterFile[2] = "Experience: " + NewExp;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "str":
                                CharacterFile[3] = "Strength:      " + NewStr;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "int":
                                CharacterFile[4] = "Intelligence:  " + NewInt;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "dex":
                                CharacterFile[5] = "Dexterity:     " + NewDex;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "wis":
                                CharacterFile[6] = "Wisdom:        " + NewWis;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "con":
                                CharacterFile[7] = "Constitution:  " + NewCon;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                            case "cha":
                                CharacterFile[8] = "Charisma:      " + NewCha;
                                File.WriteAllLines(FileName, CharacterFile, Encoding.UTF8);
                                break;
                        }
                    }



                }
















                if (text.Equals("list"))
                {

                    for (int i = 0; i < ProfileCount; i++)
                    {
                        profiles[i] = profiles[i].Replace(".csv", "");
                        e.Channel.SendMessage(profiles[i]);

                    }
                }
























                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Create
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (text.StartsWith("create "))
                {

                    text = text.Replace("create ", "");
                    string filename = Adjust.ToLower(text);
                    string newfile = path + filename + ".csv";
                    if (File.Exists(path + filename + ".csv"))
                    {
                        e.Channel.SendMessage(text + " already exists");
                    }
                   else
                    {
                        e.Channel.SendMessage("Creating " + text + "...");
                        try
                        {
                            using (FileStream fs = File.Create(newfile))
                            {
                                Byte[] info = new UTF8Encoding(true).GetBytes("");

                                fs.Write(info, 0, info.Length);


                                e.Channel.SendMessage("PC created .. " + filename);
                            }
                        }
                        catch
                        {
                            e.Channel.SendMessage("error");
                            return;
                        }


                        using (System.IO.StreamWriter file =
                            new System.IO.StreamWriter(newfile))

                        {
                            foreach (string element in Character)
                            {
                                string estr = element.ToString();
                                file.WriteLine(estr);
                            }

                        }

                    }

                }


                //foreach (int Element in DieResult)
                //{
                //    string ElementString = Element.ToString();
                //    e.Channel.SendMessage(ElementString);
                //}



            }



































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

           

















            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //DICE
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

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

                    foreach (int Element in DieResult)
                    {
                        ElementString = Element.ToString();
                        e.Channel.SendMessage(ElementString);
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
                    try
                    {
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
                    {}
                    




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
            if (e.Message.Text.Contains("pepe"))
            {
                Random rnd = new Random();
                var files = Directory.GetFiles(@"pepe\");
                string image = files[rnd.Next(files.Length)];




                e.Channel.SendFile(image);
            }
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

            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //Pompadour dumb ai
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------


            if (e.User.Name == "MinusVitaminC")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }

            if (e.User.Name == "Wedge")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
            if (e.User.Name == "hikari")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
            if (e.User.Name == "KillaMaaki")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.Replace("senpai", "");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }
            if (e.User.Name == "Hindbodes")
            {
                string path = @"AI\PompadourAI.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.Replace("senpai", "");
                if (text.StartsWith("~"))
                {
                    text = "";
                }
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }







            if (e.Message.Text.Contains(""))
            {
                string path = @"AI\PompadourAI.csv";
                string[] outputline = File.ReadAllLines(path);
                var doclength = File.ReadAllLines(path).Length;
                msgchance -= 1;
                Console.WriteLine(msgchance);

                Random rnd = new Random();

                int roll = rnd.Next(1, msgchance + 1);
                int roll2 = rnd.Next(1, doclength + 1);
                string output = "";


                try
                {
                    if (roll == 1)
                    {


                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        int smtimer = (outputline[roll2].Length) * 50;
                        e.Channel.SendIsTyping();
                        Thread.Sleep(smtimer);
                        Console.WriteLine("delay .. " + smtimer);
                        e.Channel.SendMessage(outputline[roll2]);
                        msgchance += 8;
                    }
                }
                catch
                {
                    return;
                }




                if (e.Message.Text.Contains("pompadour"))
                {
                    if (e.Message.Text.Contains("shut up"))
                    {

                    }
                }
            }

            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //Misc. functions
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            if (e.Message.Text.Contains("the best"))
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=5vRlJrkxsqo");
            }
            if (e.Message.Text.Contains("bustin'"))
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=0tdyU_gW6WE");
            }
            if (e.Message.Text.Contains("and they don't stop coming"))
            {
                e.Channel.SendMessage("https://www.youtube.com/watch?v=8ZhYNWwbJpQ");
            }
            string[] Crews =
            {
                "https://www.youtube.com/watch?v=6Ajhzlq42f0",
                "https://www.youtube.com/watch?v=fU3jfk-O7L0",
                "https://www.youtube.com/watch?v=yZ15vCGuvH0",
                "https://www.youtube.com/watch?v=Wt7sCW9_DOc",
                "https://www.youtube.com/watch?v=X1M69l7ZGlw",
                "https://www.youtube.com/watch?v=25IhfWRO4Rk",
                "https://www.youtube.com/watch?v=fI4ZhW1anKY",
                "https://www.youtube.com/watch?v=RmEQ9iPQVrE",
                "https://www.youtube.com/watch?v=QFAmaiZxLQw",
                "https://www.youtube.com/watch?v=2tv-P28jVCQ",
                "https://www.youtube.com/watch?v=yYFpVXX-nvA",
                "https://www.youtube.com/watch?v=Bn62N5n3TDw"
            };
            if (e.Message.Text.Equals("old spice"))
            {
                Random rnd = new Random();
                int roll = rnd.Next(1, Crews.Length);
                e.Channel.SendMessage(Crews[roll]);
            }



        }
    }
}



