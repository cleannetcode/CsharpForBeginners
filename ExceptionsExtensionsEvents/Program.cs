using System;
using System.IO;
using System.Text;

namespace ExceptionsExtensionsEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;

                var isCountinue = true;
                string answer = GetUserAnswer("Напишите ваше имя", "Имя не может быть пустой строкой!");
                var user = new UserSubcriptions(answer);

                do
                {
                    Console.Clear();

                    foreach (var subscription in user.GetSubscriptions())
                    {
                        Console.WriteLine(subscription.Title);
                    }

                    answer = GetUserAnswer("Добавьте новую подписку", "Название подписки не может быть пустой строкой!");

                    try
                    {
                        user.Add(new Subscription(answer));
                    }
                    catch (DuplicationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey(false);
                    }

                } while (isCountinue);
            }
            catch (Exception ex)
            {
                File.AppendAllText("errorLogs.log", ex.ToString());
                throw ex;
            }
        }

        private static string GetUserAnswer(string message, string errorMessage)
        {
            Console.WriteLine(message);
            string answer = null;

            do
            {
                answer = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(answer))
                    Console.WriteLine(errorMessage);

            } while (string.IsNullOrWhiteSpace(answer));

            return answer;
        }

        public static void InnerExceptions()
        {
            // вложенные исключения и большой стак трейс
            var generator = new ExceptionGenerator();
            generator.Generate();
        }

        public static void TryCatchFinally()
        {
            try
            {
                //Код который выбросит исключение
                File.ReadAllText(null);

                Console.WriteLine("Test");
                Console.WriteLine("Test");
                Console.WriteLine("Test");
                Console.WriteLine("Test");
                Console.WriteLine("Test");
            }
            catch
            {
                //Обработка исключения
                Console.WriteLine("Вы не указали путь к файлу!");
            }
            finally
            {
                //Блок кода который выполнится не зависимо от того, будет ли исключение или нет
                Console.WriteLine("finally");
            }
        }
    }
}
