using CM4_Core.LogicalGroupInterfaces;

namespace CM4_Core.LogicalGroups
{
    public class People : IPeople
    {
    //    Dictionary<CharacterGuid, ICharacter> _characters;
    //    Dictionary<OrganizationGuid, IOrganization> _organizations;
    //    Ledger<OrganizationGuid, CharacterGuid> _organizationCharacters;
    //    Ledger<OrganizationGuid, OrganizationGuid> _organizationSubOrganizations;

    //    public CharacterGuid? ActiveCharacter { get; set; }

    //    public People()
    //    {
    //        _characters = new Dictionary<CharacterGuid, ICharacter>();
    //        _organizations = new Dictionary<OrganizationGuid, IOrganization>();
    //        _organizationCharacters = new Ledger<OrganizationGuid, CharacterGuid>();
    //        _organizationSubOrganizations = new Ledger<OrganizationGuid, OrganizationGuid>();
    //    }

    //    public void AddCharacter(ICharacter character)
    //    {
    //        _characters.Add(character.ID, character);
    //    }

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
