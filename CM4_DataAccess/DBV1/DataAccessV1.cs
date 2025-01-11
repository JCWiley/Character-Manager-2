using CM4_Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using CM4_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CM4_DataAccess.DBV1
{
    public class DataAccessV1 : IDataAccess
    {
        internal string _connectionString;

        string _DBPath;
        ICharacterAccess _ca;

        public DataAccessV1()
        {
            _connectionString = "";
            _DBPath = "";
            _ca = new CharacterAccessV1(this);
        }

        public ICharacterAccess CA { get 
            {
                IsReady();
                return _ca;
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
            catch
            {
                return false;
            }

            return OpenDataStore(storagePath);
        }

        public bool OpenDataStore(string storagePath) 
        {
            if (File.Exists(storagePath))
            {
                CloseDataStore();
                StoragePath = storagePath;
                ConfirmMigrations();
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
