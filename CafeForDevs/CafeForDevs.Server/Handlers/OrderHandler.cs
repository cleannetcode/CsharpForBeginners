using CafeForDevs.Models;
using CafeForDevs.Server.Application;
using System.Linq;
using System.Net;

namespace CafeForDevs.Server.Handlers
{
    public class OrderHandler : Handler, IHandler
    {
        private Order _order;

        public OrderHandler(Order order)
        {
            _order = order;
        }

        public string Path => "/order";

        public void Handle(HttpListenerContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "POST":
                    var request = GetRequestBody<MenuItemRequestModel>(context);
                    SelectMenuItem(request.MenuItemId, request.Quantity);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    break;

                case "GET":
                    var order = GetOrder();
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    SetResponse(order, context);
                    break;
            }

            context.Response.Close();
        }

        private void SelectMenuItem(int menuItemId, int quantity)
        {
            var menuItem = Menu.Get(menuItemId);
            _order.AddPosition(menuItem, quantity);
        }

        private OrderModel GetOrder()
        {
            var order = new OrderModel
            {
                Positions = _order.GetPrositions()
                .Select(x => new OrderPrositionModel
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                })
                .ToArray()
            };

            return order;
        }
    }
}
