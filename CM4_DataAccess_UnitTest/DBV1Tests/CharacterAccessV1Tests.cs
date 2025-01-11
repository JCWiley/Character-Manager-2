using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_DataAccess.DBV1;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;

namespace CM4_DataAccess_UnitTest;

[TestClass]
public class CharacterAccessV1Tests
{
    static IDataAccess DA;
    static IDataAccess NullDA;

    [ClassInitialize]
    public static void DataAccessV1Initialize(TestContext testContext)
    {
        Mock<INotifyService> notifyService = new();
        Mock<ISettingsService> settingsService = new();
        DA = new DataAccessV1(notifyService.Object,settingsService.Object);
        DA.CreateDataStore(@"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TestV1DB.db");

        NullDA = new DataAccessV1(notifyService.Object, settingsService.Object);
    }

    [TestMethod]
    public async Task CRUD_CanAddAndRemoveCharacter()
    {
        Character C = await DA.CA.AddCharacter();

        List<Character> CharList = DA.CA.GetCharacters();

        Assert.IsTrue(CharList.Contains(C));

        DA.CA.RemoveCharacter(C);

        CharList = DA.CA.GetCharacters();

        Assert.IsFalse(CharList.Contains(C));
    }

    [TestMethod]
    public async Task CRUD_CanInsertPremadeCharacter()
    {
        Character C = new Character();
        C.Name = "Bob";
        C.Age = 20;

        Character C2 = await DA.CA.AddCharacter(C);

        Assert.IsNotNull(C2);
        Assert.AreEqual(C, C2);
        Assert.AreEqual(C.Age, C2.Age);
    }

    [TestMethod]
    public async Task CRUD_CanGetCharacterByID()
    {
        Character C = await DA.CA.AddCharacter();

        Character C2 = DA.CA.GetCharacters([C.ID])[0];

        Assert.IsNotNull(C2);
        Assert.AreEqual(C, C2);
    }

    [TestMethod]
    public async Task CRUD_CanUpdateCharacter()
    {
        Character C = await DA.CA.AddCharacter();

        C.Name = "Tim";
        C.Age = 43;

        Character C2 = DA.CA.UpdateCharacter(C);

        Assert.IsNotNull(C2);
        Assert.AreEqual(C, C2);
    }

    [TestMethod]
    public async Task NoDB_AddCharacterDoesNothing()
    {
        Character C = new Character();
        C.Name = "Bob";
        C.Age = 20;

        Character? C2 = await NullDA.CA.AddCharacter(C);

        Assert.IsNull(C2);
    }

    [TestMethod]
    public async Task NoDB_AddDefaultCharacterDoesNothing()
    {
        Character? C2 = await NullDA.CA.AddCharacter();

        Assert.IsNull(C2);
    }

    [TestMethod]
    public async Task NoDB_FilteredGetCharactersReturnsEmptyList()
    {
        Character? C = await NullDA.CA.AddCharacter();

        Character C2 = new();

        List<Character> C_list = NullDA.CA.GetCharacters([C2.ID]);

        Assert.IsNotNull(C_list);
        Assert.AreEqual(C_list.Count(), 0);
    }

    [TestMethod]
    public async Task NoDB_GetCharactersReturnsEmptyList()
    {
        List<Character> C_list = NullDA.CA.GetCharacters();

        Assert.IsNotNull(C_list);
        Assert.AreEqual(C_list.Count(), 0);
    }

    [TestMethod]
    public async Task NoDB_RemoveCharacterDoesNotCrash()
    {
        Character C = new();

        NullDA.CA.RemoveCharacter(C);
    }

    [TestMethod]
    public async Task NoDB_UpdateCharacterDoesNothing()
    {
        Character C = new();

        C.Name = "Tim";
        C.Age = 43;

        Character C2 = NullDA.CA.UpdateCharacter(C);

        Assert.IsNull(C2);
    }
}
