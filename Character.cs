using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot_01
{

    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //CLASS FOR CHARACTERS
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }


        public int Int { get; set; }
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Wis { get; set; }
        public int Con { get; set; }
        public int Cha { get; set; }

        public int Exp { get; set; }

    }
}
