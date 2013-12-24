using NUnit.Framework;

namespace Katas.Bowling3.Tests
{
    [TestFixture]
    public class FrameTests
    {
        [Test]
        public void NewFrame_Defaults()
        {
            var frame = new Frame();
            Assert.That(frame.FrameNumber, Is.EqualTo(1));
            Assert.That(frame.Score, Is.EqualTo(0));
        }
    }
}