using System;

namespace DungeonsOfDoom
{
    class ConsoleGame
    {
        Player player;
        Room[,] world;
        Random random = new Random();

        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            do
            {
                Console.Clear();
                DisplayWorld();
                DisplayStats();
                AskForMovement();
            } while (player.Health > 0);

            GameOver();
        }

        private void CreatePlayer()
        {
            player = new Player(0, 0);
        }

        private void CreateWorld()
        {
            world = new Room[40, 10];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    int percentage = random.Next(0, 100);
                    if (percentage < 5)
                    {
                        world[x, y].Monster = new Mage("whiteBeard");
                        Monster.MonsterCreated++;
                    }

                    else if (percentage < 10)
                    {
                        world[x, y].Monster = new Goblin("smeagle");
                        Monster.MonsterCreated++;
                    }
                    else if (percentage < 15)
                        world[x, y].Item = new Trap("Trap");
                    else if (percentage < 20)
                        world[x, y].Item = new Food("food");
                    
                    else if (percentage < 25)
                        world[x, y].Item = new Weapon("sword");
                    {

                    }

                }
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else if (room.Monster != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("M");
                        Console.ResetColor();

                        
                    }
                    else if (room.Item != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("I");
                        Console.ResetColor();
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-");
                        Console.ResetColor();

                    }
                
                }
                {

                }
                Console.WriteLine();
            }
        }

        private void DisplayStats()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Power: {player.Power}");
            Console.ResetColor();
            Console.Write("Items in Backpack: ");
            foreach (Item item in player.Backpack)
            {
                Console.Write(item.Name+ " ");
            }
            
        }

        private void AskForMovement()
        {
            int newX = player.X;
            int newY = player.Y;
            bool isValidKey = true;

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                default: isValidKey = false; break;
            }

            if (isValidKey &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;
                Room playersRoom = world[player.X, player.Y];
                if (playersRoom.Item != null) {
                    Console.Write("Do you want to use this item now? y/n: ");
                    char useItem = Console.ReadKey().KeyChar;
                    if (useItem == 'y')
                    {
                        playersRoom.Item.Bonus(player);
                    }
                    else
                        player.Backpack.Enqueue(playersRoom.Item);
                    playersRoom.Item = null;
                }
                if (playersRoom.Monster != null)
                {
                    player.Hit(playersRoom.Monster);
                    if (playersRoom.Monster.Health <= 0)
                    {
                        playersRoom.Monster = null;
                        Monster.MonsterCount++;
                        if (Monster.MonsterCount == Monster.MonsterCreated)
                        {
                            Console.WriteLine();
                            Console.WriteLine("You won!!");
                            Console.ReadLine();

                            GameOver();
                        }
                    }
                    else
                    {
                        if (player.Backpack.Count != 0)
                        {
                        Console.WriteLine("Do you want to use a item from your backpack? y/n");
                        char useItemInBackpack = Console.ReadKey().KeyChar;
                        if (useItemInBackpack == 'y')
                        {
                            player.Backpack.Dequeue().Bonus(player);
                        }

                        }

                        playersRoom.Monster.Hit(player);
                    
                    }
                }
            }




        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.WriteLine($"Number of monsters you killed: {Monster.MonsterCount}");
            Console.ReadKey();
            Play();
        }
        
    }
}
