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

            if(DataSource != null && DataSource.Parent_Organizations != null)
            {
                Parent_Organization_IDs = new ObservableCollection<Guid>(DataSource.Parent_Organizations);
            }
            else
            {
                Parent_Organization_IDs = new ObservableCollection<Guid>();
            }
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
        public string Alias
        {
            get
            {
                return DataSource.Alias;
            }
            set
            {
                DataSource.Alias = value;
                this.RaisePropertyChanged(nameof(Alias));
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
        public string Quirks
        {
            get
            {
                return DataSource.Quirks;
            }
            set
            {
                DataSource.Quirks = value;
                this.RaisePropertyChanged(nameof(Quirks));
            }
        }

        public string Occupation
        {
            get
            {
                return DataSource.Occupation;
            }
            set
            {
                DataSource.Occupation = value;
                this.RaisePropertyChanged(nameof(Occupation));
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
                return WVM.GetSpeciesFromID((Guid)DataSource.Species);
            }
            set
            {
                if (value != null)
                {
                    DataSource.Species = value.ID;
                    this.RaisePropertyChanged(nameof(Species));
                }
            }
        }

        public ObservableLocation? Location
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
                    DataSource.Location = value.ID;
                    this.RaisePropertyChanged(nameof(Location));
                }
            }
        }
        public ObservableLocation? Birthplace
        {
            get
            {
                if (DataSource.Birthplace == null)
                {
                    return null;
                }
                return WVM.GetLocationFromID((Guid)DataSource.Birthplace);
            }
            set
            {
                if (value != null)
                {
                    DataSource.Birthplace = value.ID;
                    this.RaisePropertyChanged(nameof(Birthplace));
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
