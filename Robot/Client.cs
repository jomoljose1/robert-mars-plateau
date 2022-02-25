using Robot.common;

namespace Robot
{
    public class Client
    {
        public void Test()
        {
            TwoDMovingObjectBoundary terrain = new TwoDMovingObjectBoundary(5, 5);
            TwoDMovableObject robot = new TwoDMovableObject();
            robot.LoadCommad("FFRFLFLF".ToArray());
            terrain.Attach(robot);

            robot.Start();
        }
        
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "LRF";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public int GetRandomNumber(int minimum, int maximum)
        {
            Random random = new Random();
            return  Convert.ToInt32(random.NextDouble() * (maximum - minimum)) + minimum;
        }
    }
}
