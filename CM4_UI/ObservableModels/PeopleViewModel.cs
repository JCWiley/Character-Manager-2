using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CM4_UI.ObservableModels
{
    public class PeopleViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public PeopleViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
            OrganizationList = [];
            CharacterList = [];
            _children = [];
            _selectedOrganization = null;
            _selectedCharacter = null;

            _notifyService.NotifyDataSourceChanged += _notifyService_NotifyDataSourceChanged;
            _notifyService.NotifyDataSourceAboutToChange += _notifyService_NotifyDataSourceAboutToChange;
            _notifyService.NotifyApplicationAboutToClose += _notifyService_NotifyApplicationAboutToClose;

            OrganizationList.CollectionChanged += OrganizationList_CollectionChanged;
            CharacterList.CollectionChanged += CharacterList_CollectionChanged;
        }

        private void _notifyService_NotifyApplicationAboutToClose(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }

        private void CharacterList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Children));
        }

        private void OrganizationList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.RaisePropertyChanged(nameof(Children));
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
            foreach (Organization organization in _da.Repository.Get<Organization>())
            {
                OrganizationList.Add(new ObservableOrganization(this, organization));
            }
            foreach (Character character in _da.Repository.Get<Character>())
            {
                CharacterList.Add(new ObservableCharacter(character));
            }
            _notifyService.OnPeopleViewModelUpdated(this);
        }

        private void WriteToDataAccess()
        {
            foreach (ObservableOrganization observableOrganization in OrganizationList)
            {
                if (_da.Repository.Get<Organization>().Contains(observableOrganization.GetDataSource()))
                {
                    _da.Repository.Update(observableOrganization.GetDataSource());
                }
                else
                {
                    _da.Repository.Add(observableOrganization.GetDataSource());
                }
            }
            foreach (ObservableCharacter observableCharacter in CharacterList)
            {
                if (_da.Repository.Get<Character>().Contains(observableCharacter.GetDataSource()))
                {
                    _da.Repository.Update(observableCharacter.GetDataSource());
                }
                else
                {
                    _da.Repository.Add(observableCharacter.GetDataSource());
                }
            }
        }

        public void AddChild(ObservableOrganization Parent, ObservableOrganization Child)
        {
            if (!OrganizationList.Contains(Parent))
            {
                OrganizationList.Add(Parent);
            }
            if(!OrganizationList.Contains(Child))
            {
                OrganizationList.Add(Child);
            }

            OrganizationList.First(org => org.Id == Parent.Id).Child_Organization_IDs.Add(Child.Id);
            OrganizationList.First(org => org.Id == Child.Id).Parent_Organization_IDs.Add(Parent.Id);
            this.RaisePropertyChanged(nameof(Children));
        }
        public void AddChild(ObservableOrganization Parent, ObservableCharacter Child)
        {
            if (!OrganizationList.Contains(Parent))
            {
                OrganizationList.Add(Parent);
            }
            if (!CharacterList.Contains(Child))
            {
                CharacterList.Add(Child);
            }

            OrganizationList.First(org => org.Id == Parent.Id).Child_Character_IDs.Add(Child.Id);
            CharacterList.First(org => org.Id == Child.Id).Parent_Organization_IDs.Add(Parent.Id);
            this.RaisePropertyChanged(nameof(Children));
        }

        public void AddNewChildOrg()
        {
            if (SelectedOrganization != null)
            {
                AddChild(SelectedOrganization, new ObservableOrganization(this));
            }
        }

        public void AddNewChildChar()
        {
            if (SelectedOrganization != null)
            {
                AddChild(SelectedOrganization, new ObservableCharacter());
            }
        }


        private ObservableCollection<ObservableOrganization> _organizationList;
        public ObservableCollection<ObservableOrganization> OrganizationList
        {
            get
            {
                return _organizationList;
            }
            set
            {
                if (value != null)
                {
                    _organizationList = value;
                    this.RaisePropertyChanged(nameof(OrganizationList));
                    this.RaisePropertyChanged(nameof(Children));
                }
            }
        }

        private ObservableCollection<ObservableCharacter> _characterList;
        public ObservableCollection<ObservableCharacter> CharacterList
        {
            get
            {
                return _characterList;
            }
            set
            {
                if (value != null)
                {
                    _characterList = value;
                    this.RaisePropertyChanged(nameof(CharacterList));
                    this.RaisePropertyChanged(nameof(Children));
                }
            }
        }
        private ObservableCollection<IObservableOrgChar>? _children;
        public ObservableCollection<IObservableOrgChar>? Children
        {
            get
            {
                _children.Clear();
                foreach (var org in OrganizationList)
                {
                    if(org.Parent_Organization_IDs.Count == 0)
                    {
                        _children.Add(org);
                    }
                }
                foreach (var chr in CharacterList)
                {
                    if (chr.Parent_Organization_IDs.Count == 0)
                    {
                        _children.Add(chr);
                    }
                }
                return _children;
            }
        }

        private ObservableOrganization? _selectedOrganization;
        public ObservableOrganization? SelectedOrganization
        {
            get
            {
                return _selectedOrganization;
            }
            set
            {
                _selectedOrganization = value;
                this.RaisePropertyChanged(nameof(SelectedOrganization));
                this.RaisePropertyChanged(nameof(OrgSelected));
            }
        }

        private ObservableCharacter? _selectedCharacter;
        public ObservableCharacter? SelectedCharacter
        {
            get
            {
                return _selectedCharacter;
            }
            set
            {
                _selectedCharacter = value;
                this.RaisePropertyChanged(nameof(SelectedCharacter));
                this.RaisePropertyChanged(nameof(CharSelected));
            }
        }

        public bool OrgSelected
        {
            get
            {
                return SelectedOrganization != null;
            }
        }
        public bool CharSelected
        {
            get
            {
                return SelectedCharacter != null;
            }
        }
        public IObservableOrgChar? SelectedItemSource
        {
            get
            {
                if(SelectedCharacter != null)
                {
                    return SelectedCharacter;
                }
                if(SelectedOrganization != null)
                {
                    return SelectedOrganization;
                }
                return null;
            }
            set
            {
                if(value != null)
                {
                    if(value is ObservableOrganization)
                    {
                        SelectedOrganization = (ObservableOrganization)value;
                        SelectedCharacter = null;
                    }
                    else if(value is ObservableCharacter)
                    {
                        SelectedCharacter = (ObservableCharacter)value;
                        SelectedOrganization = null;
                    }
                }
                else
                {
                    SelectedCharacter = null;
                    SelectedOrganization = null;
                }
            }
        }
    }
}
