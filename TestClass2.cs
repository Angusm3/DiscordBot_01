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

namespace DiscordBot_01
{
    public class TestClass2
    {
        private DiscordClient TC2;

        public TestClass2()
        {
            TC2 = new DiscordClient();

            TC2.MessageReceived += Bot_MessageReceived;

        }

        public static string SharedString2()
        {
            return "sent message from test class 2";
        }

            

        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            e.Channel.SendMessage("SendMessage test2");

        }
    }
}