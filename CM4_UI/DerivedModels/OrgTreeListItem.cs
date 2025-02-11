using CM4_Core.Models;
using System;
using System.Collections.Generic;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI.DerivedModels
{
    public class OrgTreeListItem
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public EntityTypeEnum EntityType { get; set; }

        public List<OrgTreeListItem> Members { get; set; } = [];

        public OrgTreeListItem(Organization organization, List<Organization> organizations, List<Character> characters)
        {
            ID = organization.ID;
            Name = organization.Name;
            foreach (var orgMember in organizations)
            {
                if (organization.Child_Organizations.Contains(orgMember.ID))
                {
                    Members.Add(new OrgTreeListItem(orgMember, organizations, characters));
                }
            }
            foreach (var charMember in characters)
            {
                if (organization.Child_Characters.Contains(charMember.ID))
                {
                    Members.Add(new OrgTreeListItem(charMember));
                }
            }
            EntityType = EntityTypeEnum.Organization;
        }

        public OrgTreeListItem(Character character)
        {
            ID = character.ID;
            Name = character.Name;
            EntityType = EntityTypeEnum.Character;
        }
    }
}
