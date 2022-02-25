namespace Robot.core
{
    public interface I2DMovableObject
    {
        event Action<I2DMovableObject> OnMoved;
        event Action<I2DMovableObject> OnStopped;
        event Action<I2DMovableObject> OnMove;
        event Action<I2DMovableObject> OnCommandsEnd;

        public I2DPosition CurrentPosition { get; }
        public I2DPosition NextPosition { get; }
        public I2DPosition Origin { get; set; }
        public Commands NextCommand { get; set; }
        public Commands LastCommand { get; set; }
        public bool LoadCommad(char[] commands);
        public bool Start();
        bool Move(Commands command);
        bool Set();
        bool Stop();
        bool Reset();
    }
}
