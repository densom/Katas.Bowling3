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

        internal bool IsSecondBall { get; private set; }
        internal bool IsSpare { get; private set; }
        internal bool IsStrike { get; private set; }


        public Game()
        {
            IsSpare = false;
            IsStrike = false;
        }

        public void RecordThrow(int numberOfPinsKnockedDown)
        {
            _numberOfPinsKnockedDown = numberOfPinsKnockedDown;

            _score += numberOfPinsKnockedDown;

            SetIsSpare();
            SetIsStrike();

            CreditUpToTwoPendingBonusBalls();
            UpdateNewlyEarnedBonusBalls();
            SetIsSecondBallStatus();

            _previousThrowNumberOfPinsKnockedDown = numberOfPinsKnockedDown;
        }

        private void UpdateNewlyEarnedBonusBalls()
        {

            if (IsSpare)
            {
                _bonusBallsEarned += 1;
            }

            if (IsStrike)
            {
                _bonusBallsEarned += 2;
            }
        }

        internal void SetIsSpare()
        {
            if (((_previousThrowNumberOfPinsKnockedDown + _numberOfPinsKnockedDown) == 10) && IsSecondBall)
            {
                IsSpare = true;
                return;
            }

            IsSpare = false;
        }

        internal void SetIsStrike()
        {
            if (_numberOfPinsKnockedDown == 10 && !IsSecondBall)
            {
                IsStrike = true;
                return;
            }

            IsStrike = false;

        }

        private void CreditUpToTwoPendingBonusBalls()
        {
            int iterations = 2;

            while (_bonusBallsEarned > 0 && iterations > 0)
            {
                _score += _numberOfPinsKnockedDown;
                _bonusBallsEarned -= 1;
                iterations--;
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