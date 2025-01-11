using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_DataAccess.DBV1;
using Moq;

namespace CM4_DataAccess_UnitTest.DBV1Tests
{
    [TestClass]
    public sealed class DataAccessV1Tests
    {
        [ClassInitialize]
        public static void DataAccessV1Initialize(TestContext testContext)
        {}

        [TestMethod]
        public void DBPath_GetSet()
        {
            Mock<INotifyService> notifyService = new();
            Mock<ISettingsService> settingsService = new();
            IDataAccess LocalDA = new DataAccessV1(notifyService.Object, settingsService.Object);
            string Path = "foo";

            LocalDA.StoragePath = Path;

            Assert.AreEqual(Path, LocalDA.StoragePath);
        }

        [TestMethod]
        public void CreateDBFromTemplate()
        {
            Mock<INotifyService> notifyService = new();
            Mock<ISettingsService> settingsService = new();
            IDataAccess LocalDA = new DataAccessV1(notifyService.Object, settingsService.Object);
            bool result = LocalDA.CreateDataStore(@"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TempDB.db");

            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(LocalDA.StoragePath));
            LocalDA.CloseDataStore();
            File.Delete(LocalDA.StoragePath);
            Assert.IsFalse(File.Exists(LocalDA.StoragePath));
        }

        [TestMethod]
        [DataRow("C:/this/path/has spaces/in/it")]
        [DataRow("C:/this_folder_does_not_exist")]
        public void CreateDB_FailsIfPathNotExistOrInvalid(string path)
        {
            Mock<INotifyService> notifyService = new();
            Mock<ISettingsService> settingsService = new();
            IDataAccess LocalDA = new DataAccessV1(notifyService.Object, settingsService.Object);
            bool result = LocalDA.CreateDataStore(path);

            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(LocalDA.StoragePath));
        }

        [TestMethod]
        public void CreateDB_RecreatingStoreOnSamePathDoesOverwrite()
        {
            string test_path = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\OverwriteTestPath.db";

            if (File.Exists(test_path))
            {
                File.Delete(test_path);
            }

            Mock<INotifyService> notifyService = new();
            Mock<ISettingsService> settingsService = new();
            IDataAccess LocalDA = new DataAccessV1(notifyService.Object, settingsService.Object);

            bool result = LocalDA.CreateDataStore(test_path);
            Assert.IsTrue(result);

            Character C = new();
            C.Name = "Tim";

            LocalDA.CA.AddCharacter(C);

            Assert.IsTrue(LocalDA.CA.GetCharacters().Contains(C));

            result = LocalDA.CreateDataStore(test_path);

            Assert.IsTrue(result);
            Assert.IsFalse(LocalDA.CA.GetCharacters().Contains(C));
            Assert.AreEqual(LocalDA.CA.GetCharacters().Count(), 0);
        }

        [TestMethod]
        public void OpenDB_CanOpenExistingDataStore()
        {
            string test_path1 = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\OpenTest1.db";
            string test_path2 = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\OpenTest2.db";

            if (File.Exists(test_path1))
            {
                File.Delete(test_path1);
            }

            if (File.Exists(test_path2))
            {
                File.Delete(test_path2);
            }

            Mock<INotifyService> notifyService = new();
            Mock<ISettingsService> settingsService = new();
            IDataAccess LocalDA = new DataAccessV1(notifyService.Object, settingsService.Object);

            bool result = LocalDA.CreateDataStore(test_path1);
            Assert.IsTrue(result);

            Character C = new();
            C.Name = "Tim";

            LocalDA.CA.AddCharacter(C);

            result = LocalDA.CreateDataStore(test_path2);
            Assert.IsTrue(result);
            Assert.IsFalse(LocalDA.CA.GetCharacters().Contains(C));


            result = LocalDA.OpenDataStore(test_path1);
            Assert.IsTrue(result);
            Assert.IsTrue(LocalDA.CA.GetCharacters().Contains(C));
        }
    }
}
