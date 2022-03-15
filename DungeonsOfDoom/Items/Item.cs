namespace DungeonsOfDoom
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public virtual void Bonus(Creature player)
        {
                player.Health += 10;
            if (player is Player p)
            {
                p.X = p.Y = 0;
            }
        }

        public string Name { get; set; }
    }
}
