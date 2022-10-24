using Moq;
using OefeningMockingWeekend;

namespace MockingWeekend.tests;

[TestClass]
public class GreeterTests
{
    [TestMethod]
    public void GetMessage_Returns_Party_If_Weekend()
    {
        var dateGetter = new Mock<IDateGetter>();
        dateGetter.Setup(x => x.GetDate()).Returns(new DateTime(2022, 10, 22));
        var greeter = new Greeter(dateGetter.Object);
        var result = greeter.GetMessage();
        Assert.AreEqual("Party time.....it's weekend", result);
    }

    [TestMethod]
    public void GetMessage_Returns_Work_Hard_If_Weekday()
    {
        var dateGetter = new Mock<IDateGetter>();
        dateGetter.Setup(x => x.GetDate()).Returns(new DateTime(2022, 10, 20));
        var greeter = new Greeter(dateGetter.Object);
        var result = greeter.GetMessage();
        Assert.AreEqual("Work hard, weekend is on his way....", result);
    }
}