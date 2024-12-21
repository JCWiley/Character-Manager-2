using CM4_Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;
using CM4_Core.Models;
using CM4_DataAccess.Utilities;

namespace CM4_DataAccess.DBV1
{
    public class DataAccessV1 : IDataAccess
    {
        internal string _connectionString;
        string _DBPath;
        ICharacterAccess _ca;

        public DataAccessV1()
        {
            if(!SqlMapper.HasTypeHandler(typeof(Guid)))
            {
                SqlMapper.AddTypeHandler<Guid>(new GuidTypeHandler());
            }

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



        public bool CreateDB()
        {
            try
            {
                File.Copy("C:\\Users\\JWiley\\source\\CM\\CharacterManager4\\CM4_DataAccess\\DBV1\\WorldV1Template.db", StoragePath);
            }
            catch 
            {
                return false;
            }
            return true;
        }


        void VerifyReady()
        {
            if (_connectionString == null)
                throw new Exception("Invalid Database Path");
        }
    }
}
