namespace CM4_Core.Models
{
    public class Species : ModelBaseClass, IEquatable<Species>
    {
        public Species()
        {
            Name = "New Species";
        }
        public bool Equals(Species? other)
        {
            if (other == null)
            {
                return false;
            }
            return ((ModelBaseClass)this).Equals((ModelBaseClass)other);
        }
        public string Name { get; set; }
    }
}
