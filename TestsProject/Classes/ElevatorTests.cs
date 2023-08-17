

using DVT___Challenge;
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
        public async Task CallElevatorTest()
        {
            var elevator = new Elevator(0, 1, new IdealWeightStrategy());

            await elevator.CallElevatorAsync(10, ElevatorDirection.MovingUp);

            Assert.That(elevator.ToString().Equals("The elevator 0 status is Moving Up and carrying 0 people."), "Invalid elevator description : " + elevator.ToString());
        }
        
    }
}
