using DVT___Challenge.Classes;

namespace DVT___Challenge.Interfaces
{
    /// <summary>
    /// Contract that describes and elevator strategy of onboarding people
    /// </summary>
    public interface IElevatorTakeOnPeopleStrategy
    {
        /// <summary>
        /// Elevator functionality for taking on a list of people
        /// </summary>
        /// <param name="people">List of people that will be attepted to onboard on to elevator</param>
        /// <param name="maxWeight">Elevator max weight </param>
        /// <param name="currentWeight">Elevator current weight</param>
        /// <returns>List of people that have actually managed to onboard, because of total weight of people, and their total weight</returns>
        Task<(List<Person>, decimal)> TakeOnPeopleAsync(List<Person> people, decimal maxWeight, decimal currentWeight);
    }
}
