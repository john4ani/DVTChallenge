
namespace DVT___Challenge.Classes.ElevatorStates
{
    public class MovingUp : IElevatorState
    {
        public IElevatorState CallElevatorUp()
        {
            return this;
        }

        public IElevatorState CallElevatorDown()
        {
            return this;
        }

        public async Task<IElevatorState> MoveElevatorAsync(Func<int, Task> moveElevatorAction)
        {
            await moveElevatorAction(MovingIncrement);
            return new Standing();
        }

        private int MovingIncrement => 1;

        public override string ToString()
        {
            return string.Format($"Moving Up");
        }
    }
}
