﻿using Avalonia.Media;
using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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
            foreach (Location location in _da.Repository.Get<Location>())
            {
                _locationList.Add(new ObservableLocation(location));
            }
            foreach (Species species in _da.Repository.Get<Species>())
            {
                _speciesList.Add(new ObservableSpecies(species));
            }
            _notifyService.OnWorldDataViewModelUpdated(this);
        }
        private void WriteToDataAccess()
        {
            foreach (ObservableLocation observableLocation in LocationList)
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
            foreach (ObservableSpecies observableSpecies in SpeciesList)
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


        private ObservableCollection<ObservableLocation> _locationList = [];
        public ObservableCollection<ObservableLocation> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                if (value != null)
                {
                    _locationList = value;
                    this.RaisePropertyChanged(nameof(LocationList));
                }
            }
        }

        private ObservableCollection<ObservableSpecies> _speciesList = [];
        public ObservableCollection<ObservableSpecies> SpeciesList
        {
            get
            {
                return _speciesList;
            }
            set
            {
                if (value != null)
                {
                    _speciesList = value;
                    this.RaisePropertyChanged(nameof(SpeciesList));
                }
            }
        }

    }
}
