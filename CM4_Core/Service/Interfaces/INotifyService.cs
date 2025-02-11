using CM4_Core.Service.Interfaces.EventDataPackages;


namespace CM4_Core.Service.Interfaces
{
    public interface INotifyService
    {
        public event EventHandler NotifyDataSourceChanged;
        public event EventHandler<SelectedOrgCharEventArgs> NotifySelectedOrgCharChanged;

        public void OnDataSourceChanged(object sender);
        public void OnSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args);
    }
}
