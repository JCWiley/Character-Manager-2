
using CM4_Core.DataStructures;
using CM4_Core.DataStructureInterfaces;

namespace CM4_Core_UnitTest.DataStructureTests
{
    [TestClass]
    public class GuidTests
    {
        [TestMethod]
        public void GuidBase_ReturnsGuid()
        {
            IGuidID G = new GuidBaseClass();
            Assert.IsInstanceOfType(G.ID, typeof(Guid));
        }

        [TestMethod]
        public void GuidBase_ReturnedGuidIsNotDuplicate()
        {
            IGuidID I = new GuidBaseClass();
            IGuidID J = new GuidBaseClass();
            Assert.AreNotEqual(I.ID, J.ID);
        }

        [TestMethod]
        public void GuidBase_CanInitializeWithPremadeGuid()
        {
            Guid guid = Guid.NewGuid();
            IGuidID iD = new GuidBaseClass(guid);
        }

        [TestMethod]
        public void GuidBase_CanSetGuid()
        {
            Guid guid = Guid.NewGuid();
            IGuidID G = new GuidBaseClass();
            G.ID = guid;
        }

        [TestMethod]
        public void GuidBase_IGuidIDWithSameValueAreEqual()
        {
            Guid guid = Guid.NewGuid();
            IGuidID I = new GuidBaseClass(guid);
            IGuidID J = new GuidBaseClass(guid);
            Assert.AreEqual(I, J);
        }

        [TestMethod]
        public void ItemGuid_ReturnsGuid()
        {
            IGuidID G = new ItemGuid();
            Assert.IsInstanceOfType(G.ID, typeof(Guid));
        }

        [TestMethod]
        public void CharacterGuid_ReturnsGuid()
        {
            IGuidID G = new CharacterGuid();
            Assert.IsInstanceOfType(G.ID, typeof(Guid));
        }

        [TestMethod]
        public void OrganizationGuid_ReturnsGuid()
        {
            IGuidID G = new OrganizationGuid();
            Assert.IsInstanceOfType(G.ID, typeof(Guid));
        }
    }
}
