using CM4_Core.Models;

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
}
