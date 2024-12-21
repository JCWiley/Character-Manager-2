using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_DataAccess.DBV1;

namespace CM4_DataAccess_UnitTest.DBV1Tests
{
    [TestClass]
    public sealed class DataAccessV1Tests
    {
        static IDataAccess DA;

        [ClassInitialize]
        public static void DataAccessV1Initialize(TestContext testContext)
        {
            DA = new DataAccessV1();
            DA.StoragePath = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TestV1DB.db";
        }

        [TestMethod]
        public void DBPath_GetSet()
        {
            IDataAccess LocalDA = new DataAccessV1();
            string Path = "foo";

            LocalDA.StoragePath = Path;

            Assert.AreEqual(Path, LocalDA.StoragePath);
        }

        [TestMethod]
        public void CreateDBFromTemplate()
        {
            IDataAccess LocalDA = new DataAccessV1();
            LocalDA.StoragePath = @"C:\Users\JWiley\source\CM\CharacterManager4\CM4_DataAccess_UnitTest\TestData\TempDB.db";

            bool result = LocalDA.CreateDB();

            Assert.IsTrue(result);
            Assert.IsTrue(File.Exists(LocalDA.StoragePath));
            File.Delete(LocalDA.StoragePath);
            Assert.IsFalse(File.Exists(LocalDA.StoragePath));
        }

        [TestMethod]
        [DataRow("C:/this/path/has spaces/in/it")]
        [DataRow("C:/this_folder_does_not_exist")]
        public void CreateDB_FailsIfPathNotExistOrInvalid(string path)
        {
            IDataAccess LocalDA = new DataAccessV1();
            LocalDA.StoragePath = path;

            bool result = LocalDA.CreateDB();

            Assert.IsFalse(result);
            Assert.IsFalse(File.Exists(LocalDA.StoragePath));
        }
    }
}
