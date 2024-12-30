using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;

namespace CM4_Core_UnitTest.LogicalGroupTests;

[TestClass]
public class ThingsTests
{
    [TestMethod]
    public void CanCreateThingsInstance()
    {
        IThings T = new Things();
        Assert.IsNotNull(T);
    }
}
