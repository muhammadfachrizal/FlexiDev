using Witch;

namespace TestFlexiDev
{
    [TestClass]
    public class PersonTest
    {
        public int KillVillagers(double year)
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

        [TestMethod]
        public void TestMethod1Person()
        {
            Person person1 = new Person(10, 15);

            person1.Year = person1.YearOfDeath - person1.AgeOfDeath;

            person1.NumberOfPeopleKilled = KillVillagers(person1.Year);

            Console.WriteLine("the witch kills {0} villagers", person1.NumberOfPeopleKilled);
        }

        [TestMethod]
        public void TestMethod2Person()
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

        [TestMethod]
        public void TestMethodError()
        {
            Person person1 = new Person(10, -12);
            Person person2 = new Person(13, -17);

            person1.Year = person1.YearOfDeath - person1.AgeOfDeath;
            person2.Year = person2.YearOfDeath - person2.AgeOfDeath;

            double avg = (person1.Year + person2.Year) / 2;
            if (person1.Year <= 0 || person2.Year<= 0) {
                Console.WriteLine(-1);
            }
        }
    }
}