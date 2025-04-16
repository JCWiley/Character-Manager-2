using Avalonia.Collections;
using Avalonia.Media;
using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ViewModels;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CM4_UI.ObservableModels
{
    public class WorldDataViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public WorldDataViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
            _notifyService.NotifyDataSourceChanged += _notifyService_NotifyDataSourceChanged;
            _notifyService.NotifyDataSourceAboutToChange += _notifyService_NotifyDataSourceAboutToChange;
            _notifyService.NotifyApplicationAboutToClose += _notifyService_NotifyApplicationAboutToClose;
        }

        private void _notifyService_NotifyApplicationAboutToClose(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }

        private void _notifyService_NotifyDataSourceChanged(object? sender, EventArgs e)
        {
            ReadFromDataAccess();
        }

        private void _notifyService_NotifyDataSourceAboutToChange(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }

        private void ReadFromDataAccess()
        {
            LocationDict.Clear();
            SpeciesDict.Clear();
            foreach (Location location in _da.Repository.Get<Location>())
            {
                _locationDict.Add(location.ID, new ObservableLocation(location));
            }
            foreach (Species species in _da.Repository.Get<Species>())
            {
                _speciesDict.Add(species.ID, new ObservableSpecies(species));
            }
            _notifyService.OnWorldDataViewModelUpdated(this);
        }
        private void WriteToDataAccess()
        {
            foreach (ObservableLocation observableLocation in LocationDict.Values)
            {
                if (_da.Repository.Get<Location>().Contains(observableLocation.GetDataSource()))
                {
                    _da.Repository.Update(observableLocation.GetDataSource());
                }
                else
                {
                    _da.Repository.Add(observableLocation.GetDataSource());
                }
            }
            foreach (ObservableSpecies observableSpecies in SpeciesDict.Values)
            {
                if (_da.Repository.Get<Species>().Contains(observableSpecies.GetDataSource()))
                {
                    _da.Repository.Update(observableSpecies.GetDataSource());
                }
                else
                {
                    _da.Repository.Add(observableSpecies.GetDataSource());
                }
            }
        }

        public async Task AddNewLocation()
        {
            ObservableLocation newLocation = new ObservableLocation();
            LocationDict.Add(newLocation.Id, newLocation);
            this.RaisePropertyChanged(nameof(LocationDict));
        }

        public async Task AddNewSpecies()
        {
            ObservableSpecies newSpecies = new ObservableSpecies();
            SpeciesDict.Add(newSpecies.Id, newSpecies);
            this.RaisePropertyChanged(nameof(SpeciesDict));
        }

        private AvaloniaDictionary<Guid, ObservableLocation> _locationDict = [];
        public AvaloniaDictionary<Guid, ObservableLocation> LocationDict
        {
            get
            {
                return _locationDict;
            }
            set
            {
                if (value != null)
                {
                    _locationDict = value;
                    this.RaisePropertyChanged(nameof(LocationDict));
                    this.RaisePropertyChanged(nameof(LocationList));
                }
            }
        }

        public ICollection<ObservableLocation> LocationList
        {
            get
            {
                return LocationDict.Values;
            }
        }

        private AvaloniaDictionary<Guid, ObservableSpecies> _speciesDict = [];
        public AvaloniaDictionary<Guid,ObservableSpecies> SpeciesDict
        {
            get
            {
                return _speciesDict;
            }
            set
            {
                if (value != null)
                {
                    _speciesDict = value;
                    this.RaisePropertyChanged(nameof(SpeciesDict));
                    this.RaisePropertyChanged(nameof(SpeciesList));
                }
            }
        }
        public ICollection<ObservableSpecies> SpeciesList
        {
            get
            {
                return SpeciesDict.Values;
            }
        }

    }
}
