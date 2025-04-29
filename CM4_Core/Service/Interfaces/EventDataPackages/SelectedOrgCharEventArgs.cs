using static CM4_Core.Utilities.EnumCollection;

namespace CM4_Core.Service.Interfaces.EventDataPackages
{
    public class SelectedOrgCharEventArgs : EventArgs
    {
        public SelectedOrgCharEventArgs(EntityTypeEnum _type, Guid _id)
        {
            Type = _type;
            ID = _id;
        }
        public EntityTypeEnum Type { get;}
        public Guid ID { get;}
    }
}
