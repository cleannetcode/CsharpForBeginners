using System;
using System.Text;
using BlackJack.Logic;

namespace BlackJack.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Game game = new Game();
            Player player = new Player("Player");
            Player computer = new Player("Computer");

            do
            {
                if (player.IsContinue)
                {
                    AskPlayer(player);
                }

                if (player.IsContinue)
                {
                    game.GetCard(player);
                }

                if (computer.IsContinue)
                {
                    AskComputer(computer);
                }

                if (computer.IsContinue)
                {
                    game.GetCard(computer);
                }

                Console.Clear();
                Console.Write($"Player: {player.Score}");
                Console.WriteLine();

            } while ((player.IsContinue || computer.IsContinue)
                && player.IsTooMuch == false
                && computer.IsTooMuch == false);

            Player winner = game.GetWinner(new[] { player, computer });
            Console.WriteLine($"Player: {player.Score}, Computer: {computer.Score}");
            Console.WriteLine("Победил: " + winner.Name);
        }

        private static void AskComputer(Player player)
        {
            if (player.Score > 15)
            {
                Console.WriteLine("Компьютер пасует");
                player.Pass();
            }
            else
            {
                Console.WriteLine("Компьютер тянет карту");
            }
        }

        private static void AskPlayer(Player player)
        {
            Console.WriteLine("Будешь тянуть карту? (y/n)");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.WriteLine("Вы тянете карту");
            }

            if (answer == "n")
            {
                Console.WriteLine("Вы пасуете");
                player.Pass();
            }
        }
    }
}
