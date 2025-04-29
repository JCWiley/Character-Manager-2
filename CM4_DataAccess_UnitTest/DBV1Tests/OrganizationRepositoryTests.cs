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
    public async Task Repository_CanUpdateOrganziation_Name()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Name = "Test";
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Name == "Test");
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Description()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Description = "Test";
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Description == "Test");
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Goals()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Goals = "Test";
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Goals == "Test");
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Quirks()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Quirks = "Test";
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Quirks == "Test");
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Size()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        organization.Size = 1;
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Size == 1);
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_PrimarySpecies()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.PrimarySpecies = TestGuid;
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.PrimarySpecies == TestGuid);
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Location()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.Location = TestGuid;
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Location == TestGuid);
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Leader()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.Leader = TestGuid;
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Leader == TestGuid);
    }


    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Child_Characters()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.Child_Characters.Add(TestGuid);
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Child_Characters.Contains(TestGuid));
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Child_Organizations()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.Child_Organizations.Add(TestGuid);
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Child_Organizations.Contains(TestGuid));
    }

    [TestMethod]
    public async Task Repository_CanUpdateOrganziation_Parent_Organizations()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Guid TestGuid = new Guid();
        organization.Parent_Organizations.Add(TestGuid);
        DA.Repository.Update(organization);
        Organization organization2 = DA.Repository.Get<Organization>(organization.ID);
        Assert.IsTrue(organization2.Parent_Organizations.Contains(TestGuid));
    }
}
