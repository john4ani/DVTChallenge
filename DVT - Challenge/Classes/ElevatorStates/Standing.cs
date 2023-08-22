
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes.ElevatorStates
{
    public class Standing : IElevatorState
    {
        public IElevatorState CallElevatorUp()
        {
            return new MovingUp();
        }

        public IElevatorState CallElevatorDown()
        {
            return new MovingDown();
        }

        public async Task<IElevatorState> MoveElevatorAsync(Func<int, Task> moveElevatorAction)
        {
            return this;
        }

        public int MovingIncrement => 0;

        public override string ToString()
        {
            return string.Format($"Standing");
        }
    }
}
