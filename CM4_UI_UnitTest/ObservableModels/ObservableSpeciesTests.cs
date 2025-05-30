using CM4_Core.Models;
using CM4_UI.ObservableModels;
using CM4_UI_UnitTest.Utilities;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableSpeciesTests
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
        Species test = new Species();
        Guid testGuid = Guid.NewGuid();
        test.ID = testGuid;

        ObservableSpecies target = new ObservableSpecies(test);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(testGuid, target.ID);
        Assert.AreEqual(testGuid, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadName()
    {
        Species test = new Species();
        string name = "Test name";
        test.Name = name;

        ObservableSpecies target = new ObservableSpecies(test);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(name, target.Name);
        Assert.AreEqual(name, target.GetDataSource().Name);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteName()
    {
        Species test = new Species();
        string startName = "Start Name";
        string endName = "End Name";
        test.Name = startName;

        ObservableSpecies target = new ObservableSpecies(test);
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

        ObservableSpecies target = new ObservableSpecies();
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

        ObservableSpecies target = new ObservableSpecies();
        target.Name = Name;

        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(Name, target.ToString());
        Assert.IsFalse(PCO.Fired());
    }
}
