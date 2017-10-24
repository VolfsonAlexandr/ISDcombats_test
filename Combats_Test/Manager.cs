using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combats_Test
{
    static class Manager
    {
        static private int State;

        static public bool IsEnd { get; set; }

        static public int Round;

        static public Gameform gameform;
        static public List<Gamer> Gamers {get; set;}

        static public PartOfBody[] PartsOfBody;

        static public Gamer AttakingGamer()
        {
            return Gamers[State];
        }

        static public Gamer DefensingGamer()
        {
            return Gamers[1 - State];
        }
        static public Label HpLabelForDG()
        {
            return gameform.HpLabels[1 - State];
        }

        static public ProgressBar HpProgressBarForDG()
        {
            return gameform.HpProgressBars[1 - State];
        }

        static public ComboBox ComboboxForSelect()
        {
            return gameform.Comboboxes[1 - State];
        }
        static public PartOfBody SelectedPartOfBody()
        {
            return (PartOfBody)ComboboxForSelect().SelectedIndex;
        }
        static public string MessagesBeforeRound()
        {
            return new[] { "Вы защищаетесь. Выберите часть своего тела(слева) для защиты", "Вы Нападаете. Выберите часть тела противника(справа) для нападения" }[1 - State];
        }

        static public string TextsOnButton()
        {
            return new[] { "Принять удар", "Нанести удар" }[1 - State];
        }

        static public string MessagesAfterRoundBlock ()
        {
            return new []{"Вы заблокировали удар противника","Противник заблокировал Ваш удар"}[1 - State];
        }

        static public string MessagesAfterRoundWound()
        {
            return new[] { "Вам нанесли урон", "Вы нанесли урон" }[1 - State];
        }

        static public string MessagesAfterRoundDeath()
        {
            return new[] { "Вы мертвы! Вы проиграли!", "Противник мертв! Вы победили!" }[1 - State];
        }

        static public void SavePartOfBody()
        {
            PartsOfBody[1 - State] = SelectedPartOfBody();
            PartsOfBody[State] = (PartOfBody)((new Random()).Next(3));
            DefensingGamer().SetBlock(PartsOfBody[0]);
        }

        static public void Battle()
        {
            DefensingGamer().GetHit(PartsOfBody[1]);
        }

        static public void SetEventHandlers()
        {
            for (int i = 0; i < 2; i++)
            {
                Gamers[i].onBlock += gameform.Block;
                Gamers[i].onWound += gameform.Wound;
                Gamers[i].onDeath += gameform.Death;
            }
        }

        static Manager()
        {
            Gamers = new List<Gamer>();
            State = 1;
            PartsOfBody = new PartOfBody[2];
        }
        static public void CreateGamers(string name1, string name2)
        {
            Gamers.Clear();
            Gamers.Add(new Gamer(name1));
            Gamers.Add(new Gamer(name2));
        }

        static public void Revers()
        {
            State = 1 - State;
        }
    }
}
