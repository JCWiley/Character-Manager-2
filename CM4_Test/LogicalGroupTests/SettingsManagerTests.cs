using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using CM4_Core.Service;
using Moq;

namespace CM4_Core_UnitTest;

[TestClass]
public class SettingsManagerTests
{
    [TestMethod]
    public void CanCreateSettingsManager()
    {
        Mock<IDataAccess> dataAccess = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();

        ISettingsManager sm = new SettingsManager(dataAccess.Object,notifyService.Object);
    }
}
