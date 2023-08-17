using System.ComponentModel.DataAnnotations;


namespace DVT___Challenge
{
    /// <summary>
    /// Enumeration that defines 3 possible states in which 
    /// an elevator can be.
    /// 
    /// This is a basic implementation, following KISS Principle. This is my "default" mode and first implementation when details are not all clear.
    ///
    /// Bellow I prezent an alternative and more advaced approach, that adhers better to OOP.
    /// </summary>
    public enum ElevatorDirection
    {
        [Display(Name = "Standing")]
        Standing,

        [Display(Name = "Moving Up")]
        MovingUp,

        [Display(Name = "Moving Down")]
        MovingDown,
    }

    ///Althernative is to have classes that describes each of the elevator states
    ///As POC, I'm not using async here
    public interface IElevatorState 
    {
        IElevatorState CallElevatorUp(Action callElevatorAction);
        IElevatorState CallElevatorDown(Action callElevatorAction);
    }

    public class Standing : IElevatorState
    {        
        public IElevatorState CallElevatorUp(Action callElevatorAction)
        {
            callElevatorAction();
            return new MovingUp();
        }

        public IElevatorState CallElevatorDown(Action callElevatorAction)
        {
            callElevatorAction();
            return new MovingDown();
        }

        public override string ToString()
        {
            return string.Format($"The elevator status is Standing.");
        }
    }

    public class MovingUp : IElevatorState
    {
        public IElevatorState CallElevatorUp(Action callElevatorAction)
        {
            return this;
        }

        public IElevatorState CallElevatorDown(Action callElevatorAction)
        {
            return this;
        }

        public override string ToString()
        {
            return string.Format($"The elevator status is Moving Up.");
        }
    }

    public class MovingDown : IElevatorState
    {
        public IElevatorState CallElevatorUp(Action callElevatorAction)
        {
            return this;
        }

        public IElevatorState CallElevatorDown(Action callElevatorAction)
        {
            return this;
        }

        public override string ToString()
        {
            return string.Format($"The elevator status is Moving Down.");
        }
    }

    //the elevator will have a state instead of ElevatorDirection
    public class ElevatorX //: IElevator
    {
        private IElevatorState _elevatorState;

        public ElevatorX()
        {
            _elevatorState = new Standing();
        }

        public void CallElevatorUp()
        {
            //I hope this  gives you an idea on how the code will change 
            _elevatorState = _elevatorState.CallElevatorUp(() => { /*some actions to executed*/ });
        }
    }

    //If you will like to see this version, I'm more than happy to provide this on request.
}
