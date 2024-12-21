using CM4_Core.ModelInterfaces;
using CM4_Core.Models;

namespace CM4_Core_UnitTest;

[TestClass]
public class OrganizationTests
{
    [TestMethod]
    public void CanCreateOrganization()
    {
        IOrganization organization = new Organization();
    }

    [TestMethod]
    public void ID_InitialValueNotNull()
    {
        IOrganization organization = new Organization();
        Assert.IsNotNull(organization.ID);
    }

    [TestMethod]
    public void Name_InitialValueNotNull()
    {
        IOrganization organization = new Organization();
        Assert.IsNotNull(organization.Name);
    }

    [TestMethod]
    [DataRow("The Fellowship of the Ring")]
    [DataRow("The Avengers")]
    [DataRow("")]
    public void Name_CanStoreAndRetrieve(string name)
    {
        IOrganization organization = new Organization();
        organization.Name = name;
        Assert.AreEqual(organization.Name, name);

    }
}
