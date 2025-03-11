using CM4_Core.Models;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;

namespace CM4_UI.ObservableModels
{
    public class ObservableSpecies : ViewModelBase
    {
        private Species DataSource;

        public ObservableSpecies(Species _source)
        {
            DataSource = _source;
        }

        public ObservableSpecies()
        {
            DataSource = new Species();
        }

        public Species GetDataSource()
        {
            return DataSource;
        }

        public Guid Id
        {
            get
            {
                return DataSource.ID;
            }
        }

        public string Name
        {
            get
            {
                return DataSource.Name;
            }
            set
            {
                DataSource.Name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }
    }
}
