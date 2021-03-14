using CafeForDevs.Models;

namespace CafeForDevs.Client
{
    public interface ICafeHttpClient
    {
        MenuModel GetMenu();
        void SelectMenuItem(int menuItemId, int quantity);
        OrderModel GetOrder();
    }
}
