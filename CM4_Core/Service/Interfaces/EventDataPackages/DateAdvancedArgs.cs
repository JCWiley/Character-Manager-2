using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Interfaces.EventDataPackages
{
    public class DateAdvancedArgs : EventArgs
    {
        public DateAdvancedArgs(int days)
        {
            Days = days;
        }

        public int Days { get; }
    }
}
