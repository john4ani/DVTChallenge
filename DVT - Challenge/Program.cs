using DVT___Challenge.Classes;
using DVT___Challenge.Interfaces;
using DVT___Challenge.Strategies;

namespace DVT___Challenge
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var firstComeFirstServedStrategy = new FirstComeFirstServedStrategy();
            var elevatorsMap = new Dictionary<int, IElevator> 
            {
                { 0, new Elevator(0, 10, firstComeFirstServedStrategy) },
                { 1, new Elevator(1, 10, firstComeFirstServedStrategy) },
                { 2, new Elevator(2, 10, firstComeFirstServedStrategy) },
                { 3, new Elevator(3, 10, firstComeFirstServedStrategy) },
                { 4, new Elevator(4, 10, firstComeFirstServedStrategy) },
            };

            

            var floorsMap = new Dictionary<int, IFloor> 
            {
                {0, new Floor(new List<Person> { new Person(1,1),new Person(2,2), new Person(3,3)}) },
                {1, new Floor(new List<Person> { new Person(1,1),new Person(2,3), new Person(3,3)}) },
                {2, new Floor(new List<Person> { new Person(1, 3), new Person(2,2), new Person(3,3)}) },
            };
            
            var commandCenter = new ElevatorsCommandCenter(elevatorsMap, floorsMap);

            var nearestElevatorIndex = await commandCenter.CallElevatorOnFloorAsync(0, ElevatorDirection.MovingUp);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 0);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            await commandCenter.MoveElevatorAsync(nearestElevatorIndex, 2, true);
            await commandCenter.UnloadPeopleFromElevatorAsync(nearestElevatorIndex, new List<Person>
            {
                new Person(1),
                new Person(2),
                new Person(3)
            });

            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            Console.WriteLine();

            nearestElevatorIndex = await commandCenter.CallElevatorOnFloorAsync(1, ElevatorDirection.MovingUp);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 1);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            nearestElevatorIndex = await commandCenter.CallElevatorOnFloorAsync(2, ElevatorDirection.MovingDown);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 2);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();



            Console.ReadKey();
        }
    }
}