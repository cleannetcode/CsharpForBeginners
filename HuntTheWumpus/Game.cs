using HuntTheWumpus.GameObjects;
using System;

namespace HuntTheWumpus
{
    public class Game
    {
        public void Start()
        {
            Map map = new Map(6);

            Player player = new Player(new Coordinates(2, 4));
            Wumpus wumpus = new Wumpus(new Coordinates(5, 2));

            map.AddObject(new Bat(new Coordinates(4, 3)));
            map.AddObject(new Bat(new Coordinates(2, 2)));
            map.AddObject(new Pit(new Coordinates(1, 4)));
            map.AddObject(new Pit(new Coordinates(3, 5)));

            map.AddObject(player);
            map.AddObject(wumpus);

            while (player.IsAlive && wumpus.IsAlive)
            {
                Console.Clear();
                PrintMap(map.GetMap());
                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        player.Move(Direction.Up);
                        break;

                    case ConsoleKey.DownArrow:
                        player.Move(Direction.Down);
                        break;

                    case ConsoleKey.LeftArrow:
                        player.Move(Direction.Left);
                        break;

                    case ConsoleKey.RightArrow:
                        player.Move(Direction.Right);
                        break;
                }

                if (userInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            if (player.IsAlive)
            {
                Console.WriteLine("Вы победили");
            }

            if (wumpus.IsAlive)
            {
                Console.WriteLine("Вас съели");
            }
        }

        public void PrintMap(string[,] map)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[x, y]);
                }

                Console.WriteLine();
            }
        }
    }
}
