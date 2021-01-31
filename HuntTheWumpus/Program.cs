using System;
using System.Text;

namespace HuntTheWumpus
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Game game = new Game();
            game.Start();
        }
    }
}
