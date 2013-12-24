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

        internal bool IsSecondBall { get; private set; }

        public void RecordThrow(int numberOfPinsKnockedDown)
        {
            _score += numberOfPinsKnockedDown;

            SetIsSecondBallStatus(numberOfPinsKnockedDown);
        }

        private void SetIsSecondBallStatus(int numberOfPinsKnockedDown)
        {
            IsSecondBall = !IsSecondBall;

            if (numberOfPinsKnockedDown == 10)
            {
                IsSecondBall = false;
            }
        }
    }
}