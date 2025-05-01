using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using CM4_UI_UnitTest.Utilities;
using Moq;
using System.ComponentModel;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableLocationTests
{
    PropertyChangedObserver PCO;
    [TestInitialize]
    public void TestInit()
    {
        PCO = new PropertyChangedObserver(); ;
    }

    [TestMethod]
    public void CanReadID()
    {
        Location test = new Location();
        Guid testGuid = Guid.NewGuid();
        test.ID = testGuid;

        ObservableLocation target = new ObservableLocation(test);
        PCO.AttachProperty(target, nameof(target.ID));

        Assert.AreEqual(testGuid, target.ID);
        Assert.AreEqual(testGuid, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadName()
    {
        Location test = new Location();
        string name = "Test name";
        test.Name = name;

        ObservableLocation target = new ObservableLocation(test);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(name, target.Name);
        Assert.AreEqual(name, target.GetDataSource().Name);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteName()
    {
        Location test = new Location();
        string startName = "Start Name";
        string endName = "End Name";
        test.Name = startName;

        ObservableLocation target = new ObservableLocation(test);
        PCO.AttachProperty(target, nameof(target.Name));

        target.Name = endName;

        Assert.AreNotEqual(startName, target.Name);
        Assert.AreEqual(endName, target.Name);
        Assert.AreEqual(endName, target.GetDataSource().Name);
        Assert.IsTrue(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteNameWithNoInitialSource()
    {
        string Name = "Name";

        ObservableLocation target = new ObservableLocation();
        PCO.AttachProperty(target, nameof(target.Name));
        target.Name = Name;

        Assert.AreEqual(Name, target.Name);
        Assert.AreEqual(Name, target.GetDataSource().Name);
        Assert.IsTrue(PCO.Fired());
    }

    [TestMethod]
    public void CastingToStringReturnsName()
    {
        string Name = "Name";

        ObservableLocation target = new ObservableLocation();
        target.Name = Name;

        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(Name, target.ToString());
        Assert.IsFalse(PCO.Fired());
    }
}
