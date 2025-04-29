
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_Core.Models
{
    public class Organization : ModelBaseClass, IEquatable<Organization>
    {
        public Organization()
        {
            Name = "";
            Description = "";
            Goals = "";
            Size = 0;
            Quirks = "";
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
        public string Description { get; set; }
        public string Goals { get; set; }
        public string Quirks { get; set; }
        public int Size { get; set; }
        public Guid? PrimarySpecies { get; set; }
        public Guid? Location { get; set; }
        public Guid? Leader { get; set; }

        public List<Guid> Child_Characters { get; set; } = [];
        public List<Guid> Child_Organizations { get; set;} = [];
        public List<Guid> Parent_Organizations { get; set; } = [];
    }
}
