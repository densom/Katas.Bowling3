namespace Katas.Bowling3
{
    public class Frame
    {
        public Frame()
        {
            FrameNumber = 1;
        }

        public int FrameNumber { get; set; }
        public int Score { get; private set; }
    }
}