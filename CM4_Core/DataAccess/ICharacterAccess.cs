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
        public List<Character> GetCharacters();
        public List<Character> GetCharacters(Guid[] ID);
        public void RemoveCharacter(Character character);
        public Character UpdateCharacter(Character character);
    }
}
