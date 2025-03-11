using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using CM4_UI.ObservableModels;
using ReactiveUI;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public TabViewModel(IDataAccess DA, INotifyService notifyService, PeopleViewModel peopleViewModel, OrganizationDetailViewModel organizationDetailViewModel, CharacterDetailViewModel characterDetailViewModel)
        {
            _da = DA;
            _notifyService = notifyService;
            PVM = peopleViewModel;
            _organizationDetailViewModel = organizationDetailViewModel;
            _characterDetailViewModel = characterDetailViewModel;
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

        PeopleViewModel _pvm;
        public PeopleViewModel PVM
        {
            get
            {
                return _pvm;
            }
            set
            {
                if (value != null && _pvm != value)
                {
                    _pvm = value;
                    this.RaisePropertyChanged(nameof(PVM));
                }
            }
        }
    }
}
