
using DVT___Challenge.Classes;
using DVT___Challenge.Strategies;

namespace TestsProject
{
    public class ElevatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CallElevatorUpTest()
        {
            var elevator = new Elevator(0, 1, new IdealWeightStrategy());

            await elevator.CallElevatorUpAsync(new Floor(10,new List<Person>()));

            Assert.That(elevator.ToString().Equals("The elevator 0 status is Standing and carrying 0 people."), "Invalid elevator description : " + elevator.ToString());
        }
        
    }
}
