using System.Collections.Generic;

namespace CafeForDevs.Server.Application
{
    internal class Order
    {
        private List<OrderProsition> _positions;

        internal Order()
        {
            _positions = new List<OrderProsition>();
        }

        internal void AddPosition(MenuItem menuItem, int quantity)
        {
            var position = new OrderProsition
            {
                Name = menuItem.Name,
                Price = menuItem.Price,
                Quantity = quantity
            };

            _positions.Add(position);
        }

        internal OrderProsition[] GetPrositions()
        {
            return _positions.ToArray();
        }
    }
}
