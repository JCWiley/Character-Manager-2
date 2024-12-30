using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using Moq;

namespace CM4_Core_UnitTest.LogicalGroupTests
{
    [TestClass]
    public class WorldTests
    {
        [TestMethod]
        public void CanInjectMembersIntoWorld()
        {
            var MockPeople = new Mock<IPeople>();
            var MockPlaces = new Mock<IPlaces>();
            var MockThings = new Mock<IThings>();
            var MockTime = new Mock<ITime>();

            IWorld W = new World(MockPeople.Object, MockPlaces.Object, MockThings.Object, MockTime.Object); //PersistenceService
            Assert.IsNotNull(W);
        }

        [TestMethod]
        public void CanRetrieveInjectedObject()
        {
            var MockPeople = new Mock<IPeople>();
            var MockPlaces = new Mock<IPlaces>();
            var MockThings = new Mock<IThings>();
            var MockTime = new Mock<ITime>();

            IWorld W = new World(MockPeople.Object, MockPlaces.Object, MockThings.Object, MockTime.Object);

            Assert.IsNotNull(W);
            Assert.IsInstanceOfType<IPeople>(W.People);
            Assert.IsInstanceOfType<IPlaces>(W.Places);
            Assert.IsInstanceOfType<IThings>(W.Things);
            Assert.IsInstanceOfType<ITime>(W.Time);

        }

        //[TestMethod]
        //public void CanLoadFromPersistance()
        //{
        //}

        //[TestMethod]
        //public void CanSaveToPersistance()
        //{
        //}
    }
}
