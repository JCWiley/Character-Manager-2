using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using ReactiveUI;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public TabViewModel(IDataAccess DA, INotifyService notifyService, OrganizationDetailViewModel organizationDetailViewModel, CharacterDetailViewModel characterDetailViewModel)
        {
            _da = DA;
            _notifyService = notifyService;
            _organizationDetailViewModel = organizationDetailViewModel;
            _characterDetailViewModel = characterDetailViewModel;
            _notifyService.NotifySelectedOrgCharChanged += HandleSelectedOrgCharChanged;
        }

        OrganizationDetailViewModel _organizationDetailViewModel;
        public OrganizationDetailViewModel OrganizationDetailViewModel
        {
            get => _organizationDetailViewModel;
            set => this.RaiseAndSetIfChanged(ref _organizationDetailViewModel, value);
        }

        CharacterDetailViewModel _characterDetailViewModel;
        public CharacterDetailViewModel CharacterDetailViewModel
        {
            get => _characterDetailViewModel;
            set => this.RaiseAndSetIfChanged(ref _characterDetailViewModel, value);
        }

        bool _isOrg = false;
        public bool IsOrg 
        {
            get => _isOrg;
            set => this.RaiseAndSetIfChanged(ref _isOrg, value);
        }

        private void HandleSelectedOrgCharChanged(object sender, SelectedOrgCharEventArgs args)
        {
            IsOrg = args.Type == EntityTypeEnum.Organization;
        }
    }
}
