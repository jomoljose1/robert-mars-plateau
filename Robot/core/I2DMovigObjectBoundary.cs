namespace Robot.core
{
    public interface I2DMovigObjectBoundary
    {
        int Height { get; set; }
        int Width { get; set; }

        bool IsInsideBoundary(I2DPosition position);
        void Attach(I2DMovableObject movableObject);
    }
}
