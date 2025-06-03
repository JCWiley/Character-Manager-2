using CM4_Core.Models;
using System.Linq;

namespace CM4_Core_UnitTest;

[TestClass]
public class OrganizationTests
{
    [TestMethod]
    public void CanCreateOrganization()
    {
        Organization organization = new Organization();
    }

    [TestMethod]
    public void CanCompareOrganizations()
    {
        Organization Org1 = new Organization();
        Organization Org2 = new Organization();

        Assert.AreEqual(Org1, Org1);
        Assert.AreEqual(Org2, Org2);
        Assert.AreNotEqual(Org1, Org2);
    }

    [TestMethod]
    public void ID_InitialValueNotNull()
    {
        Organization organization = new Organization();
        Assert.IsNotNull(organization.ID);
    }

    [TestMethod]
    public void Name_InitialValueNotNull()
    {
        Organization organization = new Organization();
        Assert.IsNotNull(organization.Name);
    }

    [TestMethod]
    [DataRow("The Fellowship of the Ring")]
    [DataRow("The Avengers")]
    [DataRow("")]
    public void Name_CanStoreAndRetrieve(string name)
    {
        Organization organization = new Organization();
        organization.Name = name;
        Assert.AreEqual(organization.Name, name);
    }

    [TestMethod]
    public void Members_CanAddCharacter()
    {
        Organization organization = new Organization();
        Character character = new Character();
        character.Name = "Frodo";

        organization.Parent_Organizations.Add(character.ID);

        Assert.IsTrue(organization.Parent_Organizations.Contains(character.ID));
    }

    [TestMethod]
    public void Members_CanAddOrganizations()
    {
        Organization organization = new Organization();
        Organization subOrg = new Organization();
        subOrg.Name = "The Hobbits";

        organization.Parent_Organizations.Add(subOrg.ID);

        Assert.IsTrue(organization.Parent_Organizations.Contains(subOrg.ID));
    }
}
