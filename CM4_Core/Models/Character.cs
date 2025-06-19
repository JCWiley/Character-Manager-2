namespace CM4_Core.Models
{
    public class Character : ModelBaseClass , IEquatable<Character>
    {

        public Character() 
        {
            Name = string.Empty;
            Description = string.Empty;
            Quirks = string.Empty;
            Occupation = string.Empty;
            Alias = string.Empty;
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
        public string Alias { get; set; }
        public string Description { get; set; }
        public string Quirks { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
        public Guid? Species { get; set; }
        public Guid? Location { get; set; }
        public Guid? Birthplace { get; set; }
        public List<Guid> Parent_Organizations { get; set; } = [];
        public List<Guid> Jobs { get; set; } = [];
        
    }
}
