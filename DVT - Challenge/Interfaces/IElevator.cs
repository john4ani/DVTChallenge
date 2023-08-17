using DVT___Challenge.Classes;

namespace DVT___Challenge.Interfaces
{
    /// <summary>
    /// Contract interface for Elevator
    /// </summary>
    public interface IElevator
    {
        /// <summary>
        /// Direction of moving for this elevator
        /// </summary>
        ElevatorDirection Direction { get; }

        /// <summary>
        /// Calls the elevator
        /// </summary>
        /// <param name="callingFloor">The floor number that is calling</param>
        /// <param name="direction">Direction of call</param>
        /// <returns></returns>  
        Task CallElevatorAsync(int callingFloor, ElevatorDirection direction);


        Task TakePeopleOff(List<Person> listOfPeople);

        /// <summary>
        /// Takes on people.
        /// </summary>
        /// <param name="listOfPeople">List of people for onboarding.</param>
        /// <returns>List of people that have managed to onboard.</returns>
        Task<List<Person>> TakePeopleOn(List<Person> listOfPeople);

        /// <summary>
        /// Private method which simulates moving elevator
        /// </summary>
        /// <param name="callingFloor">The floor number that is calling</param>
        /// /// <param name="isCallingFloorFinalDestination">If this is true, once it gets there will go in Standing mode.</param>
        Task MoveElevatorAsync(int callingFloor, bool isCallingFloorFinalDestination = false);

        /// <summary>
        /// Returns this eleveator as a string for printing
        /// </summary>
        /// <returns>String</returns>
        string ToString();
    }
}