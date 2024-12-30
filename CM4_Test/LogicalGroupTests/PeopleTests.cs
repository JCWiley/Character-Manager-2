using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using CM4_Core.Models;
using Moq;

namespace CM4_Core_UnitTest.LogicalGroupTests;

[TestClass]
public class PeopleTests
{
    [TestMethod]
    public void CanCreatePeopleInstance()
    {
        IMock<ICharacterAccess> DA_Mock = new Mock<ICharacterAccess>();
        IPeople P = new People(DA_Mock.Object);
        Assert.IsNotNull(P);
    }

    //[TestMethod]
    //public void ActiveCharacter_CanSetAndGetActiveCharacterUsingId()
    //{
    //    IPeople P = new People();
    //    CharacterGuid characterGuid = new CharacterGuid();

    //    P.ActiveCharacter = characterGuid;

    //    Assert.AreEqual(characterGuid, P.ActiveCharacter);
    //}

    [TestMethod]
    public void CharacterList_CanAddCharacter()
    {
        Mock<ICharacterAccess> DA_Mock = new Mock<ICharacterAccess>();

        Character character = new Character();
        character.Name = "Tim";

        IPeople p = new People(DA_Mock.Object);
        p.AddCharacter(character);

        DA_Mock.Verify(CA => CA.AddCharacter(character), Times.Once);
    }

    [TestMethod]
    public void CharacterList_CanRetrieveCharacter()
    {
    
    }

    //[TestMethod]
    //[DataRow(0)]
    //[DataRow(20)]
    //[DataRow(100)]
    //public void CharacterList_CanAddAndRetrieveMultipleCharacters(int N)
    //{
    //    IPeople p = new People();
    //    List<ICharacter> characterList = new List<ICharacter>();

    //    for (int i = 0; i < N; i++)
    //    {
    //        ICharacter tmp = new Character();
    //        p.AddCharacter(tmp);
    //        characterList.Add(tmp);
    //    }

    //    for (int i = 0; i < characterList.Count; i++)
    //    {
    //        ICharacter orginal = characterList[i];
    //        ICharacter tmp = p.RetrieveCharacter(orginal.ID);
    //        Assert.AreEqual(orginal, tmp);
    //    }
    //}

    //[TestMethod]
    //public void Relationships_CanAddCharacterToOrganization()
    //{
    //    IPeople P = new People();
    //    CharacterGuid child = new CharacterGuid();
    //    OrganizationGuid parent = new OrganizationGuid();

    //    P.AddMember(parent, child);

    //    Assert.IsTrue(P.GetMembers(parent).Characters.Contains(child));

    //}

    //[TestMethod]
    //public void Relationships_CanAddOrganizationToOrganization()
    //{
    //    IPeople P = new People();
    //    OrganizationGuid child = new OrganizationGuid();
    //    OrganizationGuid parent = new OrganizationGuid();

    //    P.AddMember(parent, child);

    //    Assert.IsTrue(P.GetMembers(parent).Organizations.Contains(child));

    //}

    //[TestMethod]
    //public void Relationships_CanRemoveCharacterFromOrganization()
    //{
    //    IPeople P = new People();
    //    CharacterGuid child = new CharacterGuid();
    //    OrganizationGuid parent = new OrganizationGuid();

    //    P.AddMember(parent, child);

    //    Assert.IsTrue(P.GetMembers(parent).Characters.Contains(child));

    //    P.RemoveMember(parent, child);

    //    Assert.IsFalse(P.GetMembers(parent).Characters.Contains(child));
    //}

    //[TestMethod]
    //public void Relationships_CanRemoveOrganizationFromOrganization()
    //{
    //    IPeople P = new People();
    //    OrganizationGuid child = new OrganizationGuid();
    //    OrganizationGuid parent = new OrganizationGuid();

    //    P.AddMember(parent, child);

    //    Assert.IsTrue(P.GetMembers(parent).Organizations.Contains(child));

    //    P.RemoveMember(parent, child);

    //    Assert.IsFalse(P.GetMembers(parent).Organizations.Contains(child));

    //}

    //[TestMethod]
    //public void OrganizationList_CanAddAndRetriveOrganization()
    //{
    //    IPeople p = new People();
    //    IOrganization org = new Organization();
    //    org.Name = "The Fellowship of the Ring";

    //    p.AddOrganization(org);
    //    IOrganization retrieveCharacter = p.RetrieveOrganization(org.ID);

    //    Assert.AreEqual(org.ID, retrieveCharacter.ID);
    //    Assert.AreEqual(org.Name, retrieveCharacter.Name);
    //}
}
