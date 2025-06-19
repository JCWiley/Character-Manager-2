
namespace CM4_Core.Models
{
    public class InventoryItem : ModelBaseClass, IEquatable<InventoryItem>
    {
        public InventoryItem()
        {
            Name = "New Item";
            Description = string.Empty;
        }

        public bool Equals(InventoryItem? other)
        {
            if (other == null)
            {
                return false;
            }
            return ((ModelBaseClass)this).Equals((ModelBaseClass)other);
        }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
