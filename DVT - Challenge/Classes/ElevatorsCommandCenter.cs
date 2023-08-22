

using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Class the defines Elevators Center of Command functionality that exists in a building 
    /// </summary>
    public class ElevatorsCommandCenter : IElevatorsCommandCenter
    {
        private Elevators _elevators;
        private Dictionary<int, IFloor> _floorsIndexFloorMap;

        public ElevatorsCommandCenter(Elevators elevators, Dictionary<int, IFloor> floorsIndexFloorMap)
        {
            _elevators = elevators;
            _floorsIndexFloorMap = floorsIndexFloorMap;
        }

        /// <summary>
        /// First requirment: "* show Elevator status, including which floor are they on...."
        /// </summary>
        public async Task ShowElevatorsStatusOnConsoleAsync()
        {           
             await _elevators.PrintToConsoleAsync();
        }        

        /// <summary>
        /// Functionality for Call Up elevator
        /// </summary>
        /// <param name="floorIndex">Calling floor index</param>
        /// <returns></returns>
        public async Task<int> CallElevatorUpAsync(int floorIndex)
        {
            //get the nearest elevator based on floor distance 
            var nearestElevator = _elevators
                                    .GetAvailables()
                                    .GetNearest(floorIndex);

            await nearestElevator.Value.CallElevatorUpAsync(_floorsIndexFloorMap[floorIndex]);

            return nearestElevator.Key;
        }

        /// <summary>
        /// Functionality for Call Down elevator
        /// </summary>
        /// <param name="floorIndex">Calling floor index</param>
        /// <returns></returns>
        public async Task<int> CallElevatorDownAsync(int floorIndex)
        {
            //get the nearest elevator based on floor distance 
            var nearestElevator = _elevators
                                    .GetAvailables()
                                    .GetNearest(floorIndex);

            await nearestElevator.Value.CallElevatorDownAsync(_floorsIndexFloorMap[floorIndex]);

            return nearestElevator.Key;
        }

        /// <summary>
        /// Loads people into elevator
        /// </summary>
        /// <param name="elevatorIndex">Elevator index that loads the people</param>
        /// <param name="floorIndex">Floor index where people are</param>
        /// <returns></returns>
        public async Task LoadPeopleIntoElevatorAsync(int elevatorIndex, int floorIndex)
        {
            var onboardedPeople = await _elevators[elevatorIndex].TakePeopleOn(_floorsIndexFloorMap[floorIndex].People);

            await _floorsIndexFloorMap[floorIndex].OnPeopleOnboardedIntoElevatorAsync(onboardedPeople);
        }        

        /// <summary>
        /// Unloads people from elevator
        /// </summary>
        /// <param name="elevatorIndex">Elevator index that loads the people</param>
        /// <param name="floorIndex">Floor index where people are</param>
        /// <returns></returns>
        public async Task UnloadPeopleFromElevatorAsync(int elevatorIndex, List<Person> people)
        {
            await _elevators[elevatorIndex].TakePeopleOff(people);
        }
    }
}
