using System;
using System.Runtime.Serialization.Formatters;

namespace Witch
{
    public class Person
    {
        private double m_ageOfDeath;
        private double m_yearOfDeath;

        private Person() { }

        public Person(double ageOfDeath, double yearOfDeath)
        {
            m_ageOfDeath = ageOfDeath;
            m_yearOfDeath = yearOfDeath;
        }


        public double AgeOfDeath
        {
            get { return m_ageOfDeath; }
        }

        public double YearOfDeath
        {
            get { return m_yearOfDeath; }
        }
        public double Year { get; set; }
        public double NumberOfPeopleKilled { get; set; }

        public static void Main()
        {
            Person person1 = new Person(10, 12);
            Person person2 = new Person(13, 17);

            person1.Year = person1.YearOfDeath - person1.AgeOfDeath;
            person2.Year = person2.YearOfDeath - person2.AgeOfDeath;

            person1.NumberOfPeopleKilled = KillVillagers(person1.Year);
            person2.NumberOfPeopleKilled = KillVillagers(person2.Year);

            double avg = (person1.NumberOfPeopleKilled + person2.NumberOfPeopleKilled) / 2;
            Console.WriteLine("average is {0}", avg);
        }

        public static int KillVillagers(double year)
        {
            int villagers = 0;
            List<int> yearList = new List<int>();
            for (int i = 1; i <= year; i++)
            {
                var lastNumber = yearList.Count >= 2 ? yearList[(yearList.Count - 1)] + yearList[(yearList.Count - 2)] : 1;
                yearList.Add(lastNumber);
            }

            villagers = yearList.Sum();
            return villagers;
        }
    }
}