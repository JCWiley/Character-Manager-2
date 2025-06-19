using CM4_Core.Service.Interfaces.EventDataPackages;


namespace CM4_Core.Service.Interfaces
{
    public interface INotifyService
    {
        public event EventHandler NotifyDataSourceChanged;
        public event EventHandler NotifyDataSourceAboutToChange;
        public event EventHandler<PeopleUpdatedArgs> NotifyPeopleUpdated;
        public event EventHandler NotifyLocationViewModelUpdated;
        public event EventHandler NotifyApplicationAboutToClose;
        public event EventHandler NotifyJobsUpdated;
        public event EventHandler<DateAdvancedArgs> NotifyDateAdvanced;
        //public event EventHandler<SelectedOrgCharEventArgs> NotifySelectedOrgCharChanged;

        public void OnDataSourceChanged(object sender);
        public void OnDataSourceAboutToChange(object sender);
        public void OnPeopleUpdated(object sender, PeopleUpdatedArgs args);
        public void OnWorldDataViewModelUpdated(object sender);
        public void OnApplicationAboutToClose(object sender);
        public void OnJobsUpdated(object sender);
        public void OnDateAdvanced(object sender, DateAdvancedArgs args);
        //public void OnSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args);
    }
}
