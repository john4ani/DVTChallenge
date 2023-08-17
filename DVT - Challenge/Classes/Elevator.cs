

using DVT___Challenge.Extentions;
using DVT___Challenge.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Class that defines an elevator functionality
    /// </summary>
    public class Elevator : IElevator
    {
        private decimal _maxWeight = 0;
        private decimal _currentWeight = 0;
        private int _currentFloor = 0;
        private int _index = 0;
        private int _currentNumberOfPeople = 0;

        private ElevatorDirection _direction = ElevatorDirection.Standing;
        private readonly IElevatorTakeOnPeopleStrategy _elevatorTakeOnPeopleStrategy;

        /// <summary>
        /// Direction of moving for this elevator
        /// </summary>
        public ElevatorDirection Direction => _direction;        

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
        }

        /// <summary>
        /// Calls the elevator
        /// </summary>
        /// <param name="callingFloor">The floor number that is calling</param>
        /// <param name="direction">Direction of call</param>
        /// <returns></returns>        
        public async Task CallElevatorAsync(int callingFloor, ElevatorDirection direction)
        {
            if (_currentFloor == callingFloor)
            {
                _direction = ElevatorDirection.Standing;
                return;
            }            

            _direction = direction;
            await MoveElevatorAsync(callingFloor);
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
        /// Private method which simulates moving elevator
        /// </summary>
        public async Task MoveElevatorAsync(int callingFloor, bool isCallingFloorFinalDestination = false)
        {

            var increment = callingFloor > _currentFloor ? 1 : -1;
            _direction = increment == 1 ? ElevatorDirection.MovingUp : ElevatorDirection.MovingDown;

            await Task.Run(() =>
            {
                while (_currentFloor != callingFloor)
                {
                    _currentFloor += increment;
                    
                    //optional delay for realistic simulation
                    //Thread.Sleep(1000);
                    
                    Console.WriteLine(ToString());
                }
            }); 
            
            if(isCallingFloorFinalDestination)
            {
                _direction = ElevatorDirection.Standing;
            }
        }

        /// <summary>
        /// Returns this eleveator as a string for printing
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var status = _direction.GetAttribute<DisplayAttribute>().Name;
            return string.Format($"The elevator {_index} status is {status} and carrying {_currentNumberOfPeople} people.");
        }
    }


}
