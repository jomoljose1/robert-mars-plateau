using Robot.core;

namespace Robot.common
{
    public class TwoDMovingObjectBoundary : I2DMovigObjectBoundary
    {
        public int Height { get; set; }
        public int Width { get; set; }

        List<I2DMovableObject> movingItems = new List<I2DMovableObject>();

        public TwoDMovingObjectBoundary(int height,int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public void Attach(I2DMovableObject movableObject)
        {
            movableObject.Origin = new TwoDPosition { X = 1, Y = 1, Direction = Direction.North };
            movableObject.OnMove += MovableObject_OnMove;
            movableObject.OnCommandsEnd += MovableObject_OnCommandsEnd;
            movingItems.Add(movableObject);
        }

        private void MovableObject_OnCommandsEnd(I2DMovableObject obj)
        {
            Console.WriteLine(obj.CurrentPosition.ToString());
        }

        private void MovableObject_OnMove(I2DMovableObject c)
        {
            if (!IsInsideBoundary(c.NextPosition))
            { 
              c.Stop();
            }
        }

        public bool IsInsideBoundary(I2DPosition position)
        {
            return (position.X > 0 && position.X <= this.Width) && (position.Y > 0 && position.Y < this.Height);
        }

        public bool StartAllItems()
        {
            Parallel.ForEach(movingItems, item => item.Start());
            return true;
        }
    }
}
