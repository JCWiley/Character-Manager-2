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
public class ObservableCharacterTests
{
    Character Source;
    Guid Initial_ID;
    const string Initial_Name = "Test Name";
    const string Initial_Description = "Test Description";
    const string Initial_Goals = "Test Goals";
    const int Initial_Age = 10;
    
    Mock<WorldDataViewModel> WVM_Mock;
    PropertyChangedObserver PCO;

    [TestInitialize]
    public void TestInit()
    {
        Initial_ID = Guid.NewGuid();

        Source = new Character();

        Source.ID = Initial_ID;
        Source.Name = Initial_Name;
        Source.Description = Initial_Description;
        Source.Goals = Initial_Goals;
        Source.Age = Initial_Age;

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WVM_Mock = new Mock<WorldDataViewModel>(DA_Mock.Object, NS_Mock.Object);

        PCO = new PropertyChangedObserver(); ;
    }


    [TestMethod]
    public void CanReadID()
    {
        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.ID));

        Assert.AreEqual(Initial_ID, target.ID);
        Assert.AreEqual(Initial_ID, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadName()
    {
        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(Initial_Name, target.Name);
        Assert.AreEqual(Initial_Name, target.GetDataSource().Name);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteName()
    {
        string endName = "Final Name";

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        target.Name = endName;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Name, target.Name);
        Assert.AreEqual(endName, target.Name);
        Assert.AreEqual(endName, target.GetDataSource().Name);
    }

    [TestMethod]
    public void CanWriteNameWithNoInitialSource()
    {
        ObservableCharacter target = new ObservableCharacter(WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        target.Name = Initial_Name;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Name, target.Name);
        Assert.AreEqual(Initial_Name, target.GetDataSource().Name);
    }

    [TestMethod]
    public void CanReadDescription()
    {
        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteDescription()
    {
        string endDescription = "Final Description";

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
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
        ObservableCharacter target = new ObservableCharacter(WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        target.Description = Initial_Description;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);
        
    }

    [TestMethod]
    public void CanReadGoals()
    {
        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Goals));

        Assert.AreEqual(Initial_Goals, target.Goals);
        Assert.AreEqual(Initial_Goals, target.GetDataSource().Goals);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteGoals()
    {
        string endGoals = "Final Goals";

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Goals));

        target.Goals = endGoals;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Goals, target.Goals);
        Assert.AreEqual(endGoals, target.Goals);
        Assert.AreEqual(endGoals, target.GetDataSource().Goals);
    }

    [TestMethod]
    public void CanWriteGoalsWithNoInitialSource()
    {
        ObservableCharacter target = new ObservableCharacter(WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Goals));

        target.Goals = Initial_Goals;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Goals, target.Goals);
        Assert.AreEqual(Initial_Goals, target.GetDataSource().Goals);
    }

    [TestMethod]
    public void CanReadAge()
    {
        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Age));

        Assert.AreEqual(Initial_Age, target.Age);
        Assert.AreEqual(Initial_Age, target.GetDataSource().Age);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteAge()
    {
        int endAge = Initial_Age + 2;

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Age));

        target.Age = endAge;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Age, target.Age);
        Assert.AreEqual(endAge, target.Age);
        Assert.AreEqual(endAge, target.GetDataSource().Age);
    }

    [TestMethod]
    public void CanWriteAgeWithNoInitialSource()
    {
        ObservableCharacter target = new ObservableCharacter(WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Age));

        target.Age = Initial_Age;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Age, target.Age);
        Assert.AreEqual(Initial_Age, target.GetDataSource().Age);
    }

    [TestMethod]
    public void CanReadSpecies()
    {
        Species Initial_Species = new Species();
        ObservableSpecies Initial_ObservableSpecies = new ObservableSpecies(Initial_Species);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.SpeciesList.Add(Initial_ObservableSpecies);

        Source.Species = Initial_Species.ID;

        ObservableCharacter target = new ObservableCharacter(Source, WVM);
        PCO.AttachProperty(target, nameof(target.Species));

        Assert.AreEqual(Initial_ObservableSpecies, target.Species);
        Assert.AreEqual(Initial_ObservableSpecies.ID, target.GetDataSource().Species);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteSpecies()
    {
        Species Initial_Species = new Species();
        ObservableSpecies Initial_ObservableSpecies = new ObservableSpecies(Initial_Species);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.SpeciesList.Add(Initial_ObservableSpecies);

        ObservableCharacter target = new ObservableCharacter(Source, WVM);
        PCO.AttachProperty(target, nameof(target.Species));

        target.Species = Initial_ObservableSpecies;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Species);
        Assert.AreEqual(Initial_ObservableSpecies, target.Species);
        Assert.AreEqual(Initial_Species.ID, target.GetDataSource().Species);
    }

    [TestMethod]
    public void CanWriteSpeciesWithNoInitialSource()
    {
        Species Initial_Species = new Species();
        ObservableSpecies Initial_ObservableSpecies = new ObservableSpecies(Initial_Species);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.SpeciesList.Add(Initial_ObservableSpecies);

        ObservableCharacter target = new ObservableCharacter(WVM);
        PCO.AttachProperty(target, nameof(target.Species));

        target.Species = Initial_ObservableSpecies;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Species);
        Assert.AreEqual(Initial_ObservableSpecies, target.Species);
        Assert.AreEqual(Initial_Species.ID, target.GetDataSource().Species);
    }

    public void CanReadLocation()
    {
        Location Initial_Location = new Location();
        ObservableLocation Initial_ObservableLocation = new ObservableLocation(Initial_Location);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableLocation);

        Source.Location = Initial_Location.ID;

        ObservableCharacter target = new ObservableCharacter(Source, WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        Assert.AreEqual(Initial_ObservableLocation, target.Headquarters);
        Assert.AreEqual(Initial_ObservableLocation.ID, target.GetDataSource().Location);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteLocation()
    {
        Location Initial_Location = new Location();
        ObservableLocation Initial_ObservableLocation = new ObservableLocation(Initial_Location);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableLocation);

        ObservableCharacter target = new ObservableCharacter(Source, WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        target.Headquarters = Initial_ObservableLocation;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Headquarters);
        Assert.AreEqual(Initial_ObservableLocation, target.Headquarters);
        Assert.AreEqual(Initial_Location.ID, target.GetDataSource().Location);
    }

    [TestMethod]
    public void CanWriteLocationWithNoInitialSource()
    {
        Location Initial_Location = new Location();
        ObservableLocation Initial_ObservableLocation = new ObservableLocation(Initial_Location);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableLocation);

        ObservableCharacter target = new ObservableCharacter(WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        target.Headquarters = Initial_ObservableLocation;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Headquarters);
        Assert.AreEqual(Initial_ObservableLocation, target.Headquarters);
        Assert.AreEqual(Initial_Location.ID, target.GetDataSource().Location);
    }

    [TestMethod]
    public void CanAddSingleParent()
    {
        Guid guid = Guid.NewGuid();
        bool propertyChanged = false;

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        target.Parent_Organization_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        target.Parent_Organization_IDs.Add(guid);

        Assert.IsTrue(propertyChanged);

        Assert.AreNotEqual(null, target.Parent_Organization_IDs);
        Assert.IsTrue(target.Parent_Organization_IDs.Contains(guid));
        Assert.IsTrue(target.GetDataSource().Parent_Organizations.Contains(guid));
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    [DataRow(233)]
    [DataRow(444)]
    [DataRow(10000)]
    public void CanAddMultipleParents(int GuidCount)
    {
        List<Guid> guids = new List<Guid>();
        for (int i = 0; i < GuidCount; i++)
        {
            guids.Add(Guid.NewGuid());
        }
        Guid guid = Guid.NewGuid();
        bool propertyChanged = false;

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        target.Parent_Organization_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        for (int i = 0;i < GuidCount; i++)
        {
            propertyChanged = false;
            target.Parent_Organization_IDs.Add(guids[i]);
            Assert.IsTrue(propertyChanged);
        }

        Assert.AreNotEqual(null, target.Parent_Organization_IDs);

        for (int i = 0; i < GuidCount; i++)
        {
            Assert.IsTrue(target.Parent_Organization_IDs.Contains(guids[i]));
            Assert.IsTrue(target.GetDataSource().Parent_Organizations.Contains(guids[i]));
        }
    }

    [TestMethod]
    public void CanRemoveSingleParent()
    {
        Guid guid = Guid.NewGuid();
        bool propertyChanged = false;

        ObservableCharacter target = new ObservableCharacter(Source, WVM_Mock.Object);
        target.Parent_Organization_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        target.Parent_Organization_IDs.Add(guid);
        Assert.IsTrue(propertyChanged);
        propertyChanged = false;
        target.Parent_Organization_IDs.Remove(guid);
        Assert.IsTrue(propertyChanged);

        Assert.AreNotEqual(null, target.Parent_Organization_IDs);
        Assert.IsFalse(target.Parent_Organization_IDs.Contains(guid));
        Assert.IsFalse(target.GetDataSource().Parent_Organizations.Contains(guid));
    }

}
