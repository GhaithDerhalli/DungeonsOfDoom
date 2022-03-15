using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    internal class Trap: Item
    {
        public Trap(string name): base(name)
        {

        }
        
        public override void Bonus(Creature player)
        {
            Random rnd = new Random();
            var random = rnd.Next(1,3);
            if (random==1)
            {
                player.Power -= 2;
            }
            else
                player.Health -= 3;
        }
    }
}
