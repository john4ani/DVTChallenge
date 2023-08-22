using DVT___Challenge.Classes.ElevatorStates;
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Class that defines an elevator functionality
    /// </summary>
    public class Elevator : IElevator
    {
        private decimal _maxWeight = 0;
        private decimal _currentWeight = 0;        
        private int _index = 0;
        private int _currentNumberOfPeople = 0;
        private int _currentFloorIndex = 0;


        private IElevatorState _state ;        
        private readonly IElevatorTakeOnPeopleStrategy _elevatorTakeOnPeopleStrategy;

        /// <summary>
        /// The state of this elevator
        /// </summary>
        public IElevatorState State => _state;

        /// <summary>
        /// Gets the current floor index
        /// </summary>
        public int CurrentFloorIndex => _currentFloorIndex;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="index">The elevator index</param>
        /// <param name="maxWeight">The max weight allowed for the elevator</param>
        /// <param name="elevatorTakeOnPeopleStrategy">Parameter for strategy of taking people on, used by this elevator</param>
        public Elevator(int index, decimal maxWeight, IElevatorTakeOnPeopleStrategy elevatorTakeOnPeopleStrategy)
        {
            _index = index;
            _maxWeight = maxWeight;
            _elevatorTakeOnPeopleStrategy = elevatorTakeOnPeopleStrategy;

            _state = new Standing();            
        }

        /// <summary>
        /// Calls the elevator up
        /// </summary>
        /// <param name="callingFloor">The floor number that is calling</param>
        /// <returns></returns>        
        public async Task CallElevatorUpAsync(IFloor callingFloor)
        {
            _state = _state.CallElevatorUp();
            _state = await _state.MoveElevatorAsync(async (int increment) => await MoveElevatorAsync(callingFloor, increment));
        }        

        /// <summary>
        /// Calls the elevator down
        /// </summary>
        /// <param name="callingFloor">The floor number that is calling</param>
        /// <returns></returns>        
        public async Task CallElevatorDownAsync(IFloor callingFloor)
        {
            _state = _state.CallElevatorDown();
            _state = await _state.MoveElevatorAsync(async (int increment) => await MoveElevatorAsync(callingFloor,increment));
        }

        /// <summary>
        /// Internal functionality for Moving elevator
        /// </summary>
        /// <param name="callingFloor"></param>
        /// <param name="movingIncrement"></param>
        /// <returns></returns>
        private async Task MoveElevatorAsync(IFloor callingFloor, int movingIncrement)
        {
            await Task.Run(() =>
            {
                while (_currentFloorIndex != callingFloor.Index)
                {
                    _currentFloorIndex += movingIncrement;

                    //optional delay for realistic simulation
                    //Thread.Sleep(1000);

                    //Console.WriteLine(ToString());
                }
            });
        }

        /// <summary>
        /// Takes on people.
        /// </summary>
        /// <param name="listOfPeople">List of people for onboarding.</param>
        /// <returns>List of people that have managed to onboard.</returns>
        public async Task<List<Person>> TakePeopleOn(List<Person> listOfPeople)
        {
            var onboardedPeopleAndTheirWeight = await _elevatorTakeOnPeopleStrategy.TakeOnPeopleAsync(listOfPeople, _maxWeight, _currentWeight);
            
            _currentNumberOfPeople += onboardedPeopleAndTheirWeight.Item1.Count();
            _currentWeight += onboardedPeopleAndTheirWeight.Item2;

            return onboardedPeopleAndTheirWeight.Item1;
        }

        /// <summary>
        /// Functionality to offboard people from elevator
        /// </summary>
        /// <param name="listOfPeople"></param>
        public async Task TakePeopleOff(List<Person> listOfPeople)
        {
            await Task.Run(() =>
            {
                foreach (var person in listOfPeople)
                {
                    _currentWeight -= person.Weight;
                }
                _currentNumberOfPeople -= listOfPeople.Count();

            });
        }        

        /// <summary>
        /// Returns this eleveator as a string for printing
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return string.Format($"The elevator {_index} status is {_state} and carrying {_currentNumberOfPeople} people.");
        }
    }


}
