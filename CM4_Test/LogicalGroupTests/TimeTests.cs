using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;

namespace CM4_Core_UnitTest.LogicalGroupTests;

[TestClass]
public class TimeTests
{
    [TestMethod]
    public void CanCreateTimeInstance()
    {
        ITime Ti = new Time();
        Assert.IsNotNull(Ti);
    }
}
