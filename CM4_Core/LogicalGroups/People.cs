using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.Models;

namespace CM4_Core.LogicalGroups
{
    public class People(IDataAccess DA) : IPeople
    {
        public void AddCharacter(Character character)
        {
            DA.Repository.Add(character);
        }

        public List<Character> GetCharacters()
        {
            return DA.Repository.Get<Character>();
        }

        //    public ICharacter RetrieveCharacter(CharacterGuid characterGuid)
        //    {
        //        return _characters[characterGuid];
        //    }

        public void AddOrganization(Organization organization)
        {
            DA.Repository.Add(organization);
        }
        public List<Organization> GetOrganizations()
        {
            return DA.Repository.Get<Organization>();
        }
        public void RemoveOrganization(Organization organization)
        {
            DA.Repository.Remove(organization);
        }


        public void Update<T>(T entity) where T : ModelBaseClass
        {
            DA.Repository.Update(entity);
        }

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
