using CM4_Core.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Interfaces
{
    public interface INotifyService
    {
        public event Notify NotifyDataSourceChanged;

        public void OnDataSourceChanged();
    }
}
