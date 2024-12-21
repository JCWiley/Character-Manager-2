using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_DataAccess.DBV1;

namespace CM4_DataAccess_UnitTest;

[TestClass]
public class CharacterAccessV1Tests
{
    static IDataAccess DA;

    [ClassInitialize]
    public static void DataAccessV1Initialize(TestContext testContext)
    {
        DA = new DataAccessV1();
        DA.StoragePath = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TestV1DB.db";
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

        DA.CA.UpdateCharacter(C);
    }
}
