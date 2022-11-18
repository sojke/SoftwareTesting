using NUnit.Framework;
using BowlingGameScore;

namespace BowlingGameScoreTests
{
    [TestFixture]
    public class BowlingGameScoreTests
    {
        private BowlingGame game;

        [SetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        [Test]
        public void When_Roll_GlutterGame_Returns_0()
        {
            for (int i = 0; i < 20; i++)
            {
                game.Roll(0);
            }
            var resultaat = game.Score;
            var verwacht = 0;
            Assert.AreEqual(resultaat, verwacht);
        }

        [Test]
        public void When_Roll_AllOnes_Returns_20()
        {
            for (int i = 0; i < 20; i++)
            {
                game.Roll(1);
            }
            var resultaat = game.Score;
            var verwacht = 20;
            Assert.AreEqual(resultaat, verwacht);
        }

        [Test]
        public void When_Roll_SpareAndThree_Returns_16()
        {
            game.Roll(3);
            game.Roll(7);
            game.Roll(3); 
            for (int i = 0; i < 17; i++)
            {
                game.Roll(0);
            }
            var resultaat = game.Score;
            var verwacht = 16;
            Assert.AreEqual(resultaat, verwacht);
        }

        [Test]
        public void When_Roll_StrikeAndThreeAndFour_Returns_24()
        {
            game.Roll(10);
            game.Roll(3);
            game.Roll(4);
            for (int i = 0; i < 16; i++)
            {
                game.Roll(0);
            }
            var resultaat = game.Score;
            var verwacht = 24;
            Assert.AreEqual(resultaat, verwacht);
        }
        [Test]
        public void When_Roll_PerfectGame_Returns_300()
        {
            for (int i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            var resultaat = game.Score;
            var verwacht = 300;
            Assert.AreEqual(resultaat, verwacht);
        }   
    }
}