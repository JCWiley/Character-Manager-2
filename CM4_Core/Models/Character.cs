
namespace CM4_Core.Models
{
    public class Character : ModelBaseClass
    {

        public Character() 
        {
            Name = "";
            Age = -1;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
