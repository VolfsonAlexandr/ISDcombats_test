using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combats_Test
{
    public class GamerArgs: EventArgs
    {
        public string name;
        public int hp;


        public GamerArgs(string name, int hp)
        {
            this.name = name;
            this.hp = hp;
        }
    }
}
