using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Floor class functionality
    /// </summary>
    public class Floor : IFloor
    {
        private readonly List<Person> _people;

        /// <summary>
        /// Floor default constructor
        /// </summary>
        /// <param name="people">List of people on this floor</param>
        public Floor(List<Person> people)
        {
            _people = people;
        }

        /// <summary>
        /// Gets the list of ppeople on this floor
        /// </summary>
        public List<Person> People { get { return _people; } }

        /// <summary>
        /// To be called when people were onborded from this floor
        /// into any elevator
        /// </summary>
        /// <param name="onboardedPeople">List of peopele that managed to get onboarded into a elevator</param>
        /// <returns></returns>
        public async Task OnPeopleOnboardedIntoElevatorAsync(List<Person> onboardedPeople)
        {
            await Task.Run(() =>
            {

                foreach (var person in onboardedPeople)
                {
                    _people.Remove(person);
                }

            });
        }
    }
}