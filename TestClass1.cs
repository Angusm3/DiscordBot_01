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
    public class TestClass1
    {
        private DiscordClient TC1;

        public TestClass1()
        {
            TC1 = new DiscordClient();

            //TC1.ExecuteAndWait(async () =>
            //{
                TC1.MessageReceived += Bot_MessageReceived;
            //        await TC1.Connect("treeforge2.al@gmail.com", "superbotpassword");
            //    });
        }

        public void Bot_MessageReceived(object sender, MessageEventArgs e)
        {
            e.Channel.SendMessage("sent message from test class 1");

        }
    }
}
