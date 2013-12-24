using NUnit.Framework;
using System.Linq;

namespace Katas.Bowling3.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        [Ignore]
        public void Game_Defaults()
        {
            var game = new Game();
            Assert.That(game.Score(), Is.EqualTo(0));
            Assert.That(game.FrameNumber, Is.EqualTo(1));
        }

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
    }
}