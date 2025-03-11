using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_DataAccess.DBV1;
using Moq;
using System.Linq;

namespace CM4_DataAccess_UnitTest;

[TestClass]
public class OrganizationRepositoryTests
{
    static IDataAccess DA;
    [ClassInitialize]
    public static void GeneralRepositoryTestsInitialize(TestContext testContext)
    {
        Mock<INotifyService> notifyService = new();
        Mock<ISettingsService> settingsService = new();
        DA = new DataAccessV1(notifyService.Object, settingsService.Object);
        DA.CreateDataStore(@"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\OrgRepoTestDB.db");
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziationName()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Name = "Test";
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Name == "Test");
    }
}
