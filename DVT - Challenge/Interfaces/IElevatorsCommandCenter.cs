using DVT___Challenge.Classes;

namespace DVT___Challenge.Interfaces
{
    public interface IElevatorsCommandCenter
    {
        Task<int> CallElevatorOnFloorAsync(int floorIndex, ElevatorDirection elevatorDirection);
        Task LoadPeopleIntoElevatorAsync(int elevatorIndex, int floorIndex);
        Task MoveElevatorAsync(int elevatorIndex, int floorIndex, bool isCallingFloorFinalDestination = false);
        Task ShowElevatorsStatusOnConsoleAsync();
        Task UnloadPeopleFromElevatorAsync(int elevatorIndex, List<Person> people);
    }
}