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
using CM4_Core.MetaModels;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableCharacterTests
{
    Character Source;
    Guid Initial_ID;
    const string Initial_Name = "Test Name";
    const string Initial_Description = "Test Description";
    const string Initial_Quirks = "Test Quirks";
    const string Initial_Occupation = "Initial Occupation";
    const int Initial_Age = 10;
    
    Mock<WorldDataViewModel> WVM_Mock;
    People people;
    PropertyChangedObserver PCO;

    [TestInitialize]
    public void TestInit()
    {
        Initial_ID = Guid.NewGuid();

        Source = new Character();

        Source.ID = Initial_ID;
        Source.Name = Initial_Name;
        Source.Description = Initial_Description;
        Source.Quirks = Initial_Quirks;
        Source.Age = Initial_Age;

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WVM_Mock = new Mock<WorldDataViewModel>(DA_Mock.Object, NS_Mock.Object);
        people= new People(DA_Mock.Object, NS_Mock.Object);

        people.AddChar(Source);

        PCO = new PropertyChangedObserver(); ;
    }


    [TestMethod]
    public void CanReadID()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.ID));

        Assert.AreEqual(Initial_ID, target.ID);
        Assert.AreEqual(Initial_ID, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadName()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(Initial_Name, target.Name);
        Assert.AreEqual(Initial_Name, target.GetDataSource().Name);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteName()
    {
        string endName = "Final Name";

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        target.Name = endName;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Name, target.Name);
        Assert.AreEqual(endName, target.Name);
        Assert.AreEqual(endName, target.GetDataSource().Name);
    }


    [TestMethod]
    public void CanReadDescription()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteDescription()
    {
        string endDescription = "Final Description";

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        target.Description = endDescription;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Description, target.Description);
        Assert.AreEqual(endDescription, target.Description);
        Assert.AreEqual(endDescription, target.GetDataSource().Description);
    }

    [TestMethod]
    public void CanReadQuirks()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Quirks));

        Assert.AreEqual(Initial_Quirks, target.Quirks);
        Assert.AreEqual(Initial_Quirks, target.GetDataSource().Quirks);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteQuirks()
    {
        string endQuirks = "Final Quirks";

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Quirks));

        target.Quirks = endQuirks;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Quirks, target.Quirks);
        Assert.AreEqual(endQuirks, target.Quirks);
        Assert.AreEqual(endQuirks, target.GetDataSource().Quirks);
    }


    [TestMethod]
    public void CanReadOccupation()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);

        target.Occupation = Initial_Occupation;

        PCO.AttachProperty(target, nameof(target.Occupation));

        Assert.AreEqual(Initial_Occupation, target.Occupation);
        Assert.AreEqual(Initial_Occupation, target.GetDataSource().Occupation);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteOccupation()
    {
        string endOccupation = "Final Occupation";

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Occupation));

        target.Occupation = endOccupation;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Occupation, target.Occupation);
        Assert.AreEqual(endOccupation, target.Occupation);
        Assert.AreEqual(endOccupation, target.GetDataSource().Occupation);
    }

    [TestMethod]
    public void CanReadAge()
    {
        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Age));

        Assert.AreEqual(Initial_Age, target.Age);
        Assert.AreEqual(Initial_Age, target.GetDataSource().Age);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteAge()
    {
        int endAge = Initial_Age + 2;

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Age));

        target.Age = endAge;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Age, target.Age);
        Assert.AreEqual(endAge, target.Age);
        Assert.AreEqual(endAge, target.GetDataSource().Age);
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

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM);
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

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM);
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

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM);
        PCO.AttachProperty(target, nameof(target.Location));

        Assert.AreEqual(Initial_ObservableLocation, target.Location);
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

        ObservableCharacter target = new ObservableCharacter(Source.ID, people, WVM);
        PCO.AttachProperty(target, nameof(target.Location));

        target.Location = Initial_ObservableLocation;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Location);
        Assert.AreEqual(Initial_ObservableLocation, target.Location);
        Assert.AreEqual(Initial_Location.ID, target.GetDataSource().Location);
    }

}
