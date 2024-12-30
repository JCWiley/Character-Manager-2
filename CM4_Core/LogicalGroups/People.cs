using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;

namespace CM4_Core.LogicalGroups
{
    public class People : IPeople
    {
        private IDataAccess _DA;

        //    public CharacterGuid? ActiveCharacter { get; set; }

        public People(IDataAccess DA)
        {
            _DA = DA;
        }

        public void AddCharacter(Character character)
        {
            _DA.CA.AddCharacter(character);
        }

        public List<Character> GetCharacters()
        {
            return _DA.CA.GetCharacters();
        }

        //    public ICharacter RetrieveCharacter(CharacterGuid characterGuid)
        //    {
        //        return _characters[characterGuid];
        //    }

        //    public void AddOrganization(IOrganization organization)
        //    {
        //        _organizations.Add(organization.ID, organization);
        //    }
        //    public IOrganization RetrieveOrganization(OrganizationGuid organization)
        //    {
        //        return _organizations[organization];
        //    }

        //    public void AddMember(OrganizationGuid parent, CharacterGuid child)
        //    {
        //        _organizationCharacters.Add(parent, child);
        //    }
        //    public void AddMember(OrganizationGuid parent, OrganizationGuid child)
        //    {
        //        _organizationSubOrganizations.Add(parent, child);
        //    }

        //    public void RemoveMember(OrganizationGuid parent, CharacterGuid child)
        //    {
        //        _organizationCharacters.Remove(parent, child);
        //    }
        //    public void RemoveMember(OrganizationGuid parent, OrganizationGuid child)
        //    {
        //        _organizationSubOrganizations.Remove(parent, child);
        //    }

        //    public (HashSet<CharacterGuid> Characters, HashSet<OrganizationGuid> Organizations) GetMembers(OrganizationGuid parent)
        //    {
        //        return (_organizationCharacters.GetChildren(parent), _organizationSubOrganizations.GetChildren(parent));
        //    }
    }
}
