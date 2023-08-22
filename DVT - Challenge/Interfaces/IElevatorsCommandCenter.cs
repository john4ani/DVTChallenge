using DVT___Challenge.Classes;

namespace DVT___Challenge.Interfaces
{
    public interface IElevatorsCommandCenter
    {
        Task<int> CallElevatorUpAsync(int floorIndex);
        Task<int> CallElevatorDownAsync(int floorIndex);
        Task LoadPeopleIntoElevatorAsync(int elevatorIndex, int floorIndex);
        Task ShowElevatorsStatusOnConsoleAsync();
        Task UnloadPeopleFromElevatorAsync(int elevatorIndex, List<Person> people);
    }
}