using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;

namespace CM4_Core_UnitTest.LogicalGroupTests;

[TestClass]
public class PlacesTests
{
    [TestMethod]
    public void CanCreatePlacesInstance()
    {
        IPlaces Pl = new Places();
        Assert.IsNotNull(Pl);
    }
}
