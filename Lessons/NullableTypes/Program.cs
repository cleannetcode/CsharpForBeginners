using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintNumber();
            Console.WriteLine();
            PrintDefault();
            Console.WriteLine();
            ElvisOperator();
        }

        private static void PrintDefault()
        {
            Console.WriteLine("PrintDefault");
            Console.WriteLine();

            int number = default(int);
            int? nullableNumber = default(int);
            int? nullableNumber1 = default(int?);

            Console.WriteLine("number " + number);
            Console.WriteLine("nullableNumber " + nullableNumber);
            Console.WriteLine("nullableNumber1 " + nullableNumber1);

            string text = default(string);
            string? text1 = default(string);
            string? text2 = default(string?);

            Console.WriteLine("text " + text);
            Console.WriteLine("text1 " + text1);
            Console.WriteLine("text2 " + text2);
        }

        public static void PrintNumber()
        {
            Console.WriteLine("PrintNumber");
            Console.WriteLine();

            int? nullableNumber = null;
            int number = nullableNumber.HasValue ? nullableNumber.Value : default(int);
            int number1 = nullableNumber != null ? nullableNumber.Value : default(int);
            int number2 = nullableNumber ?? 1;
            int number3 = nullableNumber.GetValueOrDefault(2);

            Console.WriteLine(number);
            Console.WriteLine(number1);
            Console.WriteLine(number2);

            string text = null;
            string text2 = text ?? "test";

            Console.WriteLine(text);
            Console.WriteLine(text2);
        }

        public static void ElvisOperator()
        {
            Console.WriteLine("ElvisOperator");
            Console.WriteLine();

            Person person = new Person("Test");
            Person person1 = null;

            Console.WriteLine(person?.Name);
            Console.WriteLine(person?.Age);
            Console.WriteLine(person?.ID?.Number);

            Console.WriteLine(person1?.Name);
            Console.WriteLine(person1?.Age);
            Console.WriteLine(person1?.Age);
            Console.WriteLine(person?.ID?.Number);
        }
    }

    public class Person
    {
        public Person(string name, int? age = null)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int? Age { get; private set; }

        public ID ID { get; set; }
    }

    public class ID
    {
        public int Number { get; set; }
    }
}
