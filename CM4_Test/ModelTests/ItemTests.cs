using CM4_Core.Models;

namespace CM4_Core_UnitTest.ModelTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void CanCreateItem()
        {
            InventoryItem item = new InventoryItem();
        }

        [TestMethod]
        [DataRow("Thor's hammer")]
        [DataRow("The one ring")]
        [DataRow("")]
        public void Name_CanStoreAndRetrieve(string name)
        {
            InventoryItem item = new InventoryItem();
            item.Name = name;
            Assert.AreEqual(name, item.Name);
        }

        [TestMethod]
        [DataRow("Hammer crackling with lightning")]
        [DataRow("One ring to rule them all and in the darkness bind them")]
        [DataRow("")]
        public void Description_CanStoreAndRetrieve(string description)
        {
            InventoryItem item = new InventoryItem();
            item.Description = description;
            Assert.AreEqual(description, item.Description);
        }
    }
}