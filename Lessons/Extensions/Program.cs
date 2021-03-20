using System;
using System.Collections.Generic;

namespace Extensions
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var student = new Student("Ivan");
            student.Study();
            student.Skip("TEST")
                .Skip2("TEST");

            var list = new List<Student>();
            list.Add(student);
            list.Add(student);
            list.Add(student);

            list.SkipLesson("TEST");
        }
    }

    public static class StudentExtension
    {
        public static T Skip<T>(this T student, string lesson) where T : Student
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{student.Name} skip {lesson}");
            Console.ResetColor();

            return student;
        }
    }

    public static class ListExtension
    {
        public static IList<T> SkipLesson<T>(this IList<T> students, string lesson) where T : Student
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} skip {lesson}");
            }

            Console.ResetColor();

            return students;
        }
    }

    public static class StudentExtension2
    {
        public static void Skip2(this Student student, string lesson)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{student.Name} skip {lesson}");
            Console.ResetColor();
        }
    }

    public class Student
    {
        public Student(string name) 
        {
            Name = name;
        }

        public string Name { get; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("Study");
        }
    }
}
