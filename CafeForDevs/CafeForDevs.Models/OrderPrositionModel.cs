namespace CafeForDevs.Models
{
    public class OrderPrositionModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Sum => Price * Quantity;
    }
}
