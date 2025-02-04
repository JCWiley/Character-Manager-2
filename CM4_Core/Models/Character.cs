
namespace CM4_Core.Models
{
    public class Character : ModelBaseClass , IEquatable<Character>
    {

        public Character() 
        {
            Name = "";
            Age = -1;
        }

        public bool Equals(Character? other)
        {
            if (other == null)
            {
                return false;
            } 
            return ((ModelBaseClass)this).Equals((ModelBaseClass)other);
        }

        public string Name { get; set; }
        public List<Guid> Parent_Organizations { get; set; } = [];
        public int Age { get; set; }
        
    }
}
