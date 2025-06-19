using CM4_Core.Models;

namespace CM4_Core_UnitTest.ModelTests;

[TestClass]
public class JobTests
{

    [TestMethod]
    public void CanCompareJob()
    {
        Job job1 = new Job(0);
        Job job2 = new Job(0);

        Assert.AreEqual(job1, job1);
        Assert.AreEqual(job2, job2);
        Assert.AreNotEqual(job1, job2);
    }
}
