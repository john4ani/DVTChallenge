using DVT___Challenge.Classes;

namespace DVT___Challenge.Interfaces
{
    /// <summary>
    /// Contract/abstraction that defines a Floor
    /// </summary>
    public interface IFloor
    {
        /// <summary>
        /// Gets the list of ppeople on this floor
        /// </summary>
        List<Person> People { get; }
        
        int Index { get; set; }

        /// <summary>
        /// To be called when people were onborded from this floor
        /// into any elevator
        /// </summary>
        /// <param name="onboardedPeople">List of peopele that managed to get onboarded into a elevator</param>
        /// <returns></returns>
        Task OnPeopleOnboardedIntoElevatorAsync(List<Person> onboardedPeople);
    }
}