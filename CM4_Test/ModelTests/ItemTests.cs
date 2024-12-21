using CM4_Core.DataStructures;
using CM4_Core.ModelInterfaces;
using CM4_Core.Models;

namespace CM4_Core_UnitTest.ModelTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void CanCreateItem()
        {
            IInventoryItem item = new InventoryItem();
        }

        [TestMethod]
        [DataRow("Thor's hammer")]
        [DataRow("The one ring")]
        [DataRow("")]
        public void Name_CanStoreAndRetrieve(string name)
        {
            IInventoryItem item = new InventoryItem();
            item.Name = name;
            Assert.AreEqual(name, item.Name);
        }

        [TestMethod]
        [DataRow("Hammer crackling with lightning")]
        [DataRow("One ring to rule them all and in the darkness bind them")]
        [DataRow("")]
        public void Description_CanStoreAndRetrieve(string description)
        {
            IInventoryItem item = new InventoryItem();
            item.Description = description;
            Assert.AreEqual(description, item.Description);
        }
    }
}