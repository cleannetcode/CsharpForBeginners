using System;
using System.Net.Http;
using System.Text;

namespace ToDoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("1 - Вывести список задач");
                Console.WriteLine("2 - Добавить задачу");
                Console.WriteLine("3 - Удалить задачу");
                Console.WriteLine("4 - Редактировать задачу");
                Console.WriteLine("5 - Отметить задачу как выполненую");
                Console.WriteLine("x - Для выхода");

                string operation = Console.ReadLine();

                switch (operation.ToLower())
                {
                    case Operations.SHOW_ISSUES_LIST:
                        PrintIssues();
                        break;

                    case Operations.ADD_NEW_ISSUE:
                        CreateNewIssue();
                        break;

                    case Operations.EDIT_ISSUE:
                        EditIssue();
                        break;

                    case Operations.REMOVE_ISSUE:
                        DeleteIssue();
                        break;

                    case Operations.SET_ISSUE_AS_DONE:
                        Console.WriteLine("выполнение задачи");
                        break;

                    case Operations.EXIT:
                        isContinue = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет! " + operation);
                        break;
                }

                if (isContinue)
                {
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void SetAsDoneIssue()
        {
            var httpClient = new HttpClient();
            var response = httpClient.PatchAsync("http://localhost:51369/Issue", null).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private static void DeleteIssue()
        {
            var httpClient = new HttpClient();
            var response = httpClient.DeleteAsync("http://localhost:51369/Issue").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private static void EditIssue()
        {
            var httpClient = new HttpClient();
            var response = httpClient.PutAsync("http://localhost:51369/Issue", null).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private static void CreateNewIssue()
        {
            var httpClient = new HttpClient();
            var response = httpClient.PostAsync("http://localhost:51369/Issue", null).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }

        private static void PrintIssues()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync("http://localhost:51369/Issue").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
