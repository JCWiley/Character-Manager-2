using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_DataAccess.DBV1;
using Moq;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_DataAccess_UnitTest;

[TestClass]
public class DataModelRepoTests
{
    static IDataAccess DA;

    [ClassInitialize]
    public static async Task GeneralRepositoryTestsInitializeAsync(TestContext testContext)
    {
        Mock<INotifyService> notifyService = new();
        Mock<ISettingsService> settingsService = new();
        DA = new DataAccessV1(notifyService.Object, settingsService.Object);
        DA.CreateDataStore(@"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\DataModelRepoTestsDB.db");
    }

    [TestMethod]
    public async Task ModelParametersPersist_OrganizationAsync()
    {
        Organization organization = await DA.Repository.Add<Organization>();
        Assert.IsNotNull(organization);

        string test_Name = "Test Name";
        string test_Description = "Test Description";
        string test_Goals = "Test Goals";
        int test_Size = 1;
        string test_Quirks = "Test Quirks";

        List<Guid> test_Child_Characters = new List<Guid>();
        List<Guid> test_Child_Organizations = new List<Guid>();
        List<Guid> test_Parent_Organizations = new List<Guid>();

        Guid test_Location = Guid.NewGuid();
        Guid test_Species = Guid.NewGuid();
        Guid test_Leader = Guid.NewGuid();

        test_Child_Characters.Add(Guid.NewGuid());
        test_Child_Organizations.Add(Guid.NewGuid());
        test_Parent_Organizations.Add(Guid.NewGuid());

        organization.Name = test_Name;
        organization.Description = test_Description;
        organization.Goals = test_Goals;
        organization.Quirks = test_Quirks;
        organization.Size = test_Size;
        organization.Location = test_Location;
        organization.PrimarySpecies = test_Species;
        organization.Leader = test_Leader;
        organization.Child_Characters = test_Child_Characters;
        organization.Child_Organizations= test_Child_Organizations;
        organization.Parent_Organizations= test_Parent_Organizations;

        DA.Repository.Update(organization);

        Organization? Result = DA.Repository.Get<Organization>(organization.ID);

        Assert.IsNotNull(Result);

        Assert.AreEqual(test_Name, Result.Name);
        Assert.AreEqual(test_Description, Result.Description);
        Assert.AreEqual(test_Goals, Result.Goals);
        Assert.AreEqual(test_Quirks, Result.Quirks);
        Assert.AreEqual(test_Size, Result.Size);
        Assert.AreEqual(test_Location, Result.Location);
        Assert.AreEqual(test_Species, Result.PrimarySpecies);
        Assert.AreEqual(test_Leader, Result.Leader);
        Assert.AreEqual(test_Child_Characters.Count, Result.Child_Characters.Count);
        Assert.AreEqual(test_Child_Organizations.Count, Result.Child_Organizations.Count);
        Assert.AreEqual(test_Parent_Organizations.Count, Result.Parent_Organizations.Count);

        for (int i = 0; i < test_Child_Characters.Count; i++)
        {
            Assert.AreEqual(test_Child_Characters[i], Result.Child_Characters[i]);
        }

        for (int i = 0; i < test_Child_Organizations.Count; i++)
        {
            Assert.AreEqual(test_Child_Organizations[i], Result.Child_Organizations[i]);
        }

        for (int i = 0; i < test_Parent_Organizations.Count; i++)
        {
            Assert.AreEqual(test_Parent_Organizations[i], Result.Parent_Organizations[i]);
        }

    }
}
