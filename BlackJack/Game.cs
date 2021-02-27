using System;
using System.Net.Http;

namespace BlackJack.Logic
{
    public class Game
    {
        private Deck _deck;

        public Game()
        {
            int[] cards = new int[]
            {
                2, 3, 4, 5, 6, 7, 8, 9, 10, // - цифры
                10, 10, 10, // - картинки
                11, // - туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // - цифры
                10, 10, 10, // - картинки
                11, // - туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // - цифры
                10, 10, 10, // - картинки
                11, // - туз

                2, 3, 4, 5, 6, 7, 8, 9, 10, // - цифры
                10, 10, 10, // - картинки
                11, // - туз
            };

            cards = Shuffle(cards);
            cards = Shuffle(cards);

            _deck = new Deck(cards);
        }

        public void GetCard(Player player)
        {
            int point = _deck.Pull();
            player.AddScore(point);
        }

        public Player GetWinner(Player[] players)
        {
            if (players == null || players.Length == 0)
                return null;

            Player winner = players[0];

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].IsTooMuch == false)
                {
                    if (players[i].Score > winner.Score)
                    {
                        winner = players[i];
                    }
                }
            }

            return winner;
        }

        private int[] Shuffle(int[] cards)
        {
            int[] usedIndexes = new int[cards.Length];

            for (int i = 0; i < usedIndexes.Length; i++)
            {
                usedIndexes[i] = -1;
            }

            int[] result = new int[cards.Length];

            Random random = new Random();

            for (int i = 0; i < cards.Length; i++)
            {
                int index = 0;

                do
                {
                    index = random.Next(0, cards.Length);

                } while (Contains(usedIndexes, index));

                result[i] = cards[index];
                usedIndexes[i] = index;
            }

            return result;
        }

        private bool Contains(int[] values, int value)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == value)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
