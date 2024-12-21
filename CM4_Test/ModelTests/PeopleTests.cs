using CM4_Core.DataStructures;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.ModelInterfaces;
using CM4_Core.Models;

namespace CM4_Core_UnitTest;

[TestClass]
public class PeopleTests
{
    [TestMethod]
    public void CanCreatePeopleInstance()
    {
        IPeople P = new People();
        Assert.IsNotNull(P);
    }

    [TestMethod]
    public void ActiveCharacter_CanSetAndGetActiveCharacterUsingId()
    {
        IPeople P = new People();
        CharacterGuid characterGuid = new CharacterGuid();

        P.ActiveCharacter = characterGuid;

        Assert.AreEqual(characterGuid, P.ActiveCharacter);
    }

    [TestMethod]
    public void CharacterList_CanAddAndRetriveCharacter()
    {
        IPeople p = new People();
        ICharacter character = new Character();
        character.Name = "Tim";

        p.AddCharacter(character);
        ICharacter retrieveCharacter = p.RetrieveCharacter(character.ID);

        Assert.AreEqual(character.ID, retrieveCharacter.ID);
        Assert.AreEqual(character.Name, retrieveCharacter.Name);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(20)]
    [DataRow(100)]
    public void CharacterList_CanAddAndRetrieveMultipleCharacters(int N)
    {
        IPeople p = new People();
        List<ICharacter> characterList = new List<ICharacter>();
        
        for (int i = 0; i < N; i++)
        {
            ICharacter tmp = new Character();
            p.AddCharacter(tmp);
            characterList.Add(tmp);
        }

        for (int i = 0; i < characterList.Count; i++)
        {
            ICharacter orginal = characterList[i];
            ICharacter tmp = p.RetrieveCharacter(orginal.ID);
            Assert.AreEqual(orginal, tmp);
        }
    }

    [TestMethod]
    public void Relationships_CanAddCharacterToOrganization()
    {
        IPeople P = new People();
        CharacterGuid child = new CharacterGuid();
        OrganizationGuid parent = new OrganizationGuid();

        P.AddMember(parent, child);
        
        Assert.IsTrue(P.GetMembers(parent).Characters.Contains(child));

    }

    [TestMethod]
    public void Relationships_CanAddOrganizationToOrganization()
    {
        IPeople P = new People();
        OrganizationGuid child = new OrganizationGuid();
        OrganizationGuid parent = new OrganizationGuid();

        P.AddMember(parent, child);

        Assert.IsTrue(P.GetMembers(parent).Organizations.Contains(child));

    }

    [TestMethod]
    public void Relationships_CanRemoveCharacterFromOrganization()
    {
        IPeople P = new People();
        CharacterGuid child = new CharacterGuid();
        OrganizationGuid parent = new OrganizationGuid();

        P.AddMember(parent, child);

        Assert.IsTrue(P.GetMembers(parent).Characters.Contains(child));

        P.RemoveMember(parent, child);

        Assert.IsFalse(P.GetMembers(parent).Characters.Contains(child));
    }

    [TestMethod]
    public void Relationships_CanRemoveOrganizationFromOrganization()
    {
        IPeople P = new People();
        OrganizationGuid child = new OrganizationGuid();
        OrganizationGuid parent = new OrganizationGuid();

        P.AddMember(parent, child);

        Assert.IsTrue(P.GetMembers(parent).Organizations.Contains(child));

        P.RemoveMember(parent, child);

        Assert.IsFalse(P.GetMembers(parent).Organizations.Contains(child));

    }

    [TestMethod]
    public void OrganizationList_CanAddAndRetriveOrganization()
    {
        IPeople p = new People();
        IOrganization org = new Organization();
        org.Name = "The Fellowship of the Ring";

        p.AddOrganization(org);
        IOrganization retrieveCharacter = p.RetrieveOrganization(org.ID);

        Assert.AreEqual(org.ID, retrieveCharacter.ID);
        Assert.AreEqual(org.Name, retrieveCharacter.Name);
    }
}
