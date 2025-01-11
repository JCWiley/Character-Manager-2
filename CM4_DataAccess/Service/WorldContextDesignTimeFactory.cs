using CM4_DataAccess.DBV1;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_DataAccess.Service
{
    public class WorldContextDesignTimeFactory : IDesignTimeDbContextFactory<WorldContext>
    {
        WorldContext IDesignTimeDbContextFactory<WorldContext>.CreateDbContext(string[] args)
        {
            string path = "C:\\Users\\JWiley\\source\\CM\\CharacterManager4\\CM4_DataAccess\\DBV1\\EFCore_Generated.db";

            string _connectionString = new SqliteConnectionStringBuilder()
            {
                Mode = SqliteOpenMode.ReadWrite,
                Cache = SqliteCacheMode.Shared,
                DataSource = path
            }.ToString();

            return new WorldContext(_connectionString);
        }
    }
}
