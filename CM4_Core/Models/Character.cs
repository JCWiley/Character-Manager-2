﻿
using static CM4_Core.Utilities.EnumCollection;

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
        public string Description { get; set; }
        public string Goals { get; set; }
        public int Age { get; set; }
        public Guid? Species { get; set; }
        public Guid? Location { get; set; }

        public List<Guid> Parent_Organizations { get; set; } = [];
        
    }
}
