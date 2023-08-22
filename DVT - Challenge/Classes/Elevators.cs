using DVT___Challenge.Classes.ElevatorStates;
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes
{
    /// <summary>
    /// Defines a collections of Elevators  
    /// Cleans and encapsulates Elevators functionality better
    /// </summary>
    public class Elevators
    {
        private IEnumerable<KeyValuePair<int, IElevator>> _elevatorsIndexElevatorMap;

        public Elevators(IEnumerable<KeyValuePair<int, IElevator>> elevatorsIndexElevatorMap)
        {
            _elevatorsIndexElevatorMap = elevatorsIndexElevatorMap;
        }

        /// <summary>
        /// This is not best shape from performance point of view
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IElevator this[int index] => _elevatorsIndexElevatorMap.First(keyValue => keyValue.Key == index).Value;

        public Elevators GetAvailables() 
        {
            var temp = _elevatorsIndexElevatorMap
                .Where(e => e.Value.State.GetType().Equals(typeof(Standing)));
            return new Elevators(temp);   
            

        }

        public KeyValuePair<int, IElevator> GetNearest(int floorIndex)
        {
            //get the nearest elevator based on floor distance 
            return _elevatorsIndexElevatorMap
                .Aggregate((best, current) => Math.Abs(floorIndex - best.Value.CurrentFloor.Index) < Math.Abs(floorIndex - current.Value.CurrentFloor.Index) ? best : current);
        }

        /// <summary>
        /// Prints the Elevators to console
        /// </summary>
        /// <returns>String</returns>
        public async Task PrintToConsoleAsync()
        {
            await Task.Run(() =>
            {
                foreach (var elevator in _elevatorsIndexElevatorMap)
                {
                    Console.WriteLine(elevator.Value.ToString());
                }
            });
        }

        
    }
}
