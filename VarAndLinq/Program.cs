using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VarAndLinq
{
    public class Issue
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }

    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int Age { get; set; }
        public List<Issue> Issues { get; set; }
    }

    public class Issues : IEnumerable<Issue>
    {
        private Issue[] _issues;

        public Issues(Issue[] issues)
        {
            _issues = issues;
        }

        public IEnumerator<Issue> GetEnumerator()
        {
            return new IssueEnumerator(_issues);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new IssueEnumerator(_issues);
        }
    }

    public class IssueEnumerator : IEnumerator<Issue>, IEnumerator
    {
        private Issue[] _issues;
        private int _index;

        public IssueEnumerator(Issue[] issues)
        {
            _issues = issues;
            _index = -1;
        }

        public Issue Current => _issues[_index];

        object IEnumerator.Current => _issues[_index];

        public bool MoveNext()
        {
            if (_index + 1 == _issues.Length)
                return false;

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var issues = new[]
            {
                new Issue
                {
                    Name = "Test A",
                    Description = "Test Description",
                    Deadline = DateTime.Now.AddDays(-2)
                },
                new Issue
                {
                    Name = "Test B",
                    Description = "Test Description",
                    Deadline = DateTime.Now.AddDays(-1)
                },
                new Issue
                {
                    Name = "Test C",
                    Description = "Test Description",
                    Deadline = DateTime.Now
                },
                new Issue
                {
                    Name = "Test D",
                    Description = "Test Description",
                    Deadline = DateTime.Now.AddDays(1)
                }
            };

            var data = new Issues(issues);

            var query = data.Where(x => x.Deadline > DateTime.Now)
                .OrderBy(x => x.Deadline);

            var enumerator = data.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item.Name + ": " + item.Deadline);
            }

            //enumerator.Reset();

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item.Name + ": " + item.Deadline);
            }

            //Console.WriteLine(count);
        }

        private static void DataQueryInvocation()
        {
            var data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var query = data
                .Where(number => number % 2 == 0)
                .Where(number => number > 5)
                .ToList();

            var result1 = query.ToArray();
            var result2 = query.Count();

            foreach (var item in result1)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine(result2);
        }

        private static void IntroToLinq()
        {
            {
                var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var evenNumbers = new List<int>();

                foreach (var number in numbers)
                {
                    if (number % 2 == 0)
                    {
                        evenNumbers.Add(number);
                    }
                }

                foreach (var evenNumber in evenNumbers)
                {
                    Console.Write(evenNumber + " ");
                }
            }

            Console.WriteLine();

            {
                var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var evenNumbers = numbers
                    .Where(number => number % 2 == 0)
                    .ToList();

                foreach (var evenNumber in evenNumbers)
                {
                    Console.Write(evenNumber + " ");
                }

                var text = "test message";
                var symbols = text
                    .Where(x => x == 'e');

                string resultText = string.Join(" ", symbols);

                Console.WriteLine(resultText);
            }
        }

        private static void SimpleInitialization()
        {
            var person = new Person("Test")
            {
                Age = 0,
                Issues = new List<Issue>
                {
                    new Issue
                    {
                        Name ="",
                        Deadline = DateTime.Now,
                        Description = ""
                    }
                }
            };
        }

        private static void AnonimousTypes()
        {
            var testObject = new
            {
                Name = "Test"
            };

            var testObject2 = new
            {
                Name = 100
            };

            var person = new Person("Test");
            person.Age = 10;
            person.Issues = new List<Issue>();

            var issue = new Issue();
            issue.Name = "Test issue";
            issue.Description = "Additional info";
            issue.Deadline = DateTime.Now;

            person.Issues.Add(issue);

            var report = new
            {
                PersonName = person.Name,
                IssueName = issue.Name
            };

            Console.WriteLine(report.PersonName + ": " + report.IssueName);
        }

        private static void InitVariablesWithVar()
        {
            {
                List<int> numbers = new List<int>();
                int number = 10;
                string text = "test";
            }

            {
                var numbers = new List<int>();
                var number = GetNumber();
                var text = "test";
            }
        }

        private static int GetNumber()
        {
            return 23535;
        }
    }
}
