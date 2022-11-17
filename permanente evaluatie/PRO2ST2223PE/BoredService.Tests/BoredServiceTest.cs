using PRO2ST2223PE;
using Moq;
using System;
using System.Diagnostics;

namespace PRO2ST2223PE.Tests
{
    [TestClass]
    public class BoredServiceTest
    {
        [TestMethod]
        public void BoredRandom_Returns_Lets_Do_Some_If_Two_Participants()
        {
            var boredApiService = new Mock<IBoredApiService>();

            var boredResponse = new BoredResponse() { Activity="test", Participants=2};
            boredApiService.Setup(x => x.GetBoredResponse()).Returns(boredResponse);

            var boredService = new BoredService(new Random(), boredApiService.Object);
            boredService.BoredVullen();

            var expected = "Let's do some => test";
            var result = boredService.BoredRandom();
            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void BoredRandom_Returns_Not_Enough_Friends_If_Participants_Above_Two()
        {
            var boredApiService = new Mock<IBoredApiService>();

            var boredResponse = new BoredResponse() { Activity = "test", Participants = 3 };
            boredApiService.Setup(x => x.GetBoredResponse()).Returns(boredResponse);

            var boredService = new BoredService(new Random(), boredApiService.Object);
            boredService.BoredVullen();

            var expected = "I don't have enough friends to => test";
            var result = boredService.BoredRandom();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BoredVullen_Fills_BoredInMemoryDb_With_Ten_BoredResponses()
        {
            var boredApiService = new Mock<IBoredApiService>();

            var boredResponse = new BoredResponse() { Activity = "test" };
            boredApiService.Setup(x => x.GetBoredResponse()).Returns(boredResponse);

            var boredService = new BoredService(new Random(), boredApiService.Object);
            boredService.BoredVullen();

            var result = BoredInMemoryDb.boredResponses.Count;
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void BoredVullen_Fills_BoredInMemoryDb_With_Correct_BoredResponses()
        {
            var boredApiService = new Mock<IBoredApiService>();

            var boredResponse = new BoredResponse() { Activity = "test" };
            boredApiService.Setup(x => x.GetBoredResponse()).Returns(boredResponse);

            var boredService = new BoredService(new Random(), boredApiService.Object);
            boredService.BoredVullen();

            foreach (var response in BoredInMemoryDb.boredResponses)
            {
                Assert.AreEqual("test", response.Activity);
            }
        }

        [TestMethod]
        public void BoredRandom_Returns_A_Random_BoredResponse()
        {
            var random = new Mock<Random>();
            random.Setup(x => x.Next(10)).Returns(2);
            
            var boredApiService = new Mock<IBoredApiService>();
            var boredResponse = new BoredResponse() { Activity = "test", Participants = 3 };
            boredApiService.Setup(x => x.GetBoredResponse()).Returns(boredResponse);

            var boredService = new BoredService(random.Object, boredApiService.Object);
            boredService.BoredVullen();

            var secondBoredResponse = new BoredResponse() { Activity = "test2", Participants = 3 };
            BoredInMemoryDb.boredResponses[2] = secondBoredResponse;

            var expected = "I don't have enough friends to => test2";
            var result = boredService.BoredRandom();
            Assert.AreEqual(expected, result);
        }
    }
}