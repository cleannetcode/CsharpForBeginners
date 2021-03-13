using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        private Stack<int> _cards;

        public Deck(int[] cards)
        {
            if (cards == null || cards.Length == 0)
                throw new ArgumentException(nameof(cards));

            _cards = new Stack<int>(cards);
        }

        public int Pull()
        {
            return _cards.Pop();
        }
    }
}
