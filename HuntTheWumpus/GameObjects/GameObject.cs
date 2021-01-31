namespace HuntTheWumpus.GameObjects
{
    public abstract class GameObject
    {
        protected GameObject(Coordinates coordinates, string model)
        {
            Coordinates = coordinates;
            Model = model;
        }

        public Coordinates Coordinates { get; set; }
        public string Model { get; private set; }
    }
}
