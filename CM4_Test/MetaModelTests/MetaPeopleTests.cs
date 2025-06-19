using CM4_Core.DataAccess;
using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using Moq;

namespace CM4_Core_UnitTest;

[TestClass]
public class MetaPeopleTests
{
    [TestMethod]
    public void RequestingInvaldOrgIDResultsInNull()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Assert.IsTrue(target.GetOrg(Guid.NewGuid()) == null);
    }

    [TestMethod]
    public void CanGetOrganization()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid id = target.AddOrg();

        Assert.IsTrue(id != Guid.Empty);
        Assert.IsTrue(target.GetOrg(id) != null);
        Assert.IsTrue(target.GetOrg(id).ID == id);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetMultipleOrgs(int numOrgs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numOrgs; i++)
        {
            guids.Add(target.AddOrg());
        }

        List<Organization> resultOrgs = target.GetOrg(guids);

        foreach (Organization org in resultOrgs)
        {
            Assert.IsTrue(guids.Contains(org.ID));
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetAllOrgs(int numOrgs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numOrgs; i++)
        {
            guids.Add(target.AddOrg());
        }

        List<Organization> resultOrgs = target.GetOrg();

        foreach (Organization org in resultOrgs)
        {
            Assert.IsTrue(guids.Contains(org.ID));
        }
    }

    [TestMethod]
    public void RequestingInvaldCharIDResultsInNull()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Assert.IsTrue(target.GetChar(Guid.NewGuid()) == null);
    }

    [TestMethod]
    public void CanGetCharanization()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid id = target.AddChar();

        Assert.IsTrue(id != Guid.Empty);
        Assert.IsTrue(target.GetChar(id) != null);
        Assert.IsTrue(target.GetChar(id).ID == id);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetMultipleChars(int numChars)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numChars; i++)
        {
            guids.Add(target.AddChar());
        }

        List<Character> resultChars = target.GetChar(guids);

        foreach (Character Char in resultChars)
        {
            Assert.IsTrue(guids.Contains(Char.ID));
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetAllChars(int numChars)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numChars; i++)
        {
            guids.Add(target.AddChar());
        }

        List<Character> resultChars = target.GetChar();

        foreach (Character Char in resultChars)
        {
            Assert.IsTrue(guids.Contains(Char.ID));
        }
    }

    [TestMethod]
    public void CanAddOrgAsChild()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid Parent = target.AddOrg();
        Guid Child = target.AddOrg();

        target.AddChild(target.GetOrg(Parent), target.GetOrg(Child));

        Assert.IsTrue(target.GetOrg(Parent).Child_Organizations.Contains(Child));
        Assert.IsTrue(target.GetOrg(Child).Parent_Organizations.Contains(Parent));
    }

    [TestMethod]
    public void CanAddCharAsChild()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid Parent = target.AddOrg();
        Guid Child = target.AddChar();

        target.AddChild(target.GetOrg(Parent), target.GetChar(Child));

        Assert.IsTrue(target.GetOrg(Parent).Child_Characters.Contains(Child));
        Assert.IsTrue(target.GetChar(Child).Parent_Organizations.Contains(Parent));
    }

    [TestMethod]
    public void CanCheckIfGuidIsChar()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid cha = target.AddChar();

        Assert.IsTrue(target.IsChar(cha));
        Assert.IsFalse(target.IsChar(Guid.Empty));
        Assert.IsFalse(target.IsOrg(cha));
    }

    [TestMethod]
    public void CanCheckIfGuidIsOrg()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid cha = target.AddOrg();

        Assert.IsTrue(target.IsOrg(cha));
        Assert.IsFalse(target.IsOrg(Guid.Empty));
        Assert.IsFalse(target.IsChar(cha));
    }

    [TestMethod]
    public void CanAddExistingOrg()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Organization Foo = new Organization();

        Guid Org = target.AddOrg(Foo);

        Assert.AreEqual(Org,Foo.ID);
        Assert.IsTrue(target.IsOrg(Org));
        Assert.IsFalse(target.IsChar(Org));
        Assert.AreEqual(Foo.ID, target.GetOrg(Org).ID);
    }

    [TestMethod]
    public void CanAddExistingChar()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Character Foo = new Character();

        Guid Cha = target.AddChar(Foo);

        Assert.AreEqual(Cha, Foo.ID);
        Assert.IsTrue(target.IsChar(Cha));
        Assert.IsFalse(target.IsOrg(Cha));
        Assert.AreEqual(Foo.ID, target.GetChar(Cha).ID);
    }


    [TestMethod]
    public void CanAddJobToChar()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid CharID = target.AddChar();
        Guid JobID = Guid.NewGuid();

        target.AddJob(CharID, JobID);

        Assert.IsTrue(target.GetChar(CharID).Jobs.Count() == 1);
        Assert.AreEqual(target.GetChar(CharID).Jobs[0], JobID);
    }

    [TestMethod]
    public void CanAddJobToOrg()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People target = new People(da.Object, notifyService.Object);

        Guid OrgID = target.AddOrg();
        Guid JobID = Guid.NewGuid();

        target.AddJob(OrgID, JobID);

        Assert.IsTrue(target.GetOrg(OrgID).Jobs.Count() == 1);
        Assert.AreEqual(target.GetOrg(OrgID).Jobs[0], JobID);
    }
}
