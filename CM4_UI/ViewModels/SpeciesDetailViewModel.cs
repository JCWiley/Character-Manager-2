using CM4_Core.DataAccess;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class SpeciesDetailViewModel : ViewModelBase
    {
        public SpeciesDetailViewModel(WorldDataViewModel _wvm)
        {
            WVM = _wvm;
        }

        public async Task AddNewSpeciesAsync()
        {
            await WVM.AddNewSpecies();
            this.RaisePropertyChanged(nameof(WVM.SpeciesDict));
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

        private ObservableSpecies _selectedSpecies;
        public ObservableSpecies SelectedSpecies
        {
            get
            {
                return _selectedSpecies;
            }
            set
            {
                if (value != null)
                {
                    _selectedSpecies = value;
                    this.RaisePropertyChanged(nameof(SelectedSpecies));
                }
            }
        }
    }
}