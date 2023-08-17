using DVT___Challenge.Classes;
using DVT___Challenge.Strategies;

namespace TestsProject
{
    public class IdealWeigthStrategyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task BasicTest()
        {
            var strategy = new IdealWeightStrategy();
            var maxWeigth = 10M;
            var currentWeigth = 0M;


            var onboardedPeopleAndWeight = await strategy.TakeOnPeopleAsync(new List<Person>
            {
                new Person(1,3),
                new Person(2,3),
                new Person(3,3),
                new Person(4,2),
                new Person(5,2),
                new Person(6,1),
                new Person(7,1),
                new Person(8,1),
                new Person(9,1)
            }, maxWeigth, currentWeigth);

            Assert.That(onboardedPeopleAndWeight.Item2.Equals(maxWeigth));
            Assert.That(onboardedPeopleAndWeight.Item1.Count.Equals(6));
        }
    }
}