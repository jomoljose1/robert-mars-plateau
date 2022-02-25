using Robot.core;

namespace Robot.common
{
    internal class TwoDPosition : I2DPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction Direction { get; set; }
        public I2DPosition Change(Commands commands)
        {
            I2DPosition nextPosition = (TwoDPosition)this.MemberwiseClone();
            if (commands == Commands.F)
            {
                nextPosition = Move(nextPosition);
            }
            else if(commands == Commands.L || commands == Commands.R)
            {
                nextPosition = Rotate(nextPosition, commands);
            }
            return nextPosition;
        }
        private I2DPosition Move(I2DPosition nextPosition)
        {
            switch (this.Direction)
            {
                case Direction.North:
                    nextPosition.Y++;
                    break;
                case Direction.South:
                    nextPosition.Y--;
                    break;
                case Direction.East:
                    nextPosition.X++;
                    break;
                case Direction.West:
                    nextPosition.X--;
                    break;
            }
            return nextPosition;
        }
        private I2DPosition Rotate(I2DPosition nextPosition,Commands command)
        {
            switch (this.Direction)
            {
                case Direction.North:
                    if (command == Commands.L)
                    {
                        nextPosition.Direction = Direction.West;
                    }
                    else 
                    {
                        nextPosition.Direction = Direction.East;
                    }
                    break;
                case Direction.South:
                    if (command == Commands.L)
                    {
                        nextPosition.Direction = Direction.East;
                    }
                    else
                    {
                        nextPosition.Direction = Direction.West;
                    }
                    break;
                case Direction.East:
                    if (command == Commands.L)
                    {
                        nextPosition.Direction = Direction.North;
                    }
                    else
                    {
                        nextPosition.Direction = Direction.South;
                    }
                    break;
                case Direction.West:
                    if (command == Commands.L)
                    {
                        nextPosition.Direction = Direction.South;
                    }
                    else
                    {
                        nextPosition.Direction = Direction.North;
                    }
                    break;
            }
            return nextPosition;
        }

        public override string ToString()
        {
            return $" X:{this.X}, Y:{this.Y}, Direction : {this.Direction.ToString()}";
        }

        public I2DPosition Clone()
        {
            return (I2DPosition)this.MemberwiseClone();
        }
    }
}
