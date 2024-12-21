using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;

namespace CM4_Core_UnitTest;

[TestClass]
public class PlacesTests
{
    [TestMethod]
    public void CanCreatePlacesInstance()
    {
        IPlaces Pl = new Places();
        Assert.IsNotNull( Pl );
    }
}
