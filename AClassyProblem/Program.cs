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
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfCases; i++)
            {
                numberOfPeople = int.Parse(Console.ReadLine());

                for (int j = 0; j < numberOfPeople; j++)
                {
                    people.Add(new Person(Console.ReadLine().Split(' ')));
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

                Console.WriteLine(string.Join("\n",people));
                Console.WriteLine("==============================");
                people.Clear();
            }
        }
    }

    class Person
    {
        public Person(string[] input)
        {
            Name = input[0].Substring(0, input[0].Length - 1);
            Class = SetClass(input[1].Split('-'));
        }

        private int[] SetClass(string[] @class)
        {
            var returnValue = new int[10];
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

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public int[] Class { get; set; }
    }
}
