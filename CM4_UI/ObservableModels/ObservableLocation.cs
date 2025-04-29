using CM4_Core.Models;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;

namespace CM4_UI.ObservableModels
{
    public class ObservableLocation : ViewModelBase
    {
        private Location DataSource;

        public ObservableLocation(Location _source)
        {
            DataSource = _source;
        }

        public ObservableLocation()
        {
            DataSource = new Location();
        }

        public Location GetDataSource()
        {
            return DataSource;
        }

        public Guid ID
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

        public override string ToString()
        {
            return Name;
        }
    }
}
