using System;

namespace Katas.Bowling3
{
    public class Game
    {
        private int _score;
        private int _bonusBallsEarned;
        private int _bonusBallsEarnedForSecondFrame;
        private int _previousThrowNumberOfPinsKnockedDown;
        private int _numberOfPinsKnockedDown;
        private int _currentFrameNumber = 1;

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
            UpdateFrameNumber();

            _previousThrowNumberOfPinsKnockedDown = numberOfPinsKnockedDown;
        }

        private void UpdateFrameNumber()
        {
            if (!IsSecondBall && _currentFrameNumber < 10)
            {
                _currentFrameNumber++;
            }
        }

        private void UpdateNewlyEarnedBonusBalls()
        {

            if (_currentFrameNumber == 10)
            {
                return;
            }

            if (IsSpare || IsStrike)
            {
                _bonusBallsEarned += 1;
            }

            if (IsStrike)
            {
                _bonusBallsEarnedForSecondFrame += 1;
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
            CreditCurrentBonusBalls();
            MoveBonusBallsEarnedForSecondFrameToCurrentBonusBalls();
        }

        private void MoveBonusBallsEarnedForSecondFrameToCurrentBonusBalls()
        {
            _bonusBallsEarned += _bonusBallsEarnedForSecondFrame;
            _bonusBallsEarnedForSecondFrame = 0;
        }

        private void CreditCurrentBonusBalls()
        {
            _score += _numberOfPinsKnockedDown * _bonusBallsEarned;
            _bonusBallsEarned = 0;
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