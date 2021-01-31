using System;

namespace DiffBetweenStructAndClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email("Test");
            Email email1 = email;

            email.SetEmail("NotTest");
            email1.SetEmail("TestValue");

            Person person = new Person();
            Person person1 = person;

            person.Name = "Иван";
            person1.Name = "FirstAfterGod V";

            Console.WriteLine(email); // NotTest
            Console.WriteLine(email1); // TestValue
            Console.WriteLine(person.Name); // FirstAfterGod V, Иван
            Console.WriteLine(person1.Name); // FirstAfterGod V
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public struct Email
    {
        private string _emailValue;
        public Email(string email)
        {
            _emailValue = email;
        }

        public void SetEmail(string email)
        {
            _emailValue = email;
        }

        public override string ToString()
        {
            return _emailValue ?? "empty";
        }
    }
}
