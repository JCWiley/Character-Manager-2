using CM4_Core.Models;

namespace CM4_Core_UnitTest.ModelTests
{
    [TestClass]
    public class CharacterTests
    {

        [TestMethod]
        public void CanCreateCharacter()
        {
            Character character = new Character();
        }

        [TestMethod]
        public void CanCompareCharacter() 
        {
            Character character1 = new Character();
            Character character2 = new Character();

            Assert.AreEqual(character1, character1);
            Assert.AreEqual(character2, character2);
            Assert.AreNotEqual(character1, character2);
        }

        [TestMethod]
        [DataRow("Tim")]
        [DataRow("Alice")]
        [DataRow("")]
        public void Name_CanStoreAndRetrieve(string name)
        {
            Character character = new Character();
            character.Name = name;
            Assert.AreEqual(character.Name, name);

        }

        [TestMethod]
        public void Age_InitialValueNotNull()
        {
            Character character = new Character();
            Assert.IsNotNull(character.Age);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(20)]
        [DataRow(665)]
        public void Age_CanStoreAndRetrieve(int age)
        {
            Character character = new Character();
            character.Age = age;
            Assert.AreEqual(character.Age, age);
        }
    }
}