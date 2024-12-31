
namespace CM4_Core.Models
{
    public class InventoryItem : ModelBaseClass
    {
        public InventoryItem()
        {
            Name = "";
            Description = "";
        }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
