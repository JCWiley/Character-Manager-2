using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using Moq;

namespace CM4_Core_UnitTest;

[TestClass]
public class SettingsManagerTests
{
    [TestMethod]
    public void CanCreateSettingsManager()
    {
        Mock<IDataAccess> dataAccess = new Mock<IDataAccess>();

        ISettingsManager sm = new SettingsManager(dataAccess.Object);
    }
}
