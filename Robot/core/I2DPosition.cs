namespace Robot.core
{
    public interface I2DPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
        I2DPosition Change(Commands commands);
        I2DPosition Clone();
    }
}
