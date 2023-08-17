using DVT___Challenge.Classes;
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Strategies
{
    /// <summary>
    /// Elevator strategy class for taking on a list of people on "First come first served" base
    /// </summary>
    public class FirstComeFirstServedStrategy : IElevatorTakeOnPeopleStrategy
    {
        /// <summary>
        /// Elevator functionality for taking on a list of people on "First come first served" base
        /// </summary>
        /// <param name="people">List of people that will be attepted to onboard on to elevator</param>
        /// <param name="maxWeight">Elevator max weight </param>
        /// <param name="currentWeight">Elevator current weight</param>
        /// <returns>List of people that have actually managed to onboard, because of total weight of people, and their total weight</returns>
        public async Task<(List<Person>, decimal)> TakeOnPeopleAsync(List<Person> people, decimal maxWeight , decimal currentWeight)
        {
            var listOfOnboardedPeople = new List<Person>();

            await Task.Run(() => {

                foreach (Person person in people)
                {
                    if (currentWeight + person.Weight <= maxWeight)
                    {
                        listOfOnboardedPeople.Add(person);
                        currentWeight += person.Weight;
                    }
                }
            });
            
            
            return (listOfOnboardedPeople, currentWeight);
        }
    }
}
