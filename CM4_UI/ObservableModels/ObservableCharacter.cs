using CM4_Core.MetaModels;
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
        private Guid TargetChar;
        private WorldDataViewModel WVM;
        private People People;
        public ObservableCharacter(Guid _targetChar, People _people, WorldDataViewModel _WVM)
        {
            TargetChar = _targetChar;
            WVM = _WVM;
            People = _people;
        }

        public Character GetDataSource()
        {
            return People.GetChar(TargetChar);
        }

        public Guid ID
        {
            get
            {
                return People.GetChar(TargetChar).ID;
            }
        }
        public string Name
        {
            get
            {
                return People.GetChar(TargetChar).Name;
            }
            set
            {
                People.GetChar(TargetChar).Name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }
        public string Alias
        {
            get
            {
                return People.GetChar(TargetChar).Alias;
            }
            set
            {
                People.GetChar(TargetChar).Alias = value;
                this.RaisePropertyChanged(nameof(Alias));
            }
        }
        public string Description
        {
            get
            {
                return People.GetChar(TargetChar).Description;
            }
            set
            {
                People.GetChar(TargetChar).Description = value;
                this.RaisePropertyChanged(nameof(Description));
            }
        }
        public string Quirks
        {
            get
            {
                return People.GetChar(TargetChar).Quirks;
            }
            set
            {
                People.GetChar(TargetChar).Quirks = value;
                this.RaisePropertyChanged(nameof(Quirks));
            }
        }

        public string Occupation
        {
            get
            {
                return People.GetChar(TargetChar).Occupation;
            }
            set
            {
                People.GetChar(TargetChar).Occupation = value;
                this.RaisePropertyChanged(nameof(Occupation));
            }
        }

        public int Age
        {
            get
            {
                return People.GetChar(TargetChar).Age;
            }
            set
            {
                People.GetChar(TargetChar).Age = value;
                this.RaisePropertyChanged(nameof(Age));
            }
        }

        public ObservableSpecies? Species
        {
            get
            {
                if (People.GetChar(TargetChar).Species == null)
                {
                    return null;
                }
                return WVM.GetSpeciesFromID((Guid)People.GetChar(TargetChar).Species);
            }
            set
            {
                if (value != null)
                {
                    People.GetChar(TargetChar).Species = value.ID;
                    this.RaisePropertyChanged(nameof(Species));
                }
            }
        }

        public ObservableLocation? Location
        {
            get
            {
                if (People.GetChar(TargetChar).Location == null)
                {
                    return null;
                }
                return WVM.GetLocationFromID((Guid)People.GetChar(TargetChar).Location);
            }
            set
            {
                if (value != null)
                {
                    People.GetChar(TargetChar).Location = value.ID;
                    this.RaisePropertyChanged(nameof(Location));
                }
            }
        }

        public ObservableLocation? Birthplace
        {
            get
            {
                if (People.GetChar(TargetChar).Birthplace == null)
                {
                    return null;
                }
                return WVM.GetLocationFromID((Guid)People.GetChar(TargetChar).Birthplace);
            }
            set
            {
                if (value != null)
                {
                    People.GetChar(TargetChar).Birthplace = value.ID;
                    this.RaisePropertyChanged(nameof(Birthplace));
                }
            }
        }

        public ObservableCollection<IObservableOrgChar>? Children => null;
    }
}
