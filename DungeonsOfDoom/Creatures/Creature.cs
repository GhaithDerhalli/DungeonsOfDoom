using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract public class Creature
    {
        
        public Queue<Item> Backpack { get; set; }

        public virtual void Hit(Creature creatureToBeat)
        {
            creatureToBeat.Health -= Power;
        }
        public Creature(int health, int power)
        {
            Health = health;
            Power = power;
            Backpack = new Queue<Item>();
        }
        public int Health { get; set; }
        public int Power { get; set; }
    }
}
