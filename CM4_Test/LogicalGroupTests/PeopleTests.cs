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
        Mock<IDataAccess> DA_Mock = new();
        IPeople P = new People(DA_Mock.Object);
        Assert.IsNotNull(P);
    }

    [TestMethod]
    public void People_CanAddCharacter()
    {
        Mock<IDataAccess> DA_Mock = new();
        Mock<IRepository> R_Mock = new();
        DA_Mock.Setup(DA => DA.Repository).Returns(R_Mock.Object);

        Character character = new()
        {
            Name = "Tim"
        };

        IPeople p = new People(DA_Mock.Object);
        p.AddCharacter(character);

        DA_Mock.Verify(DA => DA.Repository, Times.Once);
        R_Mock.Verify(R => R.Add(character),Times.Once);
        DA_Mock.VerifyNoOtherCalls();
        R_Mock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public void People_CanRetrieveCharacters()
    {
        Mock<IDataAccess> DA_Mock = new();
        Mock<IRepository> R_Mock = new();
        DA_Mock.Setup(R => R.Repository).Returns(R_Mock.Object);

        Character character1 = new()
        {
            Name = "Bob"
        };
        Character character2 = new()
        {
            Name = "Alice"
        };

        List<Character> list = [character1, character2];

        R_Mock.Setup(CA => CA.Get<Character>()).Returns(list);

        IPeople p = new People(DA_Mock.Object);

        Assert.AreEqual(p.GetCharacters(),list);

        DA_Mock.Verify(DA => DA.Repository, Times.Once);
        R_Mock.Verify(R => R.Get<Character>(), Times.Once);
        DA_Mock.VerifyNoOtherCalls();
        R_Mock.VerifyNoOtherCalls();
    }
    [TestMethod]
    public void People_CanAddOrganization()
    {
        Mock<IDataAccess> DA_Mock = new();
        Mock<IRepository> R_Mock = new();
        DA_Mock.Setup(DA => DA.Repository).Returns(R_Mock.Object);

        Organization organization = new()
        {
            Name = "The Fellowship"
        };

        IPeople p = new People(DA_Mock.Object);
        p.AddOrganization(organization);

        DA_Mock.Verify(DA => DA.Repository, Times.Once);
        R_Mock.Verify(R => R.Add(organization), Times.Once);
        DA_Mock.VerifyNoOtherCalls();
        R_Mock.VerifyNoOtherCalls();
    }

    [TestMethod]
    public void People_CanRemoveOrganization() { }
}
