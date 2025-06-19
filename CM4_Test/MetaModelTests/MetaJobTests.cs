namespace CM4_Core_UnitTest;

using CM4_Core.DataAccess;
using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using Moq;

[TestClass]
public class MetaJobTests
{
    [TestMethod]
    public void CanGetJob()
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People people = new People(da.Object, notifyService.Object);
        Jobs target = new Jobs(people, da.Object, notifyService.Object);

        Guid id = target.AddJob(Guid.Empty);

        Assert.IsTrue(id != Guid.Empty);
        Assert.IsTrue(target.GetJob(id) != null);
        Assert.IsTrue(target.GetJob(id).ID == id);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetMultipleJobs(int numJobs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People people = new People(da.Object, notifyService.Object);
        Jobs target = new Jobs(people, da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numJobs; i++)
        {
            guids.Add(target.AddJob(Guid.Empty));
        }

        List<Job> resultJobs = target.GetJob(guids);

        foreach (Job job in resultJobs)
        {
            Assert.IsTrue(guids.Contains(job.ID));
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetAllJobs(int numJobs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People people = new People(da.Object, notifyService.Object);
        Jobs target = new Jobs(people, da.Object, notifyService.Object);

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numJobs; i++)
        {
            guids.Add(target.AddJob(Guid.Empty));
        }

        List<Job> resultJobs = target.GetJob();

        foreach (Job job in resultJobs)
        {
            Assert.IsTrue(guids.Contains(job.ID));
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetAllJobsForChar(int numJobs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People people = new People(da.Object, notifyService.Object);
        Jobs target = new Jobs(people, da.Object, notifyService.Object);

        Guid personID = people.AddChar();

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numJobs; i++)
        {
            guids.Add(target.AddJob(personID));
        }

        Assert.AreEqual(numJobs, target.GetJobsForOrgChar(personID).Count);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanGetAllJobsForOrg(int numJobs)
    {
        Mock<IDataAccess> da = new Mock<IDataAccess>();
        Mock<INotifyService> notifyService = new Mock<INotifyService>();
        People people = new People(da.Object, notifyService.Object);
        Jobs target = new Jobs(people, da.Object, notifyService.Object);

        Guid orgID = people.AddOrg();

        List<Guid> guids = new List<Guid>();

        for (int i = 0; i < numJobs; i++)
        {
            guids.Add(target.AddJob(orgID));
        }

        Assert.AreEqual(numJobs, target.GetJobsForOrgChar(orgID).Count);
    }

}
