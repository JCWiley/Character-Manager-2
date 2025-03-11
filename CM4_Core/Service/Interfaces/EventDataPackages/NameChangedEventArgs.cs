using static CM4_Core.Utilities.EnumCollection;

namespace CM4_Core.Service.Interfaces.EventDataPackages
{
    public class NameChangedEventArgs : EventArgs
    {
        public NameChangedEventArgs(EntityTypeEnum _type, Guid _id, string _name)
        {
            Type = _type;
            Id = _id;
            Name = _name;
        }
        public EntityTypeEnum Type { get;}
        public Guid Id { get;}
        public string Name { get;}
    }
}
