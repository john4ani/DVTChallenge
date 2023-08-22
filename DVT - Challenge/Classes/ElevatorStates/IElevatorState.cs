
using DVT___Challenge.Interfaces;

namespace DVT___Challenge.Classes.ElevatorStates
{
    public interface IElevatorState
    {
        IElevatorState CallElevatorUp();
        IElevatorState CallElevatorDown();
        Task<IElevatorState> MoveElevatorAsync(Func<int, Task> moveElevatorAction);
    }
}
