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
                {0, new Floor(0, new List<Person> { new Person(1,1),new Person(2,2), new Person(3,3)}) },
                {1, new Floor(1, new List<Person> { new Person(1,1),new Person(2,3), new Person(3,3)}) },
                {2, new Floor(2, new List<Person> { new Person(1, 3), new Person(2,2), new Person(3,3)}) },
            };
            
            var commandCenter = new ElevatorsCommandCenter(new Elevators(elevatorsMap), floorsMap);

            var nearestElevatorIndex = await commandCenter.CallElevatorUpAsync(0);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 0);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            await commandCenter.UnloadPeopleFromElevatorAsync(nearestElevatorIndex, new List<Person>
            {
                new Person(1),
                new Person(2),
                new Person(3)
            });

            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            Console.WriteLine();

            nearestElevatorIndex = await commandCenter.CallElevatorUpAsync(1);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 1);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();

            nearestElevatorIndex = await commandCenter.CallElevatorDownAsync(2);
            await commandCenter.LoadPeopleIntoElevatorAsync(nearestElevatorIndex, 2);
            await commandCenter.ShowElevatorsStatusOnConsoleAsync();



            Console.ReadKey();
        }
    }
}