namespace BlackJack
{
    public class Player
    {
        public Player(string name)
        {
            IsContinue = true;
            Name = name;
        }

        public string Name { get; private set; }
        public int Score { get; private set; }
        public bool IsContinue { get; private set; }
        public bool IsTooMuch
        {
            get
            {
                return Score > 21;
            }
        }

        public void AddScore(int value)
        {
            Score += value;
        }

        public void Pass()
        {
            IsContinue = false;
        }
    }
}
