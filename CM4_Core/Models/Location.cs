namespace CM4_Core.Models
{
    public class Location : ModelBaseClass, IEquatable<Location>
    {
        public Location()
        {
            Name = "";
        }
        public bool Equals(Location? other)
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
