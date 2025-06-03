using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using CM4_UI_UnitTest.Utilities;
using DynamicData;
using Moq;
using System.Collections.Specialized;

namespace CM4_UI_UnitTest.ObservableModels;

[TestClass]
public class ObservableOrganizationTests
{
    Organization Source;
    Guid Initial_ID;
    const string Initial_Name = "Test Name";
    const string Initial_Description = "Test Description";
    const string Initial_Goals = "Test Goals";
    const string Initial_Quirks = "Test Quirks";
    const int Initial_Size = 3;

    Mock<WorldDataViewModel> WVM_Mock;
    Mock<PeopleViewModel> PVM_Mock;
    PropertyChangedObserver PCO;

    [TestInitialize]
    public void TestInit()
    {
        Initial_ID = Guid.NewGuid();

        Source = new Organization();

        Source.ID = Initial_ID;
        Source.Name = Initial_Name;
        Source.Description = Initial_Description;
        Source.Goals = Initial_Goals;
        Source.Quirks = Initial_Quirks;
        Source.Size = Initial_Size;

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WVM_Mock = new Mock<WorldDataViewModel>(DA_Mock.Object, NS_Mock.Object);

        PVM_Mock = new Mock<PeopleViewModel>(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        PCO = new PropertyChangedObserver(); ;
    }

    [TestMethod]
    public void CanReadID()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.ID));

        Assert.AreEqual(Initial_ID, target.ID);
        Assert.AreEqual(Initial_ID, target.GetDataSource().ID);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadName()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        Assert.AreEqual(Initial_Name, target.Name);
        Assert.AreEqual(Initial_Name, target.GetDataSource().Name);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteName()
    {
        string endName = "Final Name";

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
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
        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Name));

        target.Name = Initial_Name;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Name, target.Name);
        Assert.AreEqual(Initial_Name, target.GetDataSource().Name);
    }

    [TestMethod]
    public void CanReadDescription()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteDescription()
    {
        string endDescription = "Final Description";

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
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
        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Description));

        target.Description = Initial_Description;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Description, target.Description);
        Assert.AreEqual(Initial_Description, target.GetDataSource().Description);

    }

    [TestMethod]
    public void CanReadGoals()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Goals));

        Assert.AreEqual(Initial_Goals, target.Goals);
        Assert.AreEqual(Initial_Goals, target.GetDataSource().Goals);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteGoals()
    {
        string endGoals = "Final Goals";

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
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
        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Goals));

        target.Goals = Initial_Goals;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Goals, target.Goals);
        Assert.AreEqual(Initial_Goals, target.GetDataSource().Goals);
    }

    [TestMethod]
    public void CanReadQuirks()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Quirks));

        Assert.AreEqual(Initial_Quirks, target.Quirks);
        Assert.AreEqual(Initial_Quirks, target.GetDataSource().Quirks);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteQuirks()
    {
        string endQuirks = "Final Quirks";

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Quirks));

        target.Quirks = endQuirks;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Quirks, target.Quirks);
        Assert.AreEqual(endQuirks, target.Quirks);
        Assert.AreEqual(endQuirks, target.GetDataSource().Quirks);
    }

    [TestMethod]
    public void CanWriteQuirksWithNoInitialSource()
    {
        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Quirks));

        target.Quirks = Initial_Quirks;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Quirks, target.Quirks);
        Assert.AreEqual(Initial_Quirks, target.GetDataSource().Quirks);
    }

    [TestMethod]
    public void CanReadSize()
    {
        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Size));

        Assert.AreEqual(Initial_Size, target.Size);
        Assert.AreEqual(Initial_Size, target.GetDataSource().Size);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteSize()
    {
        int endSize = Initial_Size + 2;

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Size));

        target.Size = endSize;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(Initial_Size, target.Size);
        Assert.AreEqual(endSize, target.Size);
        Assert.AreEqual(endSize, target.GetDataSource().Size);
    }

    [TestMethod]
    public void CanWriteSizeWithNoInitialSource()
    {
        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM_Mock.Object);
        PCO.AttachProperty(target, nameof(target.Size));

        target.Size = Initial_Size;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Initial_Size, target.Size);
        Assert.AreEqual(Initial_Size, target.GetDataSource().Size);
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

        Source.PrimarySpecies = Initial_Species.ID;

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.PrimarySpecies));

        Assert.AreEqual(Initial_ObservableSpecies, target.PrimarySpecies);
        Assert.AreEqual(Initial_ObservableSpecies.ID, target.GetDataSource().PrimarySpecies);
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

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.PrimarySpecies));

        target.PrimarySpecies = Initial_ObservableSpecies;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.PrimarySpecies);
        Assert.AreEqual(Initial_ObservableSpecies, target.PrimarySpecies);
        Assert.AreEqual(Initial_Species.ID, target.GetDataSource().PrimarySpecies);
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

        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.PrimarySpecies));

        target.PrimarySpecies = Initial_ObservableSpecies;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.PrimarySpecies);
        Assert.AreEqual(Initial_ObservableSpecies, target.PrimarySpecies);
        Assert.AreEqual(Initial_Species.ID, target.GetDataSource().PrimarySpecies);
    }

    [TestMethod]
    public void CanReadHeadquarters()
    {
        Location Initial_Headquarters = new Location();
        ObservableLocation Initial_ObservableHeadquarters = new ObservableLocation(Initial_Headquarters);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableHeadquarters);

        Source.Location = Initial_Headquarters.ID;

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        Assert.AreEqual(Initial_ObservableHeadquarters, target.Headquarters);
        Assert.AreEqual(Initial_ObservableHeadquarters.ID, target.GetDataSource().Location);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanWriteHeadquarters()
    {
        Location Initial_Headquarters = new Location();
        ObservableLocation Initial_ObservableHeadquarters = new ObservableLocation(Initial_Headquarters);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableHeadquarters);

        ObservableOrganization target = new ObservableOrganization(Source, PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        target.Headquarters = Initial_ObservableHeadquarters;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Headquarters);
        Assert.AreEqual(Initial_ObservableHeadquarters, target.Headquarters);
        Assert.AreEqual(Initial_Headquarters.ID, target.GetDataSource().Location);
    }

    [TestMethod]
    public void CanWriteHeadquartersWithNoInitialSource()
    {
        Location Initial_Headquarters = new Location();
        ObservableLocation Initial_ObservableHeadquarters = new ObservableLocation(Initial_Headquarters);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        WorldDataViewModel WVM = new WorldDataViewModel(DA_Mock.Object, NS_Mock.Object);
        WVM.LocationList.Add(Initial_ObservableHeadquarters);

        ObservableOrganization target = new ObservableOrganization(PVM_Mock.Object, WVM);
        PCO.AttachProperty(target, nameof(target.Headquarters));

        target.Headquarters = Initial_ObservableHeadquarters;

        Assert.IsTrue(PCO.Fired());

        Assert.AreNotEqual(null, target.Headquarters);
        Assert.AreEqual(Initial_ObservableHeadquarters, target.Headquarters);
        Assert.AreEqual(Initial_Headquarters.ID, target.GetDataSource().Location);
    }

    [TestMethod]
    public void CanHaveNullAsLeader()
    {
        Organization Source = new Organization();

        ObservableOrganization Target = new ObservableOrganization(Source, PVM_Mock.Object, WVM_Mock.Object);

        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreEqual(null, Target.Leader);
        Assert.AreEqual(null, Target.GetDataSource().Leader);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadLeaderWhenCharacter()
    {
        Character Leader = new Character();
        Organization Source = new Organization();

        Source.Leader = Leader.ID;
        Source.Child_Characters.Add(Leader.ID);
        Leader.Parent_Organizations.Add(Source.ID);

        ObservableCharacter ObservableLeader = new ObservableCharacter(Leader, WVM_Mock.Object);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        PVM.CharacterList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreNotEqual(null, Target.Leader);
        Assert.AreEqual(Target.Leader, ObservableLeader);
        Assert.AreEqual(Target.GetDataSource().Leader,Leader.ID);
        Assert.IsInstanceOfType<ObservableCharacter>(Target.Leader);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanReadLeaderWhenOrganization()
    {
        Organization Leader = new Organization();
        Organization Source = new Organization();

        Source.Leader = Leader.ID;
        Source.Child_Organizations.Add(Leader.ID);
        Leader.Parent_Organizations.Add(Source.ID);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        ObservableOrganization ObservableLeader = new ObservableOrganization(Leader, PVM, WVM_Mock.Object);

        PVM.OrganizationList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreNotEqual(null, Target.Leader);
        Assert.AreEqual(Target.Leader, ObservableLeader);
        Assert.AreEqual(Target.GetDataSource().Leader, Leader.ID);
        Assert.IsInstanceOfType<ObservableOrganization>(Target.Leader);
        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    public void CanSetLeaderToCharacter()
    {
        Character Leader = new Character();
        Organization Source = new Organization();

        Source.Child_Characters.Add(Leader.ID);
        Leader.Parent_Organizations.Add(Source.ID);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        ObservableCharacter ObservableLeader = new ObservableCharacter(Leader, WVM_Mock.Object);

        PVM.CharacterList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreEqual(null, Target.Leader);

        Target.Leader = ObservableLeader;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Target.Leader, ObservableLeader);
        Assert.AreEqual(Target.GetDataSource().Leader, Leader.ID);
        Assert.IsInstanceOfType<ObservableCharacter>(Target.Leader);
    }

    [TestMethod]
    public void CanSetLeaderToOrganization()
    {
        Organization Leader = new Organization();
        Organization Source = new Organization();

        Source.Child_Organizations.Add(Leader.ID);
        Leader.Parent_Organizations.Add(Source.ID);

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        ObservableOrganization ObservableLeader = new ObservableOrganization(Leader, PVM, WVM_Mock.Object);

        PVM.OrganizationList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreEqual(null, Target.Leader);

        Target.Leader = ObservableLeader;

        Assert.IsTrue(PCO.Fired());

        Assert.AreEqual(Target.Leader, ObservableLeader);
        Assert.AreEqual(Target.GetDataSource().Leader, Leader.ID);
        Assert.IsInstanceOfType<ObservableOrganization>(Target.Leader);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CannotSetLeaderToOrganizationThatIsNotChild()
    {
        Organization Leader = new Organization();
        Organization Source = new Organization();

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        ObservableOrganization ObservableLeader = new ObservableOrganization(Leader, PVM, WVM_Mock.Object);

        PVM.OrganizationList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreEqual(null, Target.Leader);

        Target.Leader = ObservableLeader;

        Assert.IsFalse(PCO.Fired());
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void CannotSetLeaderToCharacterThatIsNotChild()
    {
        Character Leader = new Character();
        Organization Source = new Organization();

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        ObservableCharacter ObservableLeader = new ObservableCharacter(Leader, WVM_Mock.Object);

        PVM.CharacterList.Add(ObservableLeader);

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);
        PCO.AttachProperty(Target, nameof(Target.Leader));

        Assert.AreEqual(null, Target.Leader);

        Target.Leader = ObservableLeader;

        Assert.IsFalse(PCO.Fired());
    }


    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void TargetChildOrgsMatchSourceChildOrgs(int ChildOrgCount)
    {
        Organization Source = new Organization();

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        List<ObservableOrganization> OrgList = new List<ObservableOrganization>();

        for (int i = 0; i < ChildOrgCount; i++)
        {
            ObservableOrganization org = new ObservableOrganization(PVM, WVM_Mock.Object);
            Source.Child_Organizations.Add(org.ID);
            OrgList.Append(org);
            PVM.OrganizationList.Add(org);
        }

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);

        for (int i = 0;i < ChildOrgCount; i++)
        {
            Assert.AreEqual(Target.Child_Organization_IDs[i], Source.Child_Organizations[i]);
            Assert.AreEqual(Target.Child_Organizations[i].ID, Source.Child_Organizations[i]);
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void TargetChildCharsMatchSourceChildChars(int ChildOrgCount)
    {
        Organization Source = new Organization();

        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        List<ObservableCharacter> CharList = new List<ObservableCharacter>();

        for (int i = 0; i < ChildOrgCount; i++)
        {
            ObservableCharacter Character = new ObservableCharacter(WVM_Mock.Object);
            Source.Child_Characters.Add(Character.ID);
            CharList.Add(Character);
            PVM.CharacterList.Add(Character);
        }

        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);

        for (int i = 0; i < ChildOrgCount; i++)
        {
            Assert.AreEqual(Target.Child_Character_IDs[i], Source.Child_Characters[i]);
            Assert.AreEqual(Target.Child_Characters[i].ID, Source.Child_Characters[i]);
        }
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanAddNNewChildOrganizations(int numNewChildOrgs)
    {
        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        bool propertyChanged = false;

        List<ObservableOrganization> OrgList = new List<ObservableOrganization>();

        for (int i = 0; i < numNewChildOrgs; i++)
        {
            ObservableOrganization Organization = new ObservableOrganization(PVM, WVM_Mock.Object);
            OrgList.Add(Organization);
            PVM.OrganizationList.Add(Organization);
        }

        Organization Source = new Organization();
        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);

        Target.Child_Organization_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        for (int i = 0; i < numNewChildOrgs; i++)
        {
            Target.Child_Organization_IDs.Add(OrgList[i].ID);
            Assert.IsTrue(propertyChanged);
            propertyChanged = false;
        }

        Assert.AreEqual(Target.Child_Organization_IDs.Count, numNewChildOrgs);
        Assert.AreEqual(Target.Child_Organizations.Count, numNewChildOrgs);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanAddNNewChildCharacters(int numNewChildChars)
    {
        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        bool propertyChanged = false;

        List<ObservableCharacter> CharList = new List<ObservableCharacter>();

        for (int i = 0; i < numNewChildChars; i++)
        {
            ObservableCharacter Character = new ObservableCharacter(WVM_Mock.Object);
            CharList.Add(Character);
            PVM.CharacterList.Add(Character);
        }

        Organization Source = new Organization();
        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);

        Target.Child_Character_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        PCO.AttachProperty(Target, nameof(Target.Child_Character_IDs));

        for (int i = 0;i < numNewChildChars;i++)
        {
            Target.Child_Character_IDs.Add(CharList[i].ID);
            Assert.IsTrue(propertyChanged);
            propertyChanged = false;
        }

        Assert.AreEqual(Target.Child_Character_IDs.Count, numNewChildChars);
        Assert.AreEqual(Target.Child_Characters.Count, numNewChildChars);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(100)]
    [DataRow(1000)]
    public void CanAddNNewParentOrganizations(int numNewParentOrgs)
    {
        Mock<IDataAccess> DA_Mock = new Mock<IDataAccess>();
        Mock<INotifyService> NS_Mock = new Mock<INotifyService>();
        PeopleViewModel PVM = new PeopleViewModel(DA_Mock.Object, NS_Mock.Object, WVM_Mock.Object);

        bool propertyChanged = false;

        List<ObservableOrganization> OrgList = new List<ObservableOrganization>();

        for (int i = 0; i < numNewParentOrgs; i++)
        {
            ObservableOrganization Organization = new ObservableOrganization(PVM, WVM_Mock.Object);
            OrgList.Add(Organization);
            PVM.OrganizationList.Add(Organization);
        }

        Organization Source = new Organization();
        ObservableOrganization Target = new ObservableOrganization(Source, PVM, WVM_Mock.Object);

        Target.Parent_Organization_IDs.CollectionChanged += delegate (object? sender, NotifyCollectionChangedEventArgs e)
        {
            propertyChanged = true;
        };

        for (int i = 0; i < numNewParentOrgs; i++)
        {
            Target.Parent_Organization_IDs.Add(OrgList[i].ID);
            Assert.IsTrue(propertyChanged);
            propertyChanged = false;
        }

        Assert.AreEqual(Target.Parent_Organization_IDs.Count, numNewParentOrgs);
        Assert.AreEqual(Target.Parent_Organization_IDs.Count, numNewParentOrgs);
    }

}
