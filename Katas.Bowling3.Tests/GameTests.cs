using NUnit.Framework;
using System.Linq;

namespace Katas.Bowling3.Tests
{
    [TestFixture]
    public class GameTests
    {

        [Test]
        public void Score_NoThrows_ReturnsZero()
        {
            var game = new Game();
            Assert.That(game.Score(), Is.EqualTo(0));
        }

        [Test]
        [TestCase(new[] { 1 }, 1)]
        [TestCase(new[] { 1, 1 }, 2)]
        public void Score_OpenFrames_ReturnsPinsKnockedDown(int[] throws, int expectedScore)
        {
            var game = new Game();
            throws.ToList().ForEach(game.RecordThrow);
            Assert.That(game.Score(), Is.EqualTo(expectedScore));
        }

        [Test]
        public void Score_Spare_CalculatesOneBonusBall()
        {
            var game = new Game();
            game.RecordThrow(1);
            game.RecordThrow(9);
            game.RecordThrow(1);

            Assert.That(game.Score(), Is.EqualTo(12));
        }

        [Test]
        public void Score_Strike_CalculatesTwoBonusBalls()
        {
            var game = new Game();
            game.RecordThrow(10);
            game.RecordThrow(1);
            game.RecordThrow(1);

            Assert.That(game.Score(), Is.EqualTo(14));
        }

        [Test]
        public void IsSecondBall_InitialState_False()
        {
            var game = new Game();
            Assert.That(game.IsSecondBall, Is.False);
        }

        [Test]
        public void IsSecondBall_AfterFirstThrow_True()
        {
            var game = new Game();
            game.RecordThrow(1);
            Assert.That(game.IsSecondBall, Is.True);
        }

        [Test]
        public void IsSecondBall_AfterStrike_False()
        {
            var game = new Game();
            game.RecordThrow(10);
            Assert.That(game.IsSecondBall, Is.False);
        }

        [Test]
        public void IsSpare_OpenFrame_False()
        {
            var game = new Game();
            game.RecordThrow(1);
            game.RecordThrow(1);

            Assert.That(game.IsSpare, Is.False);
        }

        [Test]
        public void IsSpare_SecondBallAndFirstBallEqualTenPins_True()
        {
            var game = new Game();
            game.RecordThrow(1);
            game.RecordThrow(9);

            Assert.That(game.IsSpare, Is.True);
        }

        [Test]
        public void IsStrike_OpenFrame_False()
        {
            var game = new Game();
            game.RecordThrow(1);
            game.RecordThrow(1);

            Assert.That(game.IsStrike, Is.False);
        }

        [Test]
        public void IsStrike_FirstBallTenPins_True()
        {
            var game = new Game();
            game.RecordThrow(10);

            Assert.That(game.IsStrike, Is.True);
        }

        [Test]
        public void IsStrike_SecondBallTenPins_False()
        {
            var game = new Game();
            game.RecordThrow(0);
            game.RecordThrow(10);

            Assert.That(game.IsStrike, Is.False);
        }

    }
}