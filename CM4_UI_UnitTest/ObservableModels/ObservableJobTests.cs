using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using System.Collections.ObjectModel;
using CM4_UI_UnitTest.Utilities;
using Moq;
using System.Collections.Specialized;
using DynamicData;
using System.Linq;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableJobTests
{
    Job Source;
    Guid Initial_ID;

    //General data
    List<Guid> Initial_Required_Items;
    const bool Initial_IsComplete = false;
    const string Initial_Summary = "Test Summary";
    const string Initial_Description = "Test Description";
    const int Initial_SuccessChance = 20;
    const int Initial_FailureChance = 20;
    Guid OwnerEntity;
    Guid OwnerJob;

    //IsComplete math
    const bool Initial_IsCurrentlyProgressing = true;
    const bool Initial_IsRecurring = false;
    const int Initial_Days_Since_Creation = 12;
    const int Initial_Creation_Date = 1412;
    const int Initial_StartDate = 44;
    const int Initial_Duration = 52;
    const int Initial_Progress = 32;

    PropertyChangedObserver PCO;

    [TestInitialize]
    public void TestInit()
    {
        Initial_ID = Guid.NewGuid();

        Source = new Job(Initial_Creation_Date);

        Source.ID = Initial_ID;
        Source.Summary = Initial_Summary;
        Source.Description = Initial_Description;
        Source.IsCurrentlyProgressing = Initial_IsCurrentlyProgressing;
        Source.IsRecurring = Initial_IsRecurring;
        Source.Duration = Initial_Duration;
        Source.Progress = Initial_Progress;
        Source.StartDate = Initial_StartDate;
        Source.SuccessChance = Initial_SuccessChance;
        Source.FailureChance = Initial_FailureChance;

        //Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        //Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        //WVM_Mock = new Mock<WorldDataViewModel>(DA_Mock.Object, NS_Mock.Object);

        PCO = new PropertyChangedObserver(); ;
    }

    [TestMethod]
    public void CanReadID()
    {
        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.ID));

        Assert.AreEqual(Initial_ID, target.ID);
        Assert.AreEqual(Initial_ID, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadIsComplete()
    {
        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.IsComplete));

        Assert.AreEqual(Initial_IsComplete, target.IsComplete);
        Assert.AreEqual(Initial_IsComplete, target.GetDataSource().CheckIsComplete());
        Assert.IsFalse(PCO.Fired());
    }


    [TestMethod]
    public void CanWriteSummary()
    {
        string endSummary = "Final Summary";

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.Summary));

        target.Summary = endSummary;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Summary, target.Summary);
        Assert.AreEqual(endSummary, target.Summary);
        Assert.AreEqual(endSummary, target.GetDataSource().Summary);
    }

    [TestMethod]
    public void CanWriteSummaryWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.Summary));

        target.Summary = Initial_Summary;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Summary, target.Summary);
        Assert.AreEqual(Initial_Summary, target.GetDataSource().Summary);
    }

    [TestMethod]
    public void CanWriteDescription()
    {
        string endDescription = "Final Description";

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.Description));

        target.Description = endDescription;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Description, target.Description);
        Assert.AreEqual(endDescription, target.Description);
        Assert.AreEqual(endDescription, target.GetDataSource().Description);
    }

    [TestMethod]
    public void CanWriteDescriptionWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.Description));

        target.Description = Initial_Description;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);
    }

    [TestMethod]
    public void CanWriteIsCurrentlyProgressing()
    {
        bool endIsCurrentlyProgressing = !Initial_IsCurrentlyProgressing;

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.IsCurrentlyProgressing));

        target.IsCurrentlyProgressing = endIsCurrentlyProgressing;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_IsCurrentlyProgressing, target.IsCurrentlyProgressing);
        Assert.AreEqual(endIsCurrentlyProgressing, target.IsCurrentlyProgressing);
        Assert.AreEqual(endIsCurrentlyProgressing, target.GetDataSource().IsCurrentlyProgressing);
    }

    [TestMethod]
    public void CanWriteIsCurrentlyProgressingWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.IsCurrentlyProgressing));

        target.IsCurrentlyProgressing = Initial_IsCurrentlyProgressing;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_IsCurrentlyProgressing, target.IsCurrentlyProgressing);
        Assert.AreEqual(Initial_IsCurrentlyProgressing, target.GetDataSource().IsCurrentlyProgressing);
    }

    [TestMethod]
    public void CanWriteIsRecurring()
    {
        bool endIsRecurring = !Initial_IsRecurring;

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.IsRecurring));

        target.IsRecurring = endIsRecurring;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_IsRecurring, target.IsRecurring);
        Assert.AreEqual(endIsRecurring, target.IsRecurring);
        Assert.AreEqual(endIsRecurring, target.GetDataSource().IsRecurring);
    }

    [TestMethod]
    public void CanWriteIsRecurringWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.IsRecurring));

        target.IsRecurring = Initial_IsRecurring;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_IsRecurring, target.IsRecurring);
        Assert.AreEqual(Initial_IsRecurring, target.GetDataSource().IsRecurring);
    }

    [TestMethod]
    public void CanReadCreationDate()
    {
        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.Creation_Date));

        Assert.AreEqual(Initial_Creation_Date, target.Creation_Date);
        Assert.AreEqual(Initial_Creation_Date, target.GetDataSource().Creation_Date);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteDuration()
    {
        int endDuration = Initial_Duration + 1;

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.Duration));

        target.Duration = endDuration;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Duration, target.Duration);
        Assert.AreEqual(endDuration, target.Duration);
        Assert.AreEqual(endDuration, target.GetDataSource().Duration);
    }

    [TestMethod]
    public void CanWriteDurationWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.Duration));

        target.Duration = Initial_Duration;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Duration, target.Duration);
        Assert.AreEqual(Initial_Duration, target.GetDataSource().Duration);
    }

    [TestMethod]
    public void CanReadProgress()
    {
        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.Progress));

        Assert.AreEqual(Initial_Progress, target.Progress);
        Assert.AreEqual(Initial_Progress, target.GetDataSource().Progress);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadStartDate()
    {
        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.StartDate));

        Assert.AreEqual(Initial_StartDate, target.StartDate);
        Assert.AreEqual(Initial_StartDate, target.GetDataSource().StartDate);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteSuccessChance()
    {
        int endSuccessChance = Initial_SuccessChance + 1;

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.SuccessChance));

        target.SuccessChance = endSuccessChance;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_SuccessChance, target.SuccessChance);
        Assert.AreEqual(endSuccessChance, target.SuccessChance);
        Assert.AreEqual(endSuccessChance, target.GetDataSource().SuccessChance);
    }

    [TestMethod]
    public void CanWriteSuccessChanceWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.SuccessChance));

        target.SuccessChance = Initial_SuccessChance;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_SuccessChance, target.SuccessChance);
        Assert.AreEqual(Initial_SuccessChance, target.GetDataSource().SuccessChance);
    }

    [TestMethod]
    public void CanWriteFailureChance()
    {
        int endFailureChance = Initial_FailureChance + 1;

        ObservableJob target = new ObservableJob(Source);
        PCO.AttachProperty(target, nameof(target.FailureChance));

        target.FailureChance = endFailureChance;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_FailureChance, target.FailureChance);
        Assert.AreEqual(endFailureChance, target.FailureChance);
        Assert.AreEqual(endFailureChance, target.GetDataSource().FailureChance);
    }

    [TestMethod]
    public void CanWriteFailureChanceWithNoInitialSource()
    {
        ObservableJob target = new ObservableJob();
        PCO.AttachProperty(target, nameof(target.FailureChance));

        target.FailureChance = Initial_FailureChance;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_FailureChance, target.FailureChance);
        Assert.AreEqual(Initial_FailureChance, target.GetDataSource().FailureChance);
    }

}
