
using CM4_Core.Models;

namespace CM4_Core.LogicalGroupInterfaces
{
    public interface IPeople
    {
        //    int ActiveCharacter { get; set; }

        void AddCharacter(Character character);
        //    ICharacter RetrieveCharacter(int characterGuid);
        List<Character> GetCharacters();

        void AddOrganization(Organization organization);
        List<Organization> GetOrganizations();
        void Update<T>(T entity) where T : ModelBaseClass;
    }
}
