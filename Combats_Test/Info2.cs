using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combats_Test
{
    static class Info
    {
        //info2
        public static Gamer[] Gamers { get; set; }
        public static int State { get; set; }

        public static string [] MessagesBeforeRound { get; set; }

        public static string[] MessagesAfterRound { get; set; }

        public static string[] Buttontexts { get; set; }
        static Info()
        {
            Gamers = new Gamer[2];
            State = 0;
            MessagesBeforeRound = new[] { "Вы защищаетесь. Выберите часть своего тела(слева) для защиты", "Вы Нападаете. Выберите часть тела противника(справа) для нападения" };
            MessagesAfterRound = new[] { "", "" };
            Buttontexts = new[] { "Принять удар", "Нанести удар"};
        }
        public static void CreateGamers(string name1, string name2)
        {
            Gamers[0] = new Gamer(name1);
            Gamers[1] = new Gamer(name2);
        }
    }
}
