using CM4_Core.DataAccess;
using CM4_Core.Models;
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
        public async Task<Character?> AddCharacter()
        {
            Character temp = new Character();
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Character result = (await Context.AddAsync<Character>(temp)).Entity;
                    Context.SaveChanges();
                    return result;
                }
            }
            return null;
        }

        public async Task<Character?> AddCharacter(Character character)
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Character result = (await Context.AddAsync<Character>(character)).Entity;
                    Context.SaveChanges();
                    return result;
                }
            }
            return null;
        }

        public void RemoveCharacter(Character character)
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Context.Remove<Character>(character);
                    Context.SaveChanges();
                }
            }
        }


        public List<Character> GetCharacters()
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    return Context.Characters.ToList();
                }
            }
            return new List<Character>();
        }
        public List<Character> GetCharacters(Guid[] ID)
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    return Context.Characters.Where(item => ID.Contains(item.ID)).ToList();
                }
            }
            return new List<Character>();
        }


        public Character UpdateCharacter(Character character)
        {
            if (_DA.IsReady())
            {
                using (WorldContext Context = new WorldContext(_DA._connectionString))
                {
                    Character result = Context.Update<Character>(character).Entity;
                    Context.SaveChanges();
                    return result;
                }
            }
            return null;
        }
    }
}
