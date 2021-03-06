using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Delegates
{
    internal delegate void Notify(string message);
    internal delegate void Action(string message, int number);

    internal delegate bool Checker(string product);
    internal delegate bool ProductChecker(Product product);

    internal class Program
    {
        private static void Main(string[] args)
        {
            var cart = new ProductsCart(message => Console.WriteLine(message));

            cart.Add(new Product("Cheese", 100));
            cart.Add(new Product("Bread", 200));
            cart.Add(new Product("Milk", 700));

            var product1 = cart.Find(x => x.Name == "Cheese");
            var product2 = cart.Find(x => x.Price > 500);

            Console.WriteLine(product1.Name);
            Console.WriteLine(product2.Name);

            List<Product> products = new List<Product> 
            {
                new Product("Cheese", 100),
                new Product("Bread", 200),
                new Product("Milk", 700)
            };

            product1 = products.Find(x => x.Name == "Chese");
            product2 = products.Find(x => x.Price > 500);

            Console.WriteLine(product1?.Name);
            Console.WriteLine(product2?.Name);

            product1 = products.FirstOrDefault(x => x.Name == "Chese");
            product2 = products.FirstOrDefault(x => x.Price > 500);

            Console.WriteLine(product1?.Name);
            Console.WriteLine(product2?.Name);
        }

        private static void CartWithLambda()
        {
            var cart = new Cart();
            cart.Add("Cheese");
            cart.Add("Bread");
            cart.Add("Milk");

            var product = cart.Find(x => x == "Chese");

            Console.WriteLine(product);
        }

        private static void Closure()
        {
            var date = DateTime.Now;
            var number = 10;
            var message = "Test";

            Notify notifyError = delegate (string message)
            {
                var number = 50;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(date + ": " + message + "# " + number);
                Console.ResetColor();
            };

            notifyError += message =>
            {
                number -= 10;
                Console.WriteLine(date + ": " + message + "# " + number);
            };

            var cart = new Cart(notifyError);
            cart.Add(" ");
        }

        private static void LambdaExpressions2()
        {
            var cart = new Cart();
            cart.SetNotifier(message => Console.WriteLine(message));
            cart.Add(" ");
        }

        private static void LambdaExpressions()
        {
            Notify notifyError = a =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ResetColor();
            };

            notifyError("Error message");
        }

        private static void AnnonimousDelegateUsage()
        {
            Notify notifyError = delegate (string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            };

            Action action = delegate (string a, int b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a + b);
                Console.ResetColor();
            };

            action("Number: ", 10);
            notifyError("Test error message");

            TestDelegateUsage();
        }

        private static void TestDelegateUsage()
        {
            Notify notify = PrintErrorMessage;
            notify += PrintFileMessage;
            notify += delegate (string message)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            };

            var cart = new Cart(notify);
            cart.Add("Cheese");
            cart.Add("Cheese");
            cart.Add(null);
            cart.Add("");
            cart.Add(" ");
            cart.Add("Bread");
            cart.Add("Bread");

            Console.WriteLine(cart.GetProducts());
        }

        private static void TestDelegates()
        {
            Notify notify = PrintMessage;

            notify = PrintMessage;
            notify += PrintErrorMessage;
            notify += PrintMessage;

            notify = notify + notify;

            var invocationList = notify?.GetInvocationList();

            notify("Test");
        }

        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void PrintFileMessage(string message)
        {
            File.AppendAllLines("test.log", new[] { message });
        }
    }
}
