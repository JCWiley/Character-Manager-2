using CM4_Core.DataAccess;
using CM4_Core.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_DataAccess.DBV1
{
    public class CharacterAccessV1 : ICharacterAccess
    {
        DataAccessV1 _DA;
        public CharacterAccessV1(DataAccessV1 DA)
        {
             _DA = DA;
        }
        public async Task<Character> AddCharacter()
        {
            Character temp = new Character();
            string sql = "INSERT INTO Characters (ID, Name, Age) VALUES (@ID, @Name, @Age) RETURNING *";
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                return await connection.QuerySingleAsync<Character>(sql, temp);
            }
        }

        public async Task<Character> AddCharacter(Character character)
        {
            string sql = "INSERT INTO Characters (ID, Name, Age) VALUES (@ID, @Name, @Age) RETURNING *";
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                return await connection.QuerySingleAsync<Character>(sql, character);
            }
        }

        public async Task RemoveCharacter(Character C)
        {
            string sql = "DELETE FROM Characters WHERE ID = @ID";
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                await connection.ExecuteAsync(sql, C);
            }

        }


        public async Task<List<Character>> GetCharacters()
        {

            string sql = "SELECT * FROM Characters";
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                var list = await connection.QueryAsync<Character>(sql);
                return list.ToList();
            }
        }
        public async Task<List<Character>> GetCharacters(Guid[] ID)
        {
            string sql = "SELECT * FROM Characters WHERE ID in @ID";
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                var list = await connection.QueryAsync<Character>(sql, new { ID });
                return list.ToList();
            }
        }


        public async Task UpdateCharacter(Character C)
        {
            using (IDbConnection connection = new SqliteConnection(_DA._connectionString))
            {
                await connection.UpdateAsync(C);
            }
        }
    }
}
