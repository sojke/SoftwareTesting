using Moq;

namespace UnitTestingDependencies.Tests
{
    [TestClass]
    public class NumberGameTests
    {
        [TestMethod]
        public void RateGuess_Returns_2_When_Guess_Is_Correct_Moq()
        {
            var die = new Mock<IDie>();
            die.Setup(x => x.Roll()).Returns(5);
            var numberGame = new NumberGame(die.Object);
            var result = numberGame.RateGuess(5);
            Assert.AreEqual(2, result);
        }



    }
}