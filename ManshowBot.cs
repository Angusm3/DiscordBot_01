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

            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //USER EXCEPTIONS
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------
            if (e.Message.IsAuthor) return;
            if (e.Message.User.Equals("RecCom1138")) return;
            //if (e.Message.User.Equals("Angus")) return;
            if (e.User.Name.Equals("Angus") || (e.User.Name.Equals("Hikari")) || (e.User.Name.Equals("Ljnd")))
            {
                if (e.Message.Equals("MainBotMode"))
                {
                    ManshowBot bot = new DiscordBot_01.ManshowBot();
                }
                if (e.Message.Equals("DiceBotMode"))
                {
                    DiceRoll DR = new DiscordBot_01.DiceRoll();
                }
                if (e.Message.Equals("ExperimentalBotMode"))
                {
                    Pompadour AI = new DiscordBot_01.Pompadour();
                }
                if (e.Message.Equals("HibernateMode"))
                {
                    Program PRG = new DiscordBot_01.Program();
                }
            }
            else return;





            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //INPUT PARSE
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            string messagetext = e.Message.Text;
            string messageusername = e.Message.User.ToString();
            string messagetime = e.Message.Timestamp.ToString();

            messagetext = messagetext.ToLower();
            string[] usernick = messageusername.Split('#');
            string messageuser = usernick[0];
            string messageusernumber = usernick[1];

            string consoleout = messagetime + " .. " + messageuser + " .. " + messagetext;


            Console.WriteLine(consoleout);



            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //INPUT EXCEPTIONS
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------

            if (e.Message.Text.Contains("http")) return;
            if (e.Message.Text.StartsWith("~")) return;


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
            //USER SCAN
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------



            if (e.Message.Text.StartsWith(""))
            {

                string text = messagetext;

                //if text contains 'change'  'add'  'whatever'  then string function then remove it and use function for string starts after finding name
                //string function;

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Initializing files array profiles[]
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string path = @"profiles\";
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

                for (int i = 0; i < ProfileCount; i++)
                {

                    if (text.Contains(profiles[i]))
                    {
                        LoadedFile = profiles[i];
                    }

                }



                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Profile Creation
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


                if (!(File.Exists(path + messageuser + ".csv")))
                {
                    Console.WriteLine("Creating " + messageuser + "...");
                    try
                    {
                        using (FileStream fs = File.Create(path + messageuser + ".csv"))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes("");

                            fs.Write(info, 0, info.Length);

                            Console.WriteLine("Profile created for " + messageuser);
                        }
                    }
                    catch
                    {
                        e.Channel.SendMessage("error..");
                    }
                }


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Profile Writing
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (File.Exists(path + messageuser + ".csv"))
                {
                    string file = path + messageuser + ".csv";
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(messagetext);
                    }

                }


            }




            if (messagetext.Contains("pomp"))
            {
                string text = messagetext;
                text.ToLower();
                //  Console.WriteLine(text);

                if (text.Contains("shut") || text.Contains("stop") || text.Contains("stupid") || text.Contains("bad") || text.Contains("ultron"))
                {
                    string path = @"AI\Negative.csv";
                    string[] outputline = File.ReadAllLines(path);
                    var doclength = File.ReadAllLines(path).Length;
                    Random rnd = new Random();

                    int roll2 = rnd.Next(1, doclength + 1);
                    string output = "";


                    try
                    {
                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        int rdtimer = (e.Message.Text.Length * 150) + 2000;
                        int smtimer = (outputline[roll2].Length) * 50;
                        Thread.Sleep(rdtimer);
                        e.Channel.SendIsTyping();
                        Thread.Sleep(smtimer);
                        e.Channel.SendMessage(outputline[roll2]);
                    }
                    catch
                    {
                        return;
                    }
                }



                if (text.Contains("greeting") || text.Contains("hello") || text.Contains("hey") || text.Contains("yo") || text.Contains("sup") || text.Contains("hai") || text.Contains("hi") || text.Contains("wassap"))
                {
                    string path = @"AI\Greetings.csv";
                    string[] outputline = File.ReadAllLines(path);
                    var doclength = File.ReadAllLines(path).Length;
                    msgchance -= 1;
                    Console.WriteLine("GREET .. " + msgchance);

                    Random rnd = new Random();

                    int roll = rnd.Next(1, msgchance + 1);
                    int roll2 = rnd.Next(1, doclength + 1);
                    string output = "";


                    try
                    {
                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        int rdtimer = (e.Message.Text.Length * 150) + 1000;
                        int smtimer = (outputline[roll2].Length) * 50;
                        Thread.Sleep(rdtimer);
                        e.Channel.SendIsTyping();
                        Thread.Sleep(smtimer);
                        Console.WriteLine("GREETING--delay .. " + smtimer);
                        text = outputline[roll2];
                        text = text.Replace("%NAM_", e.User.Name);
                        Console.WriteLine(text);
                        e.Channel.SendMessage(text);

                    }
                    catch
                    {
                        return;
                    }
                }



                if (text.Contains("are you") || text.Contains("what is"))
                {
                    string newfile = @"AI\Response1.csv";

                    if (text.StartsWith("create "))
                    {

                        if (File.Exists(newfile))
                        {
                            string path = newfile;
                            string[] outputline = File.ReadAllLines(path);
                            var doclength = File.ReadAllLines(path).Length;
                            msgchance -= 1;
                            Console.WriteLine("RESPONSE1 .. " + msgchance);

                            Random rnd = new Random();

                            int roll = rnd.Next(1, msgchance + 1);
                            int roll2 = rnd.Next(1, doclength + 1);
                            string output = "";


                            try
                            {
                                output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                                int rdtimer = (e.Message.Text.Length * 150) + 1000;
                                int smtimer = (outputline[roll2].Length) * 50;
                                Thread.Sleep(rdtimer);
                                e.Channel.SendIsTyping();
                                Thread.Sleep(smtimer);
                                Console.WriteLine("RESPONSE1--delay .. " + smtimer);
                                text = outputline[roll2];
                                text = text.Replace("%NAM_", e.User.Name);
                                Console.WriteLine(text);
                                e.Channel.SendMessage(text);

                            }
                            catch
                            {
                                return;
                            }
                        }
                        else
                        {
                            try
                            {
                                using (FileStream fs = File.Create(newfile))
                                {
                                    Byte[] info = new UTF8Encoding(true).GetBytes("");

                                    fs.Write(info, 0, info.Length);


                                }
                            }
                            catch
                            {
                                e.Channel.SendMessage("error");
                                return;
                            }

                        }
                    }
                }
            }




            if (e.Message.Text.Contains(""))
            {


                if (File.Exists(@"AI\PompadourAI.csv"))
                {
                    string file = @"AI\PompadourAI.csv";
                    using (StreamWriter sw = File.AppendText(file))
                    {
                        sw.WriteLine(messagetext);
                    }

                }
                string path = @"AI\PompadourAI.csv";
                string[] outputline = File.ReadAllLines(path);
                var doclength = File.ReadAllLines(path).Length;
                msgchance -= 1;
                //Console.WriteLine("NML .. "+msgchance);

                Random rnd = new Random();

                int roll = rnd.Next(1, msgchance + 1);
                int roll2 = rnd.Next(1, doclength + 1);
                string output = "";


                try
                {
                    if (roll == 1)
                    {


                        output = System.IO.File.ReadLines(path).Skip(roll2).Take(1).First();
                        int rdtimer = (e.Message.Text.Length * 150) + 2000;
                        int smtimer = (outputline[roll2].Length) * 50;
                        Thread.Sleep(rdtimer);
                        e.Channel.SendIsTyping();
                        Thread.Sleep(smtimer);
                        // Console.WriteLine("delay .. " + smtimer);
                        e.Channel.SendMessage(outputline[roll2]);
                        msgchance += 4;
                    }
                }
                catch
                {
                    return;
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



