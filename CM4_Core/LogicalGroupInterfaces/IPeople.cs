
using CM4_Core.Models;

namespace CM4_Core.LogicalGroupInterfaces
{
    public interface IPeople
    {
        //    int ActiveCharacter { get; set; }

        void AddCharacter(Character character);
        //    ICharacter RetrieveCharacter(int characterGuid);

        //    void AddOrganization(Organization organization);
        //    IOrganization RetrieveOrganization(int organization);

        //    void AddMember(int parent, int child);
        //    void AddMember(int parent, int child);

        //    void RemoveMember(int parent, int child);
        //    void RemoveMember(int parent, int child);
        //    (HashSet<int> Characters, HashSet<int> Organizations) GetMembers(int parent);
    }
}
