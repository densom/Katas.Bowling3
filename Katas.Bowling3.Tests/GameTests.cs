using NUnit.Framework;
using System.Linq;

namespace Katas.Bowling3.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        [SetUp]
        public void TestSetUp()
        {
            _game = new Game();
        }

        [Test]
        public void Score_NoThrows_ReturnsZero()
        {
            Assert.That(_game.Score(), Is.EqualTo(0));
        }

        [Test]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 1, 1 }, 2)]
        public void Score_OpenFrames_ReturnsPinsKnockedDown(int[] throws, int expectedScore)
        {
            RecordMultipleThrows(throws);
            Assert.That(_game.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_Spare_CalculatesOneBonusBall()
        {
            RecordMultipleThrows(1,9,1);
            
            Assert.That(_game.Score(), Is.EqualTo(12));
        }

        [Test]
        public void Score_Strike_CalculatesTwoBonusBalls()
        {
            RecordMultipleThrows(10,1,1);

            Assert.That(_game.Score(), Is.EqualTo(14));
        }

        [Test]
        public void Score_StrikeFollowedByOneOpenBall_CalculatesOneBonusBall()
        {
            RecordMultipleThrows(10,1);
            Assert.That(_game.Score(), Is.EqualTo(12));
        }

        [Test]
        public void Score_TwoStrikes_30Including1BonusBall()
        {
            RecordMultipleThrows(10, 10);
            Assert.That(_game.Score(), Is.EqualTo(30));
        }

        [Test]
        public void Score_Turkey_60Including3BonusBalls()
        {
            RecordMultipleThrows(10, 10, 10);

            Assert.That(_game.Score(), Is.EqualTo(60));
        }

        [Test]
        public void Score_PerfectGame_300()
        {
            for (int i = 0; i < 12; i++)
            {
                _game.RecordThrow(10);
            }

            Assert.That(_game.Score(), Is.EqualTo(300));
        }

        [Test]
        public void IsSecondBall_InitialState_False()
        {
            Assert.That(_game.IsSecondBall, Is.False);
        }

        [Test]
        public void IsSecondBall_AfterFirstThrow_True()
        {
            _game.RecordThrow(1);
            Assert.That(_game.IsSecondBall, Is.True);
        }

        [Test]
        public void IsSecondBall_AfterStrike_False()
        {
            _game.RecordThrow(10);
            Assert.That(_game.IsSecondBall, Is.False);
        }

        [Test]
        public void IsSpare_OpenFrame_False()
        {
            RecordMultipleThrows(1,1);
            
            Assert.That(_game.IsSpare, Is.False);
        }

        [Test]
        public void IsSpare_SecondBallAndFirstBallEqualTenPins_True()
        {
            RecordMultipleThrows(1,9);

            Assert.That(_game.IsSpare, Is.True);
        }

        [Test]
        public void IsStrike_OpenFrame_False()
        {
            RecordMultipleThrows(1,1);
            
            Assert.That(_game.IsStrike, Is.False);
        }

        [Test]
        public void IsStrike_FirstBallTenPins_True()
        {
            _game.RecordThrow(10);

            Assert.That(_game.IsStrike, Is.True);
        }

        [Test]
        public void IsStrike_SecondBallTenPins_False()
        {
            RecordMultipleThrows(0,10);

            Assert.That(_game.IsStrike, Is.False);
        }


        private void RecordMultipleThrows(params int[] throws)
        {
            throws.ToList().ForEach(_game.RecordThrow);
        }
    }
}