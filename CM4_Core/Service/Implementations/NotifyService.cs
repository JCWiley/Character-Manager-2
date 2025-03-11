using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;

namespace CM4_Core.Service.Implementations
{
    //public delegate void Notify();
    public delegate void NotifySelectedOrgChary<ISelectedOrgCharEventArgs>();
    internal class NotifyService : INotifyService
    {
        public event EventHandler NotifyDataSourceChanged;
        public event EventHandler NotifyDataSourceAboutToChange;
        public event EventHandler NotifyPeopleViewModelUpdated;
        public event EventHandler NotifyLocationViewModelUpdated;
        public event EventHandler NotifyApplicationAboutToClose;
        //public event EventHandler<SelectedOrgCharEventArgs> NotifySelectedOrgCharChanged;

        public void OnDataSourceChanged(object sender)
        {
            NotifyDataSourceChanged?.Invoke(sender, EventArgs.Empty);
        }
        public void OnDataSourceAboutToChange(object sender)
        {
            NotifyDataSourceAboutToChange?.Invoke(sender, EventArgs.Empty);
        }

        public void OnPeopleViewModelUpdated(object sender)
        {
            NotifyPeopleViewModelUpdated?.Invoke(sender, EventArgs.Empty);
        }

        public void OnWorldDataViewModelUpdated(object sender)
        {
            NotifyLocationViewModelUpdated?.Invoke(sender, EventArgs.Empty);
        }

        public void OnApplicationAboutToClose(object sender)
        {
            NotifyApplicationAboutToClose?.Invoke(sender, EventArgs.Empty);
        }
        //public void OnSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args)
        //{
        //    NotifySelectedOrgCharChanged?.Invoke(sender, args);
        //}
    }
}

