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
    }

    [TestMethod]
    public async Task Repository_CanAddPrexisting()
    {
        await Helper_CanAddPreexisting(new Character());
        await Helper_CanAddPreexisting(new Organization());
    }

    [TestMethod]
    public async Task Repository_CanSearch()
    {
        Character character = new Character();
        await Helper_CanSearch([new Character(),new Character()],character,x => x.ID == character.ID);

        Organization organization = new Organization();
        await Helper_CanSearch([new Organization(), new Organization()], organization, x => x.ID == organization.ID);

    }

    [TestMethod]
    public async Task Repository_CanGetItemByID()
    {
        Character character = new Character();
        await Helper_CanFindItemByID([new Character(), new Character()], character);
    }

    [TestMethod]
    public async Task Repository_CanRemove()
    {
        await Helper_CanRemove<Character>();
        await Helper_CanRemove<Organization>();
    }

    [TestMethod]
    public async Task Repository_NoDB_AddDoesNothing()
    {
        await Helper_NoDB_AddDoesNothing<Character>();
        await Helper_NoDB_AddDoesNothing<Organization>();
    }
    [TestMethod]
    public async Task Repository_NoDB_AddPreexistingDoesNothing()
    {
        Character character = new Character();
        await Helper_NoDB_AddPreexistingDoesNothing(character);

        Organization organization = new Organization();
        await Helper_NoDB_AddPreexistingDoesNothing(organization);
    }
    [TestMethod]
    public async Task Repository_NoDB_SearchReturnsEmptyList()
    {
        Character character = new Character();
        await Helper_NoDB_SearchReturnsEmptyList([new Character(), new Character()], character, x => x.ID == character.ID);

        Organization organization = new Organization();
        await Helper_NoDB_SearchReturnsEmptyList([new Organization(), new Organization()], organization, x => x.ID == organization.ID);
    }
    [TestMethod]
    public void Repository_NoDB_GetReturnsEmptyList()
    {
        Helper_NoDB_GetReturnsEmptyList<Character>();
        Helper_NoDB_GetReturnsEmptyList<Organization>();
    }
    [TestMethod]
    public async Task Repository_NoDB_RemoveDoesNotCrash()
    {
        await Helper_NoDB_RemoveDoesNotCrash<Character>();
        await Helper_NoDB_RemoveDoesNotCrash<Organization>();
    }
    [TestMethod]
    public void Repository_NoDB_UpdateDoesNothing()
    {
        Character character = new Character();
        Helper_NoDB_UpdateDoesNothing(character);

        Organization organization = new Organization();
        Helper_NoDB_UpdateDoesNothing(organization);
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


