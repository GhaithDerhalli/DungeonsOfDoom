using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    internal class Mage : Monster
    {
        public Mage(string name): base(name)
        {

        }
        public override void Hit(Creature creatureToBeat)
        {
            if (creatureToBeat.Health >= (Health*2))
            {
                Power = 1;
                creatureToBeat.Health -= Power;
                
            }
            else
                Power = 5;
            creatureToBeat.Health -= Power;
        }
    }
}
