using System;
using System.Collections.Generic;
using System.Linq;

namespace AClassyProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCases = int.Parse(Console.ReadLine());
            int numberOfPeople;
            int maxSubclasses = 10;
            List<Input> input = new List<Input>();
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfCases; i++)
            {
                numberOfPeople = int.Parse(Console.ReadLine());
                for (int j = 0; j < numberOfPeople; j++)
                {
                    input.Add(new Input(Console.ReadLine()));
                }

                for (int j = 0; j < numberOfPeople; j++)
                {
                    people.Add(new Person(input[j], maxSubclasses));
                }

                people = people
                    .OrderByDescending(q => q.Class[0])
                    .ThenByDescending(q => q.Class[1])
                    .ThenByDescending(q => q.Class[2])
                    .ThenByDescending(q => q.Class[3])
                    .ThenByDescending(q => q.Class[4])
                    .ThenByDescending(q => q.Class[5])
                    .ThenByDescending(q => q.Class[6])
                    .ThenByDescending(q => q.Class[7])
                    .ThenByDescending(q => q.Class[8])
                    .ThenByDescending(q => q.Class[9])
                    .ThenBy(q => q.Name)
                    .ToList();

                for (int j = 0; j < numberOfPeople; j++)
                {
                    Console.WriteLine(people[j].Name);
                }

                Console.WriteLine("==============================");
                input.Clear();
                people.Clear();
            }
        }
    }

    class Person
    {
        public Person(Input input, int maxSubclasses)
        {
            Name = input.Name;
            Class = SetClass(input.Class, maxSubclasses);
        }

        private int[] SetClass(string[] @class, int maxSubclasses)
        {
            var returnValue = new int[maxSubclasses];
            for (int i = 0; i < @class.Length; i++)
            {
                if (@class[i] == "upper")
                {
                    returnValue[@class.Length - i - 1] = 1;
                }
                else if (@class[i] == "lower")
                {
                    returnValue[@class.Length - i - 1] = -1;
                }
                else
                {
                    returnValue[@class.Length - i - 1] = 0;
                }
            }
            return returnValue;
        }

        public string Name { get; set; }
        public int[] Class { get; set; }
    }

    class Input
    {
        public Input(string input)
        {
            var temp = input.Split(' ');
            Name = temp[0].Substring(0, temp[0].Length - 1);
            Class = temp[1].Split('-');
        }
        public string Name { get; set; }
        public string[] Class { get; set; }
    }
}
