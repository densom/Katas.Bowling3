using System;

namespace Katas.Bowling3
{
    public class Game
    {
        private int _score;
        private int _bonusBallsEarned;
        private int _previousThrowNumberOfPinsKnockedDown;
        private int _numberOfPinsKnockedDown;

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
            _numberOfPinsKnockedDown = numberOfPinsKnockedDown;

            _score += numberOfPinsKnockedDown;

            CreditUpToTwoPendingBonusBalls();
            UpdateNewlyEarnedBonusBalls();
            SetIsSecondBallStatus();

            _previousThrowNumberOfPinsKnockedDown = numberOfPinsKnockedDown;
        }

        private void UpdateNewlyEarnedBonusBalls()
        {
            if (IsSpare())
            {
                _bonusBallsEarned += 1;
            }
        }

        private bool IsSpare()
        {
            return (_previousThrowNumberOfPinsKnockedDown + _numberOfPinsKnockedDown) == 10;
        }

        private void CreditUpToTwoPendingBonusBalls()
        {
            if (_bonusBallsEarned > 0)
            {
                _score += _numberOfPinsKnockedDown;
                _bonusBallsEarned -= 1;    
            }
            
        }

        private void SetIsSecondBallStatus()
        {
            IsSecondBall = !IsSecondBall;

            if (_numberOfPinsKnockedDown == 10)
            {
                IsSecondBall = false;
            }
        }
    }
}