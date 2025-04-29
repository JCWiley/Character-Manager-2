using CM4_Core.Models;
using CM4_UI.ObservableModels;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableSpeciesTests
{
    [TestMethod]
    public void CanReadID()
    {
        Species test = new Species();
        Guid testGuid = Guid.NewGuid();
        test.ID = testGuid;

        ObservableSpecies target = new ObservableSpecies(test);

        Assert.AreEqual(testGuid, target.ID);
        Assert.AreEqual(testGuid, target.GetDataSource().ID);
    }

    [TestMethod]
    public void CanReadName()
    {
        Species test = new Species();
        string name = "Test name";
        test.Name = name;

        ObservableSpecies target = new ObservableSpecies(test);

        Assert.AreEqual(name, target.Name);
        Assert.AreEqual(name, target.GetDataSource().Name);
    }

    [TestMethod]
    public void CanWriteName()
    {
        Species test = new Species();
        string startName = "Start Name";
        string endName = "End Name";
        test.Name = startName;

        ObservableSpecies target = new ObservableSpecies(test);
        target.Name = endName;

        Assert.AreNotEqual(startName, target.Name);
        Assert.AreEqual(endName, target.Name);
        Assert.AreEqual(endName, target.GetDataSource().Name);
    }
}
