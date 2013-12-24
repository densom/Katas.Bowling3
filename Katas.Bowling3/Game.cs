using System;

namespace Katas.Bowling3
{
    public class Game
    {
        private int _score = 0;

        public int Score()
        {
            return _score;
        }

        public int FrameNumber
        {
            get { return 1; }
        }

        public void RecordThrow(int numberOfPinsKnockedDown)
        {
            _score += numberOfPinsKnockedDown;
        }
    }
}