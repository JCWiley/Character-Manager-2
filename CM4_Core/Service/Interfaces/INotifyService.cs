using CM4_Core.Service.Interfaces.EventDataPackages;


namespace CM4_Core.Service.Interfaces
{
    public interface INotifyService
    {
        public event EventHandler NotifyDataSourceChanged;
        public event EventHandler NotifyDataSourceAboutToChange;
        public event EventHandler NotifyPeopleViewModelUpdated;
        public event EventHandler NotifyLocationViewModelUpdated;
        public event EventHandler NotifyApplicationAboutToClose;
        //public event EventHandler<SelectedOrgCharEventArgs> NotifySelectedOrgCharChanged;

        public void OnDataSourceChanged(object sender);
        public void OnDataSourceAboutToChange(object sender);
        public void OnPeopleViewModelUpdated(object sender);
        public void OnWorldDataViewModelUpdated(object sender);
        public void OnApplicationAboutToClose(object sender);
        //public void OnSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args);
    }
}
