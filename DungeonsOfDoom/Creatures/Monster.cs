namespace DungeonsOfDoom
{
    abstract class Monster : Creature
    {
        static public int MonsterCreated { get; set; }
        static public int MonsterCount{get; set;}
        public Monster(string name): base(30, 10) 
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
