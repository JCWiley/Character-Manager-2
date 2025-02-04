
namespace CM4_Core.Models
{
    public class Organization : ModelBaseClass, IEquatable<Organization>
    {
        public Organization()
        {
            Name = "";
        }

        public bool Equals(Organization? other)
        {
            if (other == null)
            {
                return false;
            }
            return ((ModelBaseClass)this).Equals((ModelBaseClass)other);
        }

        public string Name { get; set; }
        public List<Guid> Child_Characters { get; set; } = [];
        public List<Guid> Child_Organizations { get; set;} = [];
        public List<Guid> Parent_Organizations { get; set; } = [];
    }
}
