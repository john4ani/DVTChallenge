

using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Class the defines Elevators Center of Command functionality that exists in a building 
    /// </summary>
    public class ElevatorsCommandCenter : IElevatorsCommandCenter
    {
        private Dictionary<int, IElevator> _elevatorsIndexElevatorMap;
        private Dictionary<int, IFloor> _floorsIndexFloorMap;

        public ElevatorsCommandCenter(Dictionary<int, IElevator> elevatorsIndexElevatorMap, Dictionary<int, IFloor> floorsIndexFloorMap)
        {
            _elevatorsIndexElevatorMap = elevatorsIndexElevatorMap;
            _floorsIndexFloorMap = floorsIndexFloorMap;
        }

        /// <summary>
        /// First requirment: "* show Elevator status, including which floor are they on...."
        /// </summary>
        public async Task ShowElevatorsStatusOnConsoleAsync()
        {
            await Task.Run(() =>
            {

                foreach (var elevator in _elevatorsIndexElevatorMap.Values)
                {
                    Console.WriteLine(elevator.ToString());
                }
            });

        }

        /// <summary>
        /// Second requirment: "* provide way to interact with elevators..."
        /// </summary>
        /// <param name="floorIndex">Floor index</param>
        /// <returns></returns>
        public async Task<int> CallElevatorOnFloorAsync(int floorIndex, ElevatorDirection elevatorDirection)
        {
            var nearestElevatorDistance = int.MaxValue;
            var nearestElevatorIndex = -1;

            var availableElevators = _elevatorsIndexElevatorMap
                .Where(e => e.Value.Direction == ElevatorDirection.Standing);            

            //find the nearest elevator
            foreach (var elevator in availableElevators)
            {
                var floorsDistance = Math.Abs(floorIndex - elevator.Value.CurrentFloor);
                
                if (nearestElevatorDistance > floorsDistance)
                {
                    nearestElevatorDistance = floorsDistance;
                    nearestElevatorIndex = elevator.Key;
                }
            }

            await _elevatorsIndexElevatorMap[nearestElevatorIndex].CallElevatorAsync(floorIndex, elevatorDirection);

            return nearestElevatorIndex;
        }

        /// <summary>
        /// Loads people into elevator
        /// </summary>
        /// <param name="elevatorIndex">Elevator index that loads the people</param>
        /// <param name="floorIndex">Floor index where people are</param>
        /// <returns></returns>
        public async Task LoadPeopleIntoElevatorAsync(int elevatorIndex, int floorIndex)
        {
            var onboardedPeople = await _elevatorsIndexElevatorMap[elevatorIndex].TakePeopleOn(_floorsIndexFloorMap[floorIndex].People);

            await _floorsIndexFloorMap[floorIndex].OnPeopleOnboardedIntoElevatorAsync(onboardedPeople);
        }

        /// <summary>
        /// Moves specific elevator to specific floor
        /// </summary>
        /// <param name="elevatorIndex">Elevator index</param>
        /// <param name="floorIndex">Floor index</param>
        /// <param name="isCallingFloorFinalDestination">True if the floor is the final destination</param>
        /// <returns></returns>
        public async Task MoveElevatorAsync(int elevatorIndex, int floorIndex, bool isCallingFloorFinalDestination = false)
        {
            await _elevatorsIndexElevatorMap[elevatorIndex].MoveElevatorAsync(floorIndex, isCallingFloorFinalDestination);
        }

        /// <summary>
        /// Unloads people from elevator
        /// </summary>
        /// <param name="elevatorIndex">Elevator index that loads the people</param>
        /// <param name="floorIndex">Floor index where people are</param>
        /// <returns></returns>
        public async Task UnloadPeopleFromElevatorAsync(int elevatorIndex, List<Person> people)
        {
            await _elevatorsIndexElevatorMap[elevatorIndex].TakePeopleOff(people);
        }
    }
}
