using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Models
{
    public class ModelBaseClass : IEquatable<ModelBaseClass>
    {
        public Guid ID { get; set; }
        public ModelBaseClass()
        {
            ID = Guid.NewGuid();
        }
        public bool Equals(ModelBaseClass? other)
        {
            if (other == null) return false;
            return other.ID == ID;
        }
    }
}
