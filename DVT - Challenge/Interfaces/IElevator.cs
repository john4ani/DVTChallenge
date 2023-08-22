using DVT___Challenge.Classes;
using DVT___Challenge.Classes.ElevatorStates;

namespace DVT___Challenge.Interfaces
{
    /// <summary>
    /// Contract interface for Elevator
    /// </summary>
    public interface IElevator
    {
        /// <summary>
        /// The state of this elevator
        /// </summary>
        public IElevatorState State { get; }

        /// <summary>
        /// Gets the current floor index
        /// </summary>
        public int CurrentFloorIndex { get; }

        /// <summary>
        /// Call Elevator Up functionality
        /// </summary>
        /// <param name="callingFloor">Calling fllor</param>
        /// <returns></returns>
        Task CallElevatorUpAsync(IFloor callingFloor);

        /// <summary>
        /// Call Elevator Down functionality
        /// </summary>
        /// <param name="callingFloor">Calling fllor</param>
        /// <returns></returns>
        Task CallElevatorDownAsync(IFloor callingFloor);

        Task TakePeopleOff(List<Person> listOfPeople);

        /// <summary>
        /// Takes on people.
        /// </summary>
        /// <param name="listOfPeople">List of people for onboarding.</param>
        /// <returns>List of people that have managed to onboard.</returns>
        Task<List<Person>> TakePeopleOn(List<Person> listOfPeople);        

        /// <summary>
        /// Returns this eleveator as a string for printing
        /// </summary>
        /// <returns>String</returns>
        string ToString();
    }
}