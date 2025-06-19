using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_DataAccess.DBV1;
using Moq;
using System.Linq;

namespace CM4_DataAccess_UnitTest;

[TestClass]
public class GeneralRepositoryTests
{
    static IDataAccess DA;
    static IDataAccess NullDA;

    [ClassInitialize]
    public static void GeneralRepositoryTestsInitialize(TestContext testContext)
    {
        Mock<INotifyService> notifyService = new();
        Mock<ISettingsService> settingsService = new();
        DA = new DataAccessV1(notifyService.Object, settingsService.Object);
        DA.CreateDataStore(@"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TestV1DB.db");

        NullDA = new DataAccessV1(notifyService.Object, settingsService.Object);
    }

    [TestMethod]
    public async Task Repository_CanAdd()
    {
        await Helper_CanAdd<Character>();
        await Helper_CanAdd<Organization>();
        await Helper_CanAdd<Location>();
        await Helper_CanAdd<Species>();
        await Helper_CanAdd<Job>();
        await Helper_CanAdd<InventoryItem>();
    }

    [TestMethod]
    public async Task Repository_CanAddPrexisting()
    {
        await Helper_CanAddPreexisting(new Character());
        await Helper_CanAddPreexisting(new Organization());

        await Helper_CanAddPreexisting(new Location());
        await Helper_CanAddPreexisting(new Species());

        await Helper_CanAddPreexisting(new Job());
        await Helper_CanAddPreexisting(new InventoryItem());
    }

    [TestMethod]
    public async Task Repository_CanSearch()
    {
        Character character = new Character();
        await Helper_CanSearch([new Character(),new Character()],character,x => x.ID == character.ID);

        Organization organization = new Organization();
        await Helper_CanSearch([new Organization(), new Organization()], organization, x => x.ID == organization.ID);

        Location location = new Location();
        await Helper_CanSearch([new Location(), new Location()], location, x => x.ID == location.ID);

        Species species = new Species();
        await Helper_CanSearch([new Species(), new Species()], species, x => x.ID == species.ID);

        Job job = new Job();
        await Helper_CanSearch([new Job(), new Job()], job, x => x.ID == job.ID);

        InventoryItem item = new InventoryItem();
        await Helper_CanSearch([new InventoryItem(), new InventoryItem()], item, x => x.ID == item.ID);

    }

    [TestMethod]
    public async Task Repository_CanGetItemByID()
    {
        Character character = new Character();
        await Helper_CanFindItemByID([new Character(), new Character()], character);

        Organization organization = new Organization();
        await Helper_CanFindItemByID([new Organization(), new Organization()], organization);

        Location location = new Location();
        await Helper_CanFindItemByID([new Location(), new Location()], location);

        Species species = new Species();
        await Helper_CanFindItemByID([new Species(), new Species()], species);

        Job job = new Job();
        await Helper_CanFindItemByID([new Job(), new Job()], job);

        InventoryItem item = new InventoryItem();
        await Helper_CanFindItemByID([new InventoryItem(), new InventoryItem()], item);
    }

    [TestMethod]
    public async Task Repository_CanRemove()
    {
        await Helper_CanRemove<Character>();
        await Helper_CanRemove<Organization>();
        await Helper_CanRemove<Location>();
        await Helper_CanRemove<Species>();
        await Helper_CanRemove<Job>();
        await Helper_CanRemove<InventoryItem>();
    }

    [TestMethod]
    public async Task Repository_NoDB_AddDoesNothing()
    {
        await Helper_NoDB_AddDoesNothing<Character>();
        await Helper_NoDB_AddDoesNothing<Organization>();
        await Helper_NoDB_AddDoesNothing<Location>();
        await Helper_NoDB_AddDoesNothing<Species>();
        await Helper_NoDB_AddDoesNothing<Job>();
        await Helper_NoDB_AddDoesNothing<InventoryItem>();
    }
    [TestMethod]
    public async Task Repository_NoDB_AddPreexistingDoesNothing()
    {
        Character character = new Character();
        await Helper_NoDB_AddPreexistingDoesNothing(character);

        Organization organization = new Organization();
        await Helper_NoDB_AddPreexistingDoesNothing(organization);

        Location location = new Location();
        await Helper_NoDB_AddPreexistingDoesNothing(location);

        Species species = new Species();
        await Helper_NoDB_AddPreexistingDoesNothing(species);

        Job job = new Job();
        await Helper_NoDB_AddPreexistingDoesNothing(location);

        InventoryItem item = new InventoryItem();
        await Helper_NoDB_AddPreexistingDoesNothing(species);
    }
    [TestMethod]
    public async Task Repository_NoDB_SearchReturnsEmptyList()
    {
        Character character = new Character();
        await Helper_NoDB_SearchReturnsEmptyList([new Character(), new Character()], character, x => x.ID == character.ID);

        Organization organization = new Organization();
        await Helper_NoDB_SearchReturnsEmptyList([new Organization(), new Organization()], organization, x => x.ID == organization.ID);

        Location location = new Location();
        await Helper_NoDB_SearchReturnsEmptyList([new Location(), new Location()], location, x => x.ID == location.ID);

        Species species = new Species();
        await Helper_NoDB_SearchReturnsEmptyList([new Species(), new Species()], species, x => x.ID == species.ID);

        Job job = new Job();
        await Helper_NoDB_SearchReturnsEmptyList([new Job(), new Job()], job, x => x.ID == job.ID);

        InventoryItem item = new InventoryItem();
        await Helper_NoDB_SearchReturnsEmptyList([new InventoryItem(), new InventoryItem()], item, x => x.ID == item.ID);
    }
    [TestMethod]
    public void Repository_NoDB_GetReturnsEmptyList()
    {
        Helper_NoDB_GetReturnsEmptyList<Character>();
        Helper_NoDB_GetReturnsEmptyList<Organization>();
        Helper_NoDB_GetReturnsEmptyList<Location>();
        Helper_NoDB_GetReturnsEmptyList<Species>();
        Helper_NoDB_GetReturnsEmptyList<Job>();
        Helper_NoDB_GetReturnsEmptyList<InventoryItem>();
    }
    [TestMethod]
    public async Task Repository_NoDB_RemoveDoesNotCrash()
    {
        await Helper_NoDB_RemoveDoesNotCrash<Character>();
        await Helper_NoDB_RemoveDoesNotCrash<Organization>();
        await Helper_NoDB_RemoveDoesNotCrash<Location>();
        await Helper_NoDB_RemoveDoesNotCrash<Species>();
        await Helper_NoDB_RemoveDoesNotCrash<Job>();
        await Helper_NoDB_RemoveDoesNotCrash<InventoryItem>();
    }
    [TestMethod]
    public void Repository_NoDB_UpdateDoesNothing()
    {
        Character character = new Character();
        Helper_NoDB_UpdateDoesNothing(character);

        Organization organization = new Organization();
        Helper_NoDB_UpdateDoesNothing(organization);

        Location location = new Location();
        Helper_NoDB_UpdateDoesNothing(location);

        Species species = new Species();
        Helper_NoDB_UpdateDoesNothing(species);

        Job job = new Job();
        Helper_NoDB_UpdateDoesNothing(job);

        InventoryItem item = new InventoryItem();
        Helper_NoDB_UpdateDoesNothing(item);
    }

