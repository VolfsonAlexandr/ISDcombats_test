using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combats_Test
{
    public enum PartOfBody
    {
        Голова,
        Корпус,
        Ноги
    }


    public class Gamer
    {
        public delegate void GameEvent(Gamer sender, GamerArgs e);

        public event GameEvent onBlock;

        public event GameEvent onWound;

        public event GameEvent onDeath;

        public string Name { get; set; }
        public PartOfBody Blocked { get; set; }

        public int Hp { get; set; }
        public Gamer(string name)
        {
            this.Name = name;
            this.Hp = 100;
            
        }

        public void GetHit(PartOfBody pob)
        {
            if (pob == Blocked)
                onBlock(this, new GamerArgs(this.Name, this.Hp));
            else
            {
                this.Hp -= 20;
                onWound(this, new GamerArgs(this.Name, this.Hp));
                if (this.Hp <= 0)
                onDeath(this, new GamerArgs(this.Name, this.Hp));
            }
        }

        public void SetBlock(PartOfBody pob)
        {
            Blocked = pob;
        }
    }
}
