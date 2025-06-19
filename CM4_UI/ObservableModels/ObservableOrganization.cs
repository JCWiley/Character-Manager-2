using Avalonia;
using Avalonia.Media;
using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using CM4_UI.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI.ObservableModels
{
    public class ObservableOrganization : ViewModelBase, IObservableOrgChar
    {
        private Guid TargetOrg;
        private People People;
        private WorldDataViewModel WVM;
        private INotifyService _notifyService;
        public ObservableOrganization(Guid _targetOrg, People _people, WorldDataViewModel _WVM, INotifyService notifyService)
        {
            TargetOrg = _targetOrg;

            WVM = _WVM;
            People = _people;
            _children = [];
            _notifyService = notifyService;

            _notifyService.NotifyPeopleUpdated += People_CollectionChanged;

            Children_Changed();
        }

        private void People_CollectionChanged(object? sender, PeopleUpdatedArgs args)
        {
            if(args.AllUpdated || args.UpdatedGuids.Contains(TargetOrg))
            {
                Children_Changed();
                this.RaisePropertyChanged("");
            }
        }

        public void Children_Changed()
        {
            _children.Clear();

            foreach (Guid org in People.GetOrg(TargetOrg).Child_Organizations)
            {
                _children.Add(new ObservableOrganization(org, People, WVM, _notifyService));
            }
            foreach (Guid cha in People.GetOrg(TargetOrg).Child_Characters)
            {
                _children.Add(new ObservableCharacter(cha, People, WVM));
            }

            this.RaisePropertyChanged(nameof(Children));
        }

        public Organization GetDataSource()
        {
            return People.GetOrg(TargetOrg);
        }

        public Guid ID
        {
            get
            {
                return People.GetOrg(TargetOrg).ID;
            }
        }
        public string Name
        {
            get
            {
                return People.GetOrg(TargetOrg).Name;
            }
            set
            {
                People.GetOrg(TargetOrg).Name = value;
                this.RaisePropertyChanged(nameof(Name));
            }
        }
        public string Description
        {
            get
            {
                return People.GetOrg(TargetOrg).Description;
            }
            set
            {
                People.GetOrg(TargetOrg).Description = value;
                this.RaisePropertyChanged(nameof(Description));
            }
        }
        public string Goals
        {
            get
            {
                return People.GetOrg(TargetOrg).Goals;
            }
            set
            {
                People.GetOrg(TargetOrg).Goals = value;
                this.RaisePropertyChanged(nameof(Goals));
            }
        }
        public string Quirks
        {
            get
            {
                return People.GetOrg(TargetOrg).Quirks;
            }
            set
            {
                People.GetOrg(TargetOrg).Quirks = value;
                this.RaisePropertyChanged(nameof(Quirks));
            }
        }
        public int Size
        {
            get
            {
                return People.GetOrg(TargetOrg).Size;
            }
            set
            {
                People.GetOrg(TargetOrg).Size = value;
                this.RaisePropertyChanged(nameof(Size));
            }
        }

        public ObservableSpecies? PrimarySpecies
        {
            get
            {
                if (People.GetOrg(TargetOrg).PrimarySpecies == null)
                {
                    return null;
                }
                return WVM.GetSpeciesFromID((Guid)People.GetOrg(TargetOrg).PrimarySpecies);
            }
            set
            {
                if (value != null)
                {
                    People.GetOrg(TargetOrg).PrimarySpecies = value.ID;
                    this.RaisePropertyChanged(nameof(PrimarySpecies));
                }
            }
        }

        public ObservableLocation? Headquarters
        {
            get
            {
                if (People.GetOrg(TargetOrg).Location == null)
                {
                    return null;
                }
                return WVM.GetLocationFromID((Guid)People.GetOrg(TargetOrg).Location);
            }
            set
            {
                if (value != null)
                {
                    People.GetOrg(TargetOrg).Location = value.ID;
                    this.RaisePropertyChanged(nameof(Headquarters));
                }
            }
        }

        public IObservableOrgChar? Leader
        {
            get
            {
                Guid? Leader = People.GetOrg(TargetOrg).Leader;
                if (Leader == null)
                {
                    return null;
                }
                return Children.First(x=> x.ID == Leader);
            }
            set
            {
                if (value != null)
                {
                    if (value is ObservableOrganization && People.GetOrg(TargetOrg).Child_Organizations.Contains(((ObservableOrganization)value).ID))
                    {
                        People.GetOrg(TargetOrg).Leader = ((ObservableOrganization)value).ID;
                    }
                    else if (value is ObservableCharacter && People.GetOrg(TargetOrg).Child_Characters.Contains(((ObservableCharacter)value).ID))
                    {
                        People.GetOrg(TargetOrg).Leader = ((ObservableCharacter)value).ID;
                    }
                    else
                    {
                        throw new InvalidOperationException("Cannot set Leader to a non-child Organization or Character");
                    }
                }
                this.RaisePropertyChanged(nameof(Leader));
            }
        }

        private ObservableCollection<IObservableOrgChar>? _children;
        public ObservableCollection<IObservableOrgChar>? Children
        {
            get
            {
                return _children;
            }
        }
    }
}
