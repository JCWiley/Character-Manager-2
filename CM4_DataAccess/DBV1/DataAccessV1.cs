using CM4_Core.DataAccess;
using CM4_Core.Service.Implementations;
using CM4_Core.Service.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CM4_DataAccess.DBV1
{
    public class DataAccessV1 : IDataAccess
    {
        internal string _connectionString;

        string _DBPath;
        IRepository _r;
        INotifyService _notifyService;
        ISettingsService _settingsService;

        public DataAccessV1(INotifyService notifyService, ISettingsService settingsService)
        {
            _connectionString = "";
            _DBPath = "";
            _r = new Repository(this);
            _notifyService = notifyService;
            _settingsService = settingsService;
        }

        public IRepository Repository
        {
            get
            {
                IsReady();
                return _r;
            }
        }

        public string StoragePath 
        { 
            get { return _DBPath; }
            set
            {
                _DBPath = value;
                _connectionString = new SqliteConnectionStringBuilder()
                {
                    Mode = SqliteOpenMode.ReadWrite,
                    Cache = SqliteCacheMode.Shared,
                    DataSource = _DBPath
                }.ToString();
            }
        }

        public bool CreateDataStore(string storagePath)
        {
            try
            {
                var stream = File.Create(storagePath);
                stream.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return OpenDataStore(storagePath);
        }

        public bool OpenDataStore(string storagePath) 
        {
            if (File.Exists(storagePath))
            {
                _notifyService.OnDataSourceAboutToChange(this);
                CloseDataStore();
                StoragePath = storagePath;
                ConfirmMigrations();
                _settingsService.ProjectPath = StoragePath;
                _notifyService.OnDataSourceChanged(this);
                return true;
            }
            return false;
        }
        public void CloseDataStore()
        {
            SqliteConnection.ClearAllPools();
        }
        internal bool IsReady()
        {
            if (_connectionString == null || !File.Exists(_DBPath))
            {
                //throw new Exception("Invalid Database Path");
                return false;
            }
            return true;
        }

        internal void ConfirmMigrations()
        {
            if (IsReady())
            {
                using (WorldContext Context = new WorldContext(_connectionString))
                {
                    try
                    {
                        Context.Database.Migrate();
                    }
                    catch
                    {
                        throw new Exception("Migration Failed");
                    }
                }
                
            }
        }
    }
}
