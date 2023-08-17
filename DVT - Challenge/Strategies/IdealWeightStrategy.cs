using DVT___Challenge.Classes;
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Strategies
{
    /// <summary>
    /// Elevator strategy class for taking on a list of people based on indeal weight + max number of people
    /// </summary>
    public class IdealWeightStrategy : IElevatorTakeOnPeopleStrategy
    {
        /// <summary>
        /// Elevator functionality for taking on a list of people based on indeal weight + max number of people
        /// </summary>
        /// <param name="people">List of people that will be attepted to onboard on to elevator</param>
        /// <param name="maxWeight">Elevator max weight </param>
        /// <param name="currentWeight">Elevator current weight</param>
        /// <returns>List of people that have actually managed to onboard, because of total weight of people, and their total weight</returns>
        public async Task<(List<Person>, decimal)> TakeOnPeopleAsync(List<Person> people, decimal maxWeight, decimal currentWeight)
        {
            List<Person> optimalList = new List<Person>();

            await Task.Run(() =>
            {

                ///Knapsack Problem - refrence Internet
                int n = people.Count;
                int[,] matrix = new int[n + 1, (int)maxWeight + 1];

                for (int i = 1; i <= n; i++)
                {
                    for (int w = 0; w <= (int)maxWeight; w++)
                    {
                        if (people[i - 1].Weight <= w)
                        {
                            matrix[i, w] = Math.Max(matrix[i - 1, w], matrix[i - 1, w - (int)people[i - 1].Weight] + 1);
                        }
                        else
                        {
                            matrix[i, w] = matrix[i - 1, w];
                        }
                    }
                }

                
                int weightLeft = (int)maxWeight;
                for (int i = n; i >= 1; i--)
                {
                    if (matrix[i, weightLeft] != matrix[i - 1, weightLeft])
                    {
                        optimalList.Add(people[i - 1]);
                        weightLeft -= (int)people[i - 1].Weight;
                        currentWeight += people[i - 1].Weight;
                    }
                }
                
            });

            return (optimalList, currentWeight);
        }

    }
}

