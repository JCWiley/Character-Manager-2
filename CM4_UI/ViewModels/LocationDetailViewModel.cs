using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class LocationDetailViewModel : ViewModelBase
    {
        public LocationDetailViewModel(WorldDataViewModel _wvm)
        {
            WVM = _wvm;
        }

        public async Task AddNewLocationAsync()
        {
            await WVM.AddNewLocation();
            this.RaisePropertyChanged(nameof(WVM.LocationDict));
        }

        WorldDataViewModel _wvm;
        public WorldDataViewModel WVM
        {
            get
            {
                return _wvm;
            }
            set
            {
                if (value != null && _wvm != value)
                {
                    _wvm = value;
                    this.RaisePropertyChanged(nameof(WVM));
                }
            }
        }


        private ObservableLocation _selectedLocation;
        public ObservableLocation SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                if (value != null)
                {
                    _selectedLocation = value;
                    this.RaisePropertyChanged(nameof(SelectedLocation));
                }
            }
        }
    }
}
