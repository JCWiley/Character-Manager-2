using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;

namespace CM4_Core.Service.Implementations
{
    //public delegate void Notify();
    public delegate void NotifySelectedOrgChary<ISelectedOrgCharEventArgs>();
    internal class NotifyService : INotifyService
    {
        public event EventHandler NotifyDataSourceChanged;
        public event EventHandler<SelectedOrgCharEventArgs> NotifySelectedOrgCharChanged;

        public void OnDataSourceChanged(object sender)
        {
            NotifyDataSourceChanged?.Invoke(sender, EventArgs.Empty);
        }

        public void OnSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args)
        {
            NotifySelectedOrgCharChanged?.Invoke(sender, args);
        }
    }
}

