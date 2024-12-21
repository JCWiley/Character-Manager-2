using CM4_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.DataAccess
{
    public interface ICharacterAccess
    {
        public Task<Character> AddCharacter();
        public Task<Character> AddCharacter(Character C);
        public Task<List<Character>> GetCharacters();
        public Task<List<Character>> GetCharacters(Guid[] ID);
        public Task RemoveCharacter(Character C);
        public Task UpdateCharacter(Character C);
    }
}
