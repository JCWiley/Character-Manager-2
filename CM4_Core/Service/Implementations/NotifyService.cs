using CM4_Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Implementations
{
    public delegate void Notify();
    internal class NotifyService : INotifyService
    {
        public event Notify NotifyDataSourceChanged;

        public void OnDataSourceChanged()
        {
            NotifyDataSourceChanged?.Invoke();
        }
    }
}
