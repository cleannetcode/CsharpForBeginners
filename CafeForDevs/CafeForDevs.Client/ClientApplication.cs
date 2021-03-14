using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace CafeForDevs.Client
{
    internal class ClientApplication
    {
        private ICafeHttpClient _cafeHttpClient;

        internal ClientApplication(ICafeHttpClient cafeHttpClient)
        {
            _cafeHttpClient = cafeHttpClient;
        }

        internal void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("ClientApplication запушен");

            var isUserContinue = true;
            string userAnswer;

            do
            {
                Console.WriteLine("выберите пункт меню:" +
                    "\n\t1) вывести меню ресторана" +
                    "\n\t2) выбрать блюдо из меню" +
                    "\n\t3) вывести информацию о своем заказе" +
                    "\n\t4) оплатить заказ");

                userAnswer = Console.ReadLine();

                // сделать проверку на число из пункта меню

                switch (userAnswer)
                {
                    case "1": 
                        PrintMenu(); 
                        break;

                    case "2":
                        SelectMenuItem();
                        break;

                    case "3":
                        PrintOrder();
                        break;
                }

                Console.WriteLine("Будем продолжать? (y/n)");
                userAnswer = Console.ReadLine();
                isUserContinue = userAnswer.ToLower() == "y";

            } while (isUserContinue);
        }

        internal void PrintMenu()
        {
            var menu = _cafeHttpClient.GetMenu();

            foreach(var item in menu.Items)
            {
                Console.WriteLine($"№{item.Id}: {item.Name} - {item.Price}");
            }
        }

        internal void SelectMenuItem()
        {
            Console.WriteLine("Введите номер блюдо");
            var userAnswer = Console.ReadLine();
            var menuItemId = int.Parse(userAnswer);

            Console.WriteLine("Введите желаемое кол-во");
            userAnswer = Console.ReadLine();
            var quantity = int.Parse(userAnswer);

            _cafeHttpClient.SelectMenuItem(menuItemId, quantity);
        }

        internal void PrintOrder()
        {
            var order = _cafeHttpClient.GetOrder();

            foreach(var position in order.Positions)
            {
                Console.WriteLine($"{position.Name}: {position.Price} * {position.Quantity} = {position.Sum}");
            }

            var orderTotal = order.Positions.Sum(x => x.Sum);

            Console.WriteLine($"Сумма вашего заказа: {orderTotal}");
        }
    }
}
