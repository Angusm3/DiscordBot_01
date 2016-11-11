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
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;


namespace DiscordBot_01
{
    public class Program
    {
        private DiscordClient PRG;

        public Program()
        {
            PRG = new DiscordClient();

            PRG.ExecuteAndWait(async () =>
            {
                PRG.MessageReceived += Bot_MessageReceived;
                await PRG.Connect("treeforge2.al@gmail.com", "superbotpassword");
            });



        }

        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {

            
            if (e.User.Name.Equals("Angus" ) || (e.User.Name.Equals("Hikari")) || (e.User.Name.Equals("Ljnd")))
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





        }






        }
    }