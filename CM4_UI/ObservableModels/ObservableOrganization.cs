using Avalonia;
using Avalonia.Media;
using CM4_Core.Models;
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
        private Organization DataSource;
        private PeopleViewModel Model;
        public ObservableOrganization(PeopleViewModel _parent, Organization _source)
        {
            DataSource = _source;

            Child_Organization_IDs = new ObservableCollection<Guid>(DataSource.Child_Organizations);
            Parent_Organization_IDs = new ObservableCollection<Guid>(DataSource.Parent_Organizations);
            Child_Character_IDs = new ObservableCollection<Guid>(DataSource.Child_Characters);

            Init(_parent);
        }
        public ObservableOrganization(PeopleViewModel _parent)
        {
            DataSource = new Organization();

            Child_Organization_IDs = new ObservableCollection<Guid>();
            Parent_Organization_IDs = new ObservableCollection<Guid>();
            Child_Character_IDs = new ObservableCollection<Guid>();

            Init(_parent);
        }

        private void Init(PeopleViewModel _parent)
        {
            Model = _parent;
            _children = [];
            Child_Organization_IDs.CollectionChanged += Child_Organization_IDs_CollectionChanged;
            Child_Character_IDs.CollectionChanged += Child_Character_IDs_CollectionChanged;
        }

        private void Child_Character_IDs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Child_Characters));
            this.RaisePropertyChanged(nameof(Children));
        }

        private void Child_Organization_IDs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Child_Organizations));
            this.RaisePropertyChanged(nameof(Children));
        }

        public Organization GetDataSource()
        {
            DataSource.Child_Organizations = Child_Organization_IDs.ToList();
            DataSource.Parent_Organizations = Parent_Organization_IDs.ToList();
            DataSource.Child_Characters = Child_Character_IDs.ToList();
            
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
        public OrgSizeEnum Size
        {
            get
            {
                return DataSource.Size;
            }
            set
            {
                DataSource.Size = value;
                this.RaisePropertyChanged(nameof(Size));
            }
        }
        public Species? PrimarySpecies
        {
            get
            {
                return DataSource.PrimarySpecies;
            }
            set
            {
                if (value != null)
                {
                    DataSource.PrimarySpecies = value;
                    this.RaisePropertyChanged(nameof(PrimarySpecies));
                }
            }
        }
        public Location? Headquarters
        {
            get
            {
                return DataSource.Location;
            }
            set
            {
                if (value != null)
                {
                    DataSource.Location = value;
                    this.RaisePropertyChanged(nameof(Location));
                }
            }
        }

        private ObservableCollection<Guid> _child_Organization_IDs;
        public ObservableCollection<Guid> Child_Organization_IDs
        {
            get
            {
                return _child_Organization_IDs;//
            }
            set
            {
                if (value != null)
                {
                    _child_Organization_IDs = value;
                    this.RaisePropertyChanged(nameof(Child_Organization_IDs));
                    this.RaisePropertyChanged(nameof(Child_Organizations));
                    this.RaisePropertyChanged(nameof(Children));
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


        private ObservableCollection<Guid> _child_Character_IDs;
        public ObservableCollection<Guid> Child_Character_IDs
        {
            get
            {
                return _child_Character_IDs;
            }
            set
            {
                if (value != null)
                {
                    _child_Character_IDs = value;
                    this.RaisePropertyChanged(nameof(Child_Character_IDs));
                    this.RaisePropertyChanged(nameof(Child_Characters));
                    this.RaisePropertyChanged(nameof(Children));
                }
            }
        }


        //https://www.nequalsonelifestyle.com/2019/06/18/avalonia-treeview-tutorial/
        public List<ObservableOrganization> Child_Organizations
        {
            get
            {
                return Model.OrganizationList.Where(org => Child_Organization_IDs.Contains(org.Id)).ToList();
            }
        }
        public List<ObservableCharacter> Child_Characters
        {
            get
            {
                return Model.CharacterList.Where(chr => Child_Character_IDs.Contains(chr.Id)).ToList();
            }
        }

        private ObservableCollection<IObservableOrgChar>? _children;
        public ObservableCollection<IObservableOrgChar>? Children
        {
            get
            {
                _children.Clear();
                foreach (var org in Child_Organizations)
                {
                    _children.Add(org);
                }
                foreach (var chr in Child_Characters)
                {
                    _children.Add(chr);
                }
                return _children;
            }
        }
    }
}
