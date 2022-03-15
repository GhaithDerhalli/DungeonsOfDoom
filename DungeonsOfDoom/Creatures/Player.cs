namespace DungeonsOfDoom
{
    class Player: Creature
    {
       public Player(int x, int y): base(30, 10)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; set; }
        public int Y { get; set; }
    }
}
