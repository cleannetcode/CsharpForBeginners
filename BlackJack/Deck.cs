using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        private Stack<int> _cards;

        public Deck(int[] cards)
        {
            _cards = new Stack<int>(cards);
        }

        public int Pull()
        {
            return _cards.Pop();
        }
    }
}
