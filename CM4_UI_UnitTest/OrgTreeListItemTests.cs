using CM4_Core.Models;
using CM4_UI.DerivedModels;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI_UnitTest;

[TestClass]
public class OrgTreeListItemTests
{
    [TestMethod]
    public void OrgTreeListItem_FieldsMatchSourceCharacter()
    {
        Character character = new Character();
        character.Name = "Tim";

        OrgTreeListItem foo = new(character);

        Assert.AreEqual(foo.Name,character.Name);
        Assert.AreEqual(foo.ID, character.ID);
        Assert.AreEqual(foo.EntityType, EntityTypeEnum.Character);
    }

    [TestMethod]
    public void OrgTreeListItem_FieldsMatchSourceOrganization()
    {
        Organization organization = new Organization();
        organization.Name = "The Fellowship of the Ring";

        List<Organization> organizations = new List<Organization>();
        List<Character> characters = new List<Character>();

        OrgTreeListItem foo = new(organization, organizations, characters);

        Assert.AreEqual(foo.Name, organization.Name);
        Assert.AreEqual(foo.ID, organization.ID);
        Assert.AreEqual(foo.EntityType, EntityTypeEnum.Organization);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(20)]
    [DataRow(44)]
    [DataRow(100)]
    public void OrgTreeListItem_OrganizationListItemBuildsListOfChildOrgs(int numOrgs)
    {
        Organization parentOrg = new Organization();
        parentOrg.Name = "The Fellowship of the Ring";

        List<Organization> organizations = new List<Organization>();
        List<Character> characters = new List<Character>();
        List<Organization> childOrgs = new List<Organization>();

        organizations.Add(parentOrg);

        for (int i = 0; i < numOrgs; i++)
        {
            childOrgs.Add(new Organization());
        }
        foreach (Organization child in childOrgs)
        {
            parentOrg.Child_Organizations.Add(child.ID);
            child.Parent_Organizations.Add(parentOrg.ID);
            organizations.Add(child);
        }

        OrgTreeListItem foo = new(parentOrg, organizations, characters);

        bool result = false;
        foreach (Organization child in childOrgs)
        {
            result = false;
            foreach (OrgTreeListItem item in foo.Members)
            {
                if (item.ID == child.ID)
                {
                    result = true; break;
                }
            }
            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(20)]
    [DataRow(44)]
    [DataRow(100)]
    public void OrgTreeListItem_OrganizationListBuildsListOfChildCharactes(int numChars)
    {
        Organization parentOrg = new Organization();

        List<Organization> organizations = new List<Organization>();
        List<Character> characters = new List<Character>();
        List<Character> childChars = new List<Character>();

        organizations.Add(parentOrg);

        for (int i = 0; i < numChars; i++)
        {
            childChars.Add(new Character());
        }
        foreach (Character child in childChars)
        {
            parentOrg.Child_Characters.Add(child.ID);
            child.Parent_Organizations.Add(parentOrg.ID);
            characters.Add(child);
        }

        OrgTreeListItem foo = new(parentOrg, organizations, characters);

        bool result = false;
        foreach (Character child in childChars)
        {
            result = false;
            foreach (OrgTreeListItem item in foo.Members)
            {
                if (item.ID == child.ID)
                {
                    result = true; break;
                }
            }
            Assert.IsTrue(result);
        }
    }

    [TestMethod]
    [DataRow(2)]
    [DataRow(5)]
    [DataRow(44)]
    [DataRow(100)]
    public void OrgTreeListItem_FullOrgTreeIsBuilt(int depth)
    {
        Organization parentOrg = new Organization();

        List<Organization> organizations = new List<Organization>();
        List<Character> characters = new List<Character>();
        List<Organization> orgStack = new List<Organization>(depth);

        organizations.Add (parentOrg);
        orgStack.Add(parentOrg);

        for(int i = 1; i < depth; i++)
        {
            orgStack.Add(new Organization());
            organizations.Add (orgStack[i]);
            orgStack[i].Parent_Organizations.Add(orgStack[i-1].ID);
            orgStack[i - 1].Child_Organizations.Add(orgStack[i].ID);
        }

        OrgTreeListItem foo = new(parentOrg, organizations, characters);

        OrgTreeListItem parent;
        parent = foo;
        int index = 0;

        do
        {
            Assert.AreEqual(orgStack[index].ID, parent.ID);
            parent = parent.Members[0];
            index++;
        }while(index < depth-1);
    }

}