    //Helpers
    public async Task Helper_CanAdd<T>() where T : ModelBaseClass
    {
        T C = await DA.Repository.Add<T>();

        List<T> ResultList = DA.Repository.Get<T>();

        Assert.IsTrue(ResultList.Contains(C));
    }

    public async Task Helper_CanAddPreexisting<T>(T Target) where T : ModelBaseClass
    {
        await DA.Repository.Add(Target);

        List<T> ResultList = DA.Repository.Get<T>();

        Assert.IsTrue(ResultList.Contains(Target));
    }

    public async Task Helper_CanSearch<T>(T[] Items,T Target ,Func<T, bool> filter) where T : ModelBaseClass
    {
        foreach (T Item in Items) {
            await DA.Repository.Add(Item);
        }
        await DA.Repository.Add(Target);

        List<T> ResultList = DA.Repository.Get(filter);

        Assert.IsTrue(ResultList.Contains(Target));
        Assert.IsTrue(ResultList.Count() == 1);
    }

    public async Task Helper_CanFindItemByID<T>(T[] Items, T Target) where T : ModelBaseClass
    {
        foreach (T Item in Items)
        {
            await DA.Repository.Add(Item);
        }
        await DA.Repository.Add(Target);

        T Result = DA.Repository.Get<T>(Target.ID);

        Assert.AreEqual(Result,Target);
    }

    public async Task Helper_CanRemove<T>() where T : ModelBaseClass
    {
        T Result = await DA.Repository.Add<T>();

        List<T> ResultList = DA.Repository.Get<T>();

        Assert.IsTrue(ResultList.Contains(Result));

        DA.Repository.Remove(Result);

        ResultList = DA.Repository.Get<T>();

        Assert.IsFalse(ResultList.Contains(Result));
    }

    public async Task Helper_CanUpdate<T>(T Original,T Updated,Func<T,T,bool> comparison) where T : ModelBaseClass
    {
        //await NullDA.Repository.Add(Original);

        //Assert.IsTrue

        //Assert.IsNull(C2);
    }

    public async Task Helper_NoDB_AddDoesNothing<T>() where T : ModelBaseClass
    {
        T? Result = await NullDA.Repository.Add<T>();

        Assert.IsNull(Result);
    }
    public async Task Helper_NoDB_AddPreexistingDoesNothing<T>(T Target) where T : ModelBaseClass
    {
        await NullDA.Repository.Add(Target);

        List<T> ResultList = NullDA.Repository.Get<T>();

        Assert.AreEqual(ResultList.Count(),0);
    }
    public async Task Helper_NoDB_SearchReturnsEmptyList<T>(T[] Items, T Target, Func<T, bool> filter) where T : ModelBaseClass
    {
        foreach (T Item in Items)
        {
            await NullDA.Repository.Add(Item);
        }
        await NullDA.Repository.Add(Target);

        List<T> ResultList = NullDA.Repository.Get(filter);

        Assert.AreEqual(ResultList.Count(), 0);
    }
    public void Helper_NoDB_GetReturnsEmptyList<T>() where T : ModelBaseClass
    {
        List<T> ResultList = NullDA.Repository.Get<T>();

        Assert.AreEqual(ResultList.Count(), 0);
    }
    public async Task Helper_NoDB_RemoveDoesNotCrash<T>() where T : ModelBaseClass
    {
        T Result = await NullDA.Repository.Add<T>();

        List<T> ResultList = NullDA.Repository.Get<T>();

        Assert.IsFalse(ResultList.Contains(Result));

        NullDA.Repository.Remove(Result);

    }
    public void Helper_NoDB_UpdateDoesNothing<T>(T Target) where T : ModelBaseClass
    {
        T Result = NullDA.Repository.Update(Target);

        Assert.AreNotEqual(Result, Target);
    }
}


