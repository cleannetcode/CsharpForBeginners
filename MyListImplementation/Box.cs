namespace MyListImplementation
{
    internal class Box
    {
        public Box(int value)
        {
            Value = value;
            Next = null;
        }

        public int Value { get; set; }
        public Box Next { get; set; }
    }
}
