using Discord;
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
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

    public class Pompadour
    {
        private DiscordClient AI;

        public Pompadour()
        {
            AI = new DiscordClient();

            AI.ExecuteAndWait(async () =>
            {
                AI.MessageReceived += Bot_MessageReceived;
                await AI.Connect("treeforge2.al@gmail.com", "superbotpassword");
            });



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
#pragma warning disable 0414
        string LoadedFile = "Character not found";
        int msgchance = 12;





        string[] AdjectiveList = { };
        string[] NameList = { };
        string[] NounList = { };
        string[] PronounList = { };
        string[] VerbList = { };
        string[] AdverbList = { };
        int LoadedLists = 0;

        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {

            if (e.Message.IsAuthor) return;
            //-----------------------------------------------------------------------------------
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //
            //AI
            //
            //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            //-----------------------------------------------------------------------------------
            string UserName = e.User.Name;
            string InputText = e.Message.Text;
            string UserPath = @"AI\";




            if (LoadedLists < 5)
            {
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Adjectives
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string AdjectivePath = @"AI\Lists\adjectives";



                string[] FileEntriesAdj = Directory.GetFiles(AdjectivePath);


                string[] FileNames = new string[FileEntriesAdj.Length];
                string[] LineArray = { "" };
                int AdjectiveListLength = 0;

                foreach (string filename in FileEntriesAdj)
                {

                }
                Console.WriteLine("" + FileNames.Length + " files found");
#pragma warning disable CS0219 // Variable is assigned but its value is never used
                int TotalLines = 0;

                for (int i = 0; i < FileEntriesAdj.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesAdj[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        AdjectiveListLength += 1;
                    }



                }

                string[] WordList = new string[AdjectiveListLength];
                AdjectiveList = new string[AdjectiveListLength];
                Console.WriteLine("Length .. " + AdjectiveListLength);
                Console.WriteLine("String Length .. " + WordList.Length);
                int Adjo = 0;
                for (int i = 0; i < FileEntriesAdj.Length; i++)
                {
                    WordList = File.ReadAllLines(FileEntriesAdj[i]);
                    foreach (string s in WordList)
                    {

                        AdjectiveList[Adjo] = s;
                        Adjo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }





                //e.Channel.SendMessage("Adjective List Loaded");

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Names
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string NamePath = @"AI\Lists\names";



                string[] FileEntriesName = Directory.GetFiles(NamePath);


                string[] FileNamesName = new string[FileEntriesName.Length];
                string[] LineArrayName = { "" };
                int NameListLength = 0;

                foreach (string filename in FileEntriesName)
                {

                }
                Console.WriteLine("" + FileNamesName.Length + " files found");
                int TotalLinesName = 0;
                for (int i = 0; i < FileEntriesName.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesName[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        NameListLength += 1;
                    }



                }

                string[] WordListName = new string[NameListLength];
                NameList = new string[NameListLength];
                Console.WriteLine("Length .. " + NameListLength);
                Console.WriteLine("String Length .. " + WordListName.Length);
                int Nameo = 0;
                for (int i = 0; i < FileEntriesName.Length; i++)
                {
                    WordListName = File.ReadAllLines(FileEntriesName[i]);
                    foreach (string s in WordListName)
                    {

                        NameList[Nameo] = s;
                        Nameo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }





                //e.Channel.SendMessage("Name List Loaded");


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Nouns
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string NounPath = @"AI\Lists\nouns";



                string[] FileEntriesNoun = Directory.GetFiles(NounPath);


                string[] FileNouns = new string[FileEntriesNoun.Length];
                string[] LineArrayNoun = { "" };
                int NounListLength = 0;

                foreach (string filenoun in FileEntriesNoun)
                {

                }
                Console.WriteLine("" + FileNouns.Length + " files found");
                int TotalLinesNoun = 0;
                for (int i = 0; i < FileEntriesNoun.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesNoun[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        NounListLength += 1;
                    }



                }

                string[] WordListNoun = new string[NounListLength];
                NounList = new string[NounListLength];
                Console.WriteLine("Length .. " + NounListLength);
                Console.WriteLine("String Length .. " + WordListNoun.Length);
                int Nouno = 0;
                for (int i = 0; i < FileEntriesNoun.Length; i++)
                {
                    WordListNoun = File.ReadAllLines(FileEntriesNoun[i]);
                    foreach (string s in WordListNoun)
                    {

                        NounList[Nouno] = s;
                        Nouno += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");

                }





                //e.Channel.SendMessage("Noun List Loaded");
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Pronouns
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string PronounPath = @"AI\Lists\pronouns";



                string[] FileEntriesPronoun = Directory.GetFiles(PronounPath);


                string[] FilePronouns = new string[FileEntriesPronoun.Length];
                string[] LineArrayPronoun = { "" };
                int PronounListLength = 0;

                foreach (string filepronoun in FileEntriesPronoun)
                {

                }
                Console.WriteLine("" + FilePronouns.Length + " files found");
                int TotalLinesPronoun = 0;
                for (int i = 0; i < FileEntriesPronoun.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesPronoun[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        PronounListLength += 1;
                    }



                }

                string[] WordListPronoun = new string[PronounListLength];
                PronounList = new string[PronounListLength];
                Console.WriteLine("Length .. " + PronounListLength);
                Console.WriteLine("String Length .. " + WordListPronoun.Length);
                int Pronouno = 0;
                for (int i = 0; i < FileEntriesPronoun.Length; i++)
                {
                    WordListPronoun = File.ReadAllLines(FileEntriesPronoun[i]);
                    foreach (string s in WordListPronoun)
                    {

                        PronounList[Pronouno] = s;
                        Pronouno += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");

                }





                //e.Channel.SendMessage("Pronoun List Loaded");


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Verbs
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string VerbPath = @"AI\Lists\verbs";



                string[] FileEntriesVerb = Directory.GetFiles(VerbPath);


                string[] FileVerbs = new string[FileEntriesVerb.Length];
                string[] LineArrayVerb = { "" };
                int VerbListLength = 0;

                foreach (string fileverb in FileEntriesVerb)
                {

                }
                Console.WriteLine("" + FileVerbs.Length + " files found");
                int TotalLinesVerb = 0;
                for (int i = 0; i < FileEntriesVerb.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesVerb[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        VerbListLength += 1;
                    }



                }

                string[] WordListVerb = new string[VerbListLength];
                VerbList = new string[VerbListLength];
                Console.WriteLine("Length .. " + VerbListLength);
                Console.WriteLine("String Length .. " + WordListVerb.Length);
                int Verbo = 0;
                for (int i = 0; i < FileEntriesVerb.Length; i++)
                {
                    WordListVerb = File.ReadAllLines(FileEntriesVerb[i]);
                    foreach (string s in WordListVerb)
                    {

                        VerbList[Verbo] = s;
                        Verbo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }




                //e.Channel.SendMessage("Verb List Loaded");





                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Adverbs
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string AdverbPath = @"AI\Lists\adverbs";



                string[] FileEntriesAdverb = Directory.GetFiles(AdverbPath);


                string[] FileAdverbs = new string[FileEntriesAdverb.Length];
                string[] LineArrayAdverb = { "" };
                int AdverbListLength = 0;

                foreach (string fileadverb in FileEntriesAdverb)
                {

                }
                Console.WriteLine("" + FileAdverbs.Length + " files found");
                int TotalLinesAdverb = 0;
                for (int i = 0; i < FileEntriesAdverb.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesAdverb[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        AdverbListLength += 1;
                    }



                }

                string[] WordListAdverb = new string[AdverbListLength];
                AdverbList = new string[AdverbListLength];
                Console.WriteLine("Length .. " + AdverbListLength);
                Console.WriteLine("String Length .. " + WordListAdverb.Length);
                int Adverbo = 0;
                for (int i = 0; i < FileEntriesAdverb.Length; i++)
                {
                    WordListAdverb = File.ReadAllLines(FileEntriesAdverb[i]);
                    foreach (string s in WordListAdverb)
                    {

                        AdverbList[Adverbo] = s;
                        Adverbo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }





                //e.Channel.SendMessage("Adverb List Loaded");
            }
            //make sure only my messages activate pompadour ai
            if (UserName == "Angus")



                if (File.Exists(UserPath + UserName + ".csv"))
                {

                }
                else if (UserName.Equals("Angus") && !(File.Exists(UserPath + UserName + ".csv")))
                {
                    e.Channel.SendMessage("Creating " + UserName + "...");
                    try
                    {
                        using (FileStream fs = File.Create(UserPath + UserName + ".csv"))
                        {
                            Byte[] info = new UTF8Encoding(true).GetBytes("");

                            fs.Write(info, 0, info.Length);

                            e.Channel.SendMessage("Knowledge file created for .. " + UserName);
                        }
                    }
                    catch
                    {
                        e.Channel.SendMessage("error..");
                    }
                }



            if (File.Exists(UserPath + "Pompadours_Brain" + ".csv"))
            {

            }
            else if (UserName.Equals("Angus") && !(File.Exists(UserPath + "Pompadours_Brain" + ".csv")))
            {
                e.Channel.SendMessage("Creating " + "Pompadours_Brain" + "...");
                try
                {
                    using (FileStream fs = File.Create(UserPath + "Pompadours_Brain" + ".csv"))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("");

                        fs.Write(info, 0, info.Length);

                        e.Channel.SendMessage("Knowledge file created for .. " + "Pompadours_Brain");
                    }
                }
                catch
                {
                    e.Channel.SendMessage("error..");
                }
            }



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



            if (e.Message.Text.Contains("no ") || e.Message.Text.Contains("n't") || e.Message.Text.Contains("not "))
            {
                string path = @"AI\Negative.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.ToLower();
                text = text.Replace("pompadour", "%NAM_");
                text = text.Replace("pomp", "%NAM_");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }



            if (e.Message.Text.Contains("greeting") || e.Message.Text.Contains("hello") || e.Message.Text.Contains("hey") || e.Message.Text.Contains("yo ") || e.Message.Text.Contains("sup ") || e.Message.Text.Contains("hai ") || e.Message.Text.Contains("hi ") || e.Message.Text.Contains("wassap"))
            {
                string path = @"AI\Greetings.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                text = text.ToLower();
                text = text.Replace("pompadour", "%NAM_");
                text = text.Replace("pomp", "%NAM_");
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
            }


















            if (e.Message.Text.Contains("http"))
            {
                string path = @"AI\Links.csv";
                string[] CharacterFile = File.ReadAllLines(path);
                string text = e.Message.Text;
                string[] AIfile = new string[1]
                {
                    text
                };
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(text);
                }
                return;
            }





            if (e.Message.Text.Contains(""))
            {
                string text = "";
                text = e.Message.Text;
                text.ToLower();
                if (text.Contains("pomp"))
                {
                    msgchance = 20;
                }

            }



            if (e.Message.Text.Contains(""))
            {
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
                        msgchance += 8;
                    }
                }
                catch
                {
                    return;
                }

            }

            /* add greetings
             * fix roll overflow
             * recognize name 
             * replace name with %NAM_
             * 
             * 
             * 
             */




















            if (e.Message.Text.Contains("pompadour") || e.Message.Text.Contains("Pompadour") || e.Message.Text.Contains("pomp") || e.Message.Text.Contains("Pomp"))
            {
                string text = e.Message.Text;
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
                        Console.WriteLine("NEGATIVE--delay .. " + smtimer);
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

















            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Word Arrays
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


            string Input = e.Message.Text;
            Input = Input.ToLower();

            string[] SentenceType =
            {
                "interrogative", "declarative", "exclamatory", "imperative"
            };

            

            string[] InputQuestionArray =
            {
                "who", "what", "where", "when", "why", "how", "which", "wherefore", "whatever", "whom", "whose", "wherewith", "whither", "whence"
            };

            string[] QuestionEndInputArray =
            {
                "?"
            };

            string[] SentenceCompoundIdentifierArray =
            {
                ", ", ": ", "; "
            };

            string[] CompoundStatementArray =
            {
                ". ", "?  ", "!  "
            };

            string[] CoordinatingConjunctionArray =
            {
                "for", "and", "nor", "but", "or", "yet", "so"
            };



            string[,] CorrelativeConjunctionArray =
            {
                { "as", "as" },
                { "just so", "so" },
                { "both", "and" },
                { "hardly", "when" },
                { "scarcely", "when" },
                { "either", "or" },
                { "neither", "nor" },
                { "if", "then" },
                { "not", "but" },
                { "what with", "and" },
                { "whether", "or" },
                { "not only", "but also" },
                { "no sooner", "than" },
                { "rather", "than" }
            };

            string[] ConjunctiveAdverbAndArray =
            {
                "also", "besides", "furthermore", "likewise", "moreover", "however", "nevertheless", "nonetheless", "still", "conversely", "instead", "otherwise", "rather"
            };

            string[] ConjunctiveAdverbButArray =
            {
                "however", "nevertheless", "nonetheless", "still", "conversely", "instead", "otherwise", "rather"
            };

            string[] ConjunctiveAdverbSoArray =
            {
                "accordingly", "consequently", "hence", "meanwhile", "then", "therefore", "thus"
            };

            string[] SubordinatingConjunctionConcessionArray =
            {
                "though", "although", "even though", "while"
            };

            string[] SubordinatingConjunctionConditionArray =
            {
                "if", "only if", "unless", "until", "providing that", "assuming that", "assuming", "even if", "in case", "lest"
            };

            string[] SubordinatingConjunctionComparisonArray =
            {
                "than", "rather than", "whether", "as much as", "whereas"
            };

            string[] SubordinatingConjunctionTimeArray =
            {
                "after", "as long as", "as soon as", "before", "by the time", "now that", "once", "since", "til", "till", "until", "when", "whenever", "while"
            };

            string[] SubordinatingConjunctionReasonArray =
            {
                "because", "since", "so that", "in order", "why"
            };

            string[] SubordinatingConjunctionAdjectiveArray =
            {
                "that", "what", "whatever", "which", "whichever"
            };

            string[] SubordinatingConjunctionPronounArray =
            {
                "who", "whoever", "whom", "whomever", "whose"
            };

            string[] SubordinatingConjunctionMannerArray =
            {
                "how", "as though", "as if"
            };

            string[] SubordinatingConjunctionPlaceArray =
            {
                "where", "wherever"
            };
#pragma warning disable 0219











            if (e.Message.Text.Contains("reload lists"))
            {



                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Adjectives
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                string AdjectivePath = @"AI\Lists\adjectives";



                string[] FileEntriesAdj = Directory.GetFiles(AdjectivePath);


                string[] FileNames = new string[FileEntriesAdj.Length];
                string[] LineArray = { "" };
                int AdjectiveListLength = 0;

                foreach (string filename in FileEntriesAdj)
                {

                }
                Console.WriteLine("" + FileNames.Length + " files found");
                int TotalLines = 0;
                for (int i = 0; i < FileEntriesAdj.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesAdj[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        AdjectiveListLength += 1;
                    }



                }

                string[] WordList = new string[AdjectiveListLength];
                AdjectiveList = new string[AdjectiveListLength];
                Console.WriteLine("Length .. " + AdjectiveListLength);
                Console.WriteLine("String Length .. " + WordList.Length);
                int Adjo = 0;
                for (int i = 0; i < FileEntriesAdj.Length; i++)
                {
                    WordList = File.ReadAllLines(FileEntriesAdj[i]);
                    foreach (string s in WordList)
                    {

                        AdjectiveList[Adjo] = s;
                        Adjo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }





                //e.Channel.SendMessage("Adjective List Loaded");

                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Names
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string NamePath = @"AI\Lists\names";



                string[] FileEntriesName = Directory.GetFiles(NamePath);


                string[] FileNamesName = new string[FileEntriesName.Length];
                string[] LineArrayName = { "" };
                int NameListLength = 0;

                foreach (string filename in FileEntriesName)
                {

                }
                Console.WriteLine("" + FileNamesName.Length + " files found");
                int TotalLinesName = 0;
                for (int i = 0; i < FileEntriesName.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesName[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        NameListLength += 1;
                    }



                }

                string[] WordListName = new string[NameListLength];
                NameList = new string[NameListLength];
                Console.WriteLine("Length .. " + NameListLength);
                Console.WriteLine("String Length .. " + WordListName.Length);
                int Nameo = 0;
                for (int i = 0; i < FileEntriesName.Length; i++)
                {
                    WordListName = File.ReadAllLines(FileEntriesName[i]);
                    foreach (string s in WordListName)
                    {

                        NameList[Nameo] = s;
                        Nameo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }





                //e.Channel.SendMessage("Name List Loaded");


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Nouns
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string NounPath = @"AI\Lists\nouns";



                string[] FileEntriesNoun = Directory.GetFiles(NounPath);


                string[] FileNouns = new string[FileEntriesNoun.Length];
                string[] LineArrayNoun = { "" };
                int NounListLength = 0;

                foreach (string filenoun in FileEntriesNoun)
                {

                }
                Console.WriteLine("" + FileNouns.Length + " files found");
                int TotalLinesNoun = 0;
                for (int i = 0; i < FileEntriesNoun.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesNoun[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        NounListLength += 1;
                    }



                }

                string[] WordListNoun = new string[NounListLength];
                NounList = new string[NounListLength];
                Console.WriteLine("Length .. " + NounListLength);
                Console.WriteLine("String Length .. " + WordListNoun.Length);
                int Nouno = 0;
                for (int i = 0; i < FileEntriesNoun.Length; i++)
                {
                    WordListNoun = File.ReadAllLines(FileEntriesNoun[i]);
                    foreach (string s in WordListNoun)
                    {

                        NounList[Nouno] = s;
                        Nouno += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");

                }





                //e.Channel.SendMessage("Noun List Loaded");
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Pronouns
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string PronounPath = @"AI\Lists\pronouns";



                string[] FileEntriesPronoun = Directory.GetFiles(PronounPath);


                string[] FilePronouns = new string[FileEntriesPronoun.Length];
                string[] LineArrayPronoun = { "" };
                int PronounListLength = 0;

                foreach (string filepronoun in FileEntriesPronoun)
                {

                }
                Console.WriteLine("" + FilePronouns.Length + " files found");
                int TotalLinesPronoun = 0;
                for (int i = 0; i < FileEntriesPronoun.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesPronoun[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        PronounListLength += 1;
                    }



                }

                string[] WordListPronoun = new string[PronounListLength];
                PronounList = new string[PronounListLength];
                Console.WriteLine("Length .. " + PronounListLength);
                Console.WriteLine("String Length .. " + WordListPronoun.Length);
                int Pronouno = 0;
                for (int i = 0; i < FileEntriesPronoun.Length; i++)
                {
                    WordListPronoun = File.ReadAllLines(FileEntriesPronoun[i]);
                    foreach (string s in WordListPronoun)
                    {

                        PronounList[Pronouno] = s;
                        Pronouno += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");

                }





                //e.Channel.SendMessage("Pronoun List Loaded");


                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //Load Verbs
                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

                string VerbPath = @"AI\Lists\verbs";



                string[] FileEntriesVerb = Directory.GetFiles(VerbPath);


                string[] FileVerbs = new string[FileEntriesVerb.Length];
                string[] LineArrayVerb = { "" };
                int VerbListLength = 0;

                foreach (string fileverb in FileEntriesVerb)
                {

                }
                Console.WriteLine("" + FileVerbs.Length + " files found");
                int TotalLinesVerb = 0;
                for (int i = 0; i < FileEntriesVerb.Length; i++)
                {
                    string[] CharacterFile = File.ReadAllLines(FileEntriesVerb[i]);
                    foreach (string s in CharacterFile)
                    {
                        //Console.WriteLine(s);
                        VerbListLength += 1;
                    }



                }

                string[] WordListVerb = new string[VerbListLength];
                VerbList = new string[VerbListLength];
                Console.WriteLine("Length .. " + VerbListLength);
                Console.WriteLine("String Length .. " + WordListVerb.Length);
                int Verbo = 0;
                for (int i = 0; i < FileEntriesVerb.Length; i++)
                {
                    WordListVerb = File.ReadAllLines(FileEntriesVerb[i]);
                    foreach (string s in WordListVerb)
                    {

                        VerbList[Verbo] = s;
                        Verbo += 1;
                    }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                }




                //e.Channel.SendMessage("Verb List Loaded");





            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Load Adverbs
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            string AdverbPath = @"AI\Lists\adverbs";



            string[] FileEntriesAdverb = Directory.GetFiles(AdverbPath);


            string[] FileAdverbs = new string[FileEntriesAdverb.Length];
            string[] LineArrayAdverb = { "" };
            int AdverbListLength = 0;

            foreach (string fileadverb in FileEntriesAdverb)
            {

            }
            Console.WriteLine("" + FileAdverbs.Length + " files found");
            int TotalLinesAdverb = 0;
            for (int i = 0; i < FileEntriesAdverb.Length; i++)
            {
                string[] CharacterFile = File.ReadAllLines(FileEntriesAdverb[i]);
                foreach (string s in CharacterFile)
                {
                    //Console.WriteLine(s);
                    AdverbListLength += 1;
                }



            }

            string[] WordListAdverb = new string[AdverbListLength];
            AdverbList = new string[AdverbListLength];
            Console.WriteLine("Length .. " + AdverbListLength);
            Console.WriteLine("String Length .. " + WordListAdverb.Length);
            int Adverbo = 0;
            for (int i = 0; i < FileEntriesAdverb.Length; i++)
            {
                WordListAdverb = File.ReadAllLines(FileEntriesAdverb[i]);
                foreach (string s in WordListAdverb)
                {

                    AdverbList[Adverbo] = s;
                    Adverbo += 1;
                }
                    LoadedLists += 1;
                    Console.WriteLine("Loaded .. " + LoadedLists + " ");
                    if ((LoadedLists > 2))
                    {
                        e.Channel.SendMessage("" + LoadedLists + " Files Loaded");
                    }
                }





            //e.Channel.SendMessage("Adverb List Loaded");
    }


            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Response Arrays
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            string[] AuxiliaryVerbList = { "be", "can", "could", "dare", "do", "have", "may", "might", "must", "need", "ought", "shall", "should", "will", "would" };
            string[] RespondYes =
            {

            };




            //Disable string unused warning

            string KeyWord = "unknown";
            string InputType = "";
            string InputSentenceType = "";
            string InputSentenceVerb = "";
            string InputSentenceSubject = "";
            string InputSentencePredicate = "";
            string InputSentenceConjunction = "";
            string InputSentenceAdjective = "";
            string InputSentenceNoun = "";
            string InputSentencePronoun = "";
            string InputSentenceAdverb = "";
            string InputSentenceAuxiliaryVerb = "";
            string QuestionType = "no question";
            string MyName = "pompadour";
            string YourName = "";
            bool PompadourCalled = false;




            string LetterI = "";
            if (e.Message.Text.Contains("I"))
            {
                LetterI = "I";
            }
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Identify Interrogative type
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (Input.Contains(MyName))
            {
                PompadourCalled = true;
                bool IsQuestion = false;
                Input = Input.Replace("pompadour ", "");
                Input = Input.Replace("pompadour", "");
                if (Input.Contains("?"))
                {
                    Input = Input.Replace("?", "");
                    IsQuestion = true;
                }
                e.Channel.SendMessage("My name was mentioned - Reading Sentence...");

                string[] InputArray = Input.Split(' ');


                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < AdjectiveList.Length; o++)
                    {
                        if (InputArray[i].Equals(AdjectiveList[o]))
                        {
                            InputSentenceAdjective = InputSentenceAdjective + "," + AdjectiveList[o];

                            Console.WriteLine(AdjectiveList[o]);
                        }
                    }
                }


                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < NounList.Length; o++)
                    {
                        if (InputArray[i].Equals(NounList[o]))
                        {
                            InputSentenceNoun = InputSentenceNoun + "," + NounList[o];

                            Console.WriteLine(NounList[o]);
                        }
                    }
                }


                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < PronounList.Length; o++)
                    {
                        if (InputArray[i].Equals(PronounList[o]))
                        {
                            InputSentencePronoun = InputSentencePronoun + "," + PronounList[o];

                            Console.WriteLine(PronounList[o]);
                        }
                    }
                }



                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < VerbList.Length; o++)
                    {
                        if (InputArray[i].Equals(VerbList[o]))
                        {
                            InputSentenceVerb = InputSentenceVerb + "," + VerbList[o];

                            Console.WriteLine(VerbList[o]);
                        }
                    }
                }


                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < AdverbList.Length; o++)
                    {
                        if (InputArray[i].Equals(AdverbList[o]))
                        {
                            InputSentenceAdverb = InputSentenceAdverb + "," + AdverbList[o];

                            Console.WriteLine(AdverbList[o]);
                        }
                    }
                }

                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < InputQuestionArray.Length; o++)
                    {
                        if (InputArray[i].Equals(InputQuestionArray[o]))
                        {
                            QuestionType = InputArray[i];

                            Console.WriteLine(InputQuestionArray[o]);
                            IsQuestion = true;
                        }
                    }
                }

                for (int i = 0; i < InputArray.Length; i++)
                {
                    for (int o = 0; o < AuxiliaryVerbList.Length; o++)
                    {
                        if (InputArray[i].Equals(AuxiliaryVerbList[o]))
                        {
                            InputSentenceAuxiliaryVerb = InputSentenceAuxiliaryVerb + "," + AuxiliaryVerbList[o];

                            Console.WriteLine(AuxiliaryVerbList[o]);
                        }
                    }
                }



                if (InputSentenceNoun == InputSentencePronoun)
                {
                    InputSentenceSubject = InputSentenceNoun;
                }
                if (LetterI.Equals("I") || InputSentenceNoun.Contains("me") || InputSentenceNoun.Contains("myself"))
                {
                    InputSentenceSubject = "User " + e.Message.User;
                }
                if (InputSentenceNoun.Contains("you"))
                {
                    InputSentenceSubject = "me";
                }




                if (IsQuestion == true)
                {
                    if (QuestionType.Equals("who"))
                    {
                        QuestionType = "someone";
                    }
                    if (QuestionType.Equals("what"))
                    {
                        QuestionType = "something";
                    }
                    if (QuestionType.Equals("why"))
                    {
                        QuestionType = "reason";
                    }
                    if (QuestionType.Equals("where"))
                    {
                        QuestionType = "location";
                    }
                    if (QuestionType.Equals("when"))
                    {
                        QuestionType = "time";
                    }
                    if (QuestionType.Equals("how"))
                    {
                        QuestionType = "ability";
                        if (Input.Contains("are"))
                        {
                            QuestionType = "status";
                        }
                    }
                    if (QuestionType.Equals("do"))
                    {
                        QuestionType = "knowledge/emotion";
                    }
                }

                string Output = "";
                string OutputSubject = "";
                string OutputAdjective = "";
                string OutputNoun = "";
                string OutputPronoun = "";
                string OutputVerb = "";
                string OutputAdverb = "";
                string OutputAuxiliaryVerb = "";
                string OutputMood = "";



                Random rnd = new Random();
                int MoodRoll = rnd.Next(1, 4);
                string[] MoodArray = { "fine", "alright", "good", "bad" };

                if (InputSentenceSubject.Contains("me"))
                {
                    OutputSubject = "I";
                }
                if (InputSentenceAdjective.Contains("feeling"))
                {
                    OutputAdjective = "feeling";
                }
                if (InputSentenceVerb.Contains("are"))
                {
                    OutputVerb = "are";
                    if (OutputSubject.Equals("I"))
                    {
                        OutputVerb = "am";
                    }
                }
                if (InputSentenceAdjective.Contains("feeling"))
                {
                    OutputMood = MoodArray[MoodRoll];
                }







































                Output = OutputSubject + " " + OutputVerb + " " + OutputMood;



                string PreOut = "";
                PreOut = "Input was: " + Input + "\n" + "Adjective: " + InputSentenceAdjective + "\n" + "Noun: " + InputSentenceNoun + "\n" + "Pronoun: " + InputSentencePronoun + "\n" + "Verb: " + InputSentenceVerb + "\n" + "Adverb: " + InputSentenceAdverb + "\n" + "Auxiliary Verb(s): " + InputSentenceAuxiliaryVerb;
                e.Channel.SendMessage(PreOut);

                e.Channel.SendMessage("Subject is .. " + InputSentenceSubject + " .. ?");
                //e.Channel.SendMessage("Sentence Type .. " + InputSentenceType + " .. ?");
                //if (IsQuestion)
                //{
                //    e.Channel.SendMessage("Question is about: " + QuestionType);
                //}

                e.Channel.SendMessage("Output response: " + Output);


            }










































        }
    }
}
