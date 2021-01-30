using System;
using System.Runtime.InteropServices;

namespace DiffBetweenStructAndClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Email email = new Email("Test");
            Email email1 = email;

            Person person = new Person();
            Person person1 = new Person();
        }
    }

    public class Person
    {
        public string Value { get; set; }
    }

    public struct Email
    {
        private string _emailValue;

        public Email(string email)
        {
            _emailValue = email;
        }

        public override string ToString()
        {
            return _emailValue ?? "empty";
        }
    }
}
