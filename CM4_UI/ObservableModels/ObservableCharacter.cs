using CM4_Core.Models;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ObservableModels
{
    public class ObservableCharacter : ViewModelBase, IObservableOrgChar
    {
        private Character DataSource;
        private WorldDataViewModel WVM;
        public ObservableCharacter(Character _source, WorldDataViewModel _WVM)
        {
            DataSource = _source;
            WVM = _WVM;

            Parent_Organization_IDs = new ObservableCollection<Guid>(DataSource.Parent_Organizations);

        }

        public ObservableCharacter(WorldDataViewModel _WVM)
        {
            DataSource = new Character();
            Parent_Organization_IDs = new ObservableCollection<Guid>();
            WVM = _WVM;
        }

        public Character GetDataSource()
        {
            DataSource.Parent_Organizations = Parent_Organization_IDs.ToList();
            
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
        public string Description
        {
            get
            {
                return DataSource.Description;
            }
            set
            {
                DataSource.Description = value;
                this.RaisePropertyChanged(nameof(Description));
            }
        }
        public string Goals
        {
            get
            {
                return DataSource.Goals;
            }
            set
            {
                DataSource.Goals = value;
                this.RaisePropertyChanged(nameof(Goals));
            }
        }
        public int Age
        {
            get
            {
                return DataSource.Age;
            }
            set
            {
                DataSource.Age = value;
                this.RaisePropertyChanged(nameof(Age));
            }
        }

        public ObservableSpecies? Species
        {
            get
            {
                if (DataSource.Species == null)
                {
                    return null;
                }
                return WVM.GetSpeciesFromId((Guid)DataSource.Species);
            }
            set
            {
                if (value != null)
                {
                    DataSource.Species = value.Id;
                    this.RaisePropertyChanged(nameof(Species));
                }
            }
        }

        public ObservableLocation? Headquarters
        {
            get
            {
                if (DataSource.Location == null)
                {
                    return null;
                }
                return WVM.GetLocationFromID((Guid)DataSource.Location);
            }
            set
            {
                if (value != null)
                {
                    DataSource.Location = value.Id;
                    this.RaisePropertyChanged(nameof(Location));
                }
            }
        }




        private ObservableCollection<Guid> _parent_Organization_IDs;
        public ObservableCollection<Guid> Parent_Organization_IDs
        {
            get
            {
                return _parent_Organization_IDs;
            }
            set
            {
                if (value != null)
                {
                    _parent_Organization_IDs = value;
                    this.RaisePropertyChanged(nameof(Parent_Organization_IDs));
                }
            }
        }
        public ObservableCollection<IObservableOrgChar>? Children => null;
    }
}
