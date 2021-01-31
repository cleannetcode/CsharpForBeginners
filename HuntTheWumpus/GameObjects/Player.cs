namespace HuntTheWumpus.GameObjects
{
    public class Player : GameObject
    {
        public Player(Coordinates coordinates) : base(coordinates, "[@]")
        {
            IsAlive = true;
        }

        public bool IsAlive { get; set; }

        public void Move(Direction direction)
        {
            int x = 0;
            int y = 0;

            switch (direction)
            {
                case Direction.Up:
                    x = Coordinates.X;
                    y = Coordinates.Y - 1;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Down:
                    x = Coordinates.X;
                    y = Coordinates.Y + 1;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Left:
                    x = Coordinates.X - 1;
                    y = Coordinates.Y;
                    Coordinates = new Coordinates(x, y);
                    break;

                case Direction.Right:
                    x = Coordinates.X + 1;
                    y = Coordinates.Y;
                    Coordinates = new Coordinates(x, y);
                    break;
            }
        }
    }
}
