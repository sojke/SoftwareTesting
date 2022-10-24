using MockingOpenWeather;
using Moq;

namespace OpenWeather.Tests
{
    [TestClass]
    public class WeatherServiceTests
    {
        [TestMethod]
        public void GetCurrentTemperatureInAntwerp_Returns_Freezing_If_Bellow_Zero()
        {
            var openWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            openWeatherMapApi.Setup(x => x.GetCurrentTemperatureInAntwerp()).Returns(-1);
            var weatherService = new WeatherService(openWeatherMapApi.Object);
            var result = weatherService.GetCurrentWeatherInAntwerp();
            Assert.AreEqual("Brrrr, it's freezing", result);
        }

        [TestMethod]
        public void GetCurrentTemperatureInAntwerp_Returns_cold_If_Bellow_Fifteen()
        {
            var openWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            openWeatherMapApi.Setup(x => x.GetCurrentTemperatureInAntwerp()).Returns(11);
            var weatherService = new WeatherService(openWeatherMapApi.Object);
            var result = weatherService.GetCurrentWeatherInAntwerp();
            Assert.AreEqual("It's cold", result);
        }

        [TestMethod]
        public void GetCurrentTemperatureInAntwerp_Returns_cold_If_Bellow_Twentyfour()
        {
            var openWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            openWeatherMapApi.Setup(x => x.GetCurrentTemperatureInAntwerp()).Returns(20);
            var weatherService = new WeatherService(openWeatherMapApi.Object);
            var result = weatherService.GetCurrentWeatherInAntwerp();
            Assert.AreEqual("It's ok", result);
        }

        [TestMethod]
        public void GetCurrentTemperatureInAntwerp_Returns_cold_If_Above_Twentyfour()
        {
            var openWeatherMapApi = new Mock<IOpenWeatherMapApi>();
            openWeatherMapApi.Setup(x => x.GetCurrentTemperatureInAntwerp()).Returns(28);
            var weatherService = new WeatherService(openWeatherMapApi.Object);
            var result = weatherService.GetCurrentWeatherInAntwerp();
            Assert.AreEqual("It's HOT!!!", result);
        }
    }
}