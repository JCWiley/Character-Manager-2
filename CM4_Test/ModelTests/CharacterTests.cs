using CM4_Core.ModelInterfaces;
using CM4_Core.Models;

namespace CM4_Core_UnitTest.ModelTests
{
    [TestClass]
    public class CharacterTests
    {

        [TestMethod]
        public void CanCreateCharacter()
        {
            ICharacter character = new Character();
        }

        [TestMethod]
        [DataRow("Tim")]
        [DataRow("Alice")]
        [DataRow("")]
        public void Name_CanStoreAndRetrieve(string name)
        {
            ICharacter character = new Character();
            character.Name = name;
            Assert.AreEqual(character.Name, name);

        }

        [TestMethod]
        public void Age_InitialValueNotNull()
        {
            ICharacter character = new Character();
            Assert.IsNotNull(character.Age);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(20)]
        [DataRow(665)]
        public void Age_CanStoreAndRetrieve(int age)
        {
            ICharacter character = new Character();
            character.Age = age;
            Assert.AreEqual(character.Age, age);
        }
    }
}