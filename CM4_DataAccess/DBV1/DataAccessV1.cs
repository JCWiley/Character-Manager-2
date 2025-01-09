﻿using CM4_Core.DataAccess;
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
                VerifyReady();
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
                File.Copy("C:\\Users\\JWiley\\source\\CM\\CharacterManager4\\CM4_DataAccess\\DBV1\\WorldV1Template.db", storagePath, true);
            }
            catch
            {
                return false;
            }
            
            StoragePath = storagePath;
            return true;
        }

        public bool OpenDataStore(string storagePath) 
        {
            if (File.Exists(storagePath))
            {
                StoragePath = storagePath;
                return true;
            }
            return false;
        }


        void VerifyReady()
        {
            if (_connectionString == null)
                throw new Exception("Invalid Database Path");
        }

        internal bool IsReady()
        {
            return File.Exists(_DBPath);
        }
    }
}
