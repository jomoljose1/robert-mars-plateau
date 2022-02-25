using Robot.core;

namespace Robot.common
{
    public class TwoDMovableObject : I2DMovableObject
    {
        public event Action<I2DMovableObject>? OnMoved;
        public event Action<I2DMovableObject>? OnStopped;
        public event Action<I2DMovableObject>? OnMove;
        public event Action<I2DMovableObject>? OnCommandsEnd;

        public I2DPosition CurrentPosition { get; private set; }
        public I2DPosition NextPosition { get; private set; }
        public I2DPosition Origin { get; set; }
        public Commands NextCommand { get; set; }
        public Commands LastCommand { get; set; }
        private I2DPosition ZeroOrigin { get; set; } = new TwoDPosition { X = 0, Y = 0, Direction = Direction.North };
        private List<Commands> CommandSequences { get; set; }
        public TwoDMovableObject() 
        {
            this.Origin = ZeroOrigin.Clone();
            this.CurrentPosition = ZeroOrigin.Clone();
            this.NextPosition = ZeroOrigin.Clone();
            this.LastCommand =  Commands.S;
            this.NextCommand = Commands.S;
            CommandSequences = new List<Commands>();
            this.Reset();
        }
        public bool LoadCommad(char[] commands)
        {
            this.CurrentPosition = this.Origin.Clone();
            this.CommandSequences = commands.Select(m => (Commands)Enum.Parse(typeof(Commands), m.ToString())).ToList();
            return true;
        }

        public bool Start()
        {
            this.CurrentPosition = this.Origin.Clone();
            this.CommandSequences.ForEach(m => Move(m));
            OnCommandsEnd?.Invoke(this);
            return true;
        }

        public bool Move(Commands command)
        {
            this.NextPosition = CalculateNextPosition(command);
            this.NextCommand = command;
            OnMove?.Invoke(this);
            return Set(); ;
        }
        public bool Reset()
        {
            if (Origin == null)
            {
                this.Origin = new TwoDPosition { X = 0, Y = 0,Direction=Direction.North };
            }

            this.NextPosition = this.Origin.Clone();
            return Set();
        }
        public bool Set()
        {
            if (IsThereAnyMovement())
            {
                this.CurrentPosition = this.NextPosition.Clone();
                this.LastCommand = this.NextCommand;
                OnMoved?.Invoke(this);
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public bool Stop()
        {
            this.NextPosition = this.CurrentPosition.Clone();
            OnStopped?.Invoke(this);
            return Set();
        }

        private bool IsThereAnyMovement()
        {
            return CurrentPosition?.X != NextPosition?.X || NextPosition?.Y != CurrentPosition?.Y || NextPosition?.Direction != CurrentPosition?.Direction;
        }

        private I2DPosition CalculateNextPosition(Commands command)
        {
            I2DPosition nextPosition = CurrentPosition.Change(command);
            return nextPosition;
        }

        public override string ToString()
        {
            return $"Origin : {Origin.ToString()}| Current position : {CurrentPosition.ToString()} last command : {this.LastCommand} | next command {this.NextCommand } Next position : {NextPosition.ToString()}";
        }      
    }
}
