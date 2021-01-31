namespace HuntTheWumpus.GameObjects
{
    public class Wumpus : GameObject
    {
        public Wumpus(Coordinates coordinates) : base(coordinates, "[W]")
        {
            IsAlive = true;
        }

        public bool IsAlive { get; set; }
    }
}
