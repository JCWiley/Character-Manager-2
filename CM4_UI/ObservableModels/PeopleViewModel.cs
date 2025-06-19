using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CM4_Core.DataAccess;
using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
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
        INotifyService _notifyService;
        WorldDataViewModel _WVM;
        People _source;
        public PeopleViewModel(People source, INotifyService notifyService, WorldDataViewModel WVM)
        {
            _notifyService = notifyService;
            _WVM = WVM;
            _source = source;

            _children = [];
            _selectedOrganization = null;
            _selectedCharacter = null;

            _notifyService.NotifyPeopleUpdated += People_CollectionChanged;
        }

        private void People_CollectionChanged(object? sender, PeopleUpdatedArgs args)
        {
            if (SelectedItemSource != null)
            {
                if (args.AllUpdated || args.UpdatedGuids.Contains(SelectedItemSource.ID))
                {
                    this.RaisePropertyChanged(nameof(SelectedItemSource));
                    this.RaisePropertyChanged(nameof(SelectedOrganization));
                    this.RaisePropertyChanged(nameof(SelectedCharacter));
                }
            }
            UpdateChildren();
            this.RaisePropertyChanged(nameof(Children));
        }

        public void AddNewOrg()
        {
            Guid NewOrg = _source.AddOrg();
            
            this.RaisePropertyChanged(nameof(Children));
        }
        public void AddNewChar()
        {
            Guid NewChar = _source.AddChar();
            this.RaisePropertyChanged(nameof(Children));
        }

        public void UpdateChildren()
        {
            _children.Clear();
            foreach (var org in _source.GetOrg())
            {
                if (org.Parent_Organizations.Count == 0)
                {
                    _children.Add(new ObservableOrganization(org.ID, _source, _WVM, _notifyService));
                }
            }
            foreach (var chr in _source.GetChar())
            {
                if (chr.Parent_Organizations.Count == 0)
                {
                    _children.Add(new ObservableCharacter(chr.ID, _source, _WVM));
                }
            }
        }

        public void AddNewChildOrg()
        {
            if (SelectedOrganization != null)
            {
                _source.AddChild(SelectedOrganization.GetDataSource(), _source.GetOrg(_source.AddOrg()));
            }
            else
            {
                _source.AddOrg();
            }
            this.RaisePropertyChanged(nameof(Children));
        }

        public void AddNewChildChar()
        {
            if (SelectedOrganization != null)
            {
                _source.AddChild(SelectedOrganization.GetDataSource(), _source.GetChar(_source.AddChar()));
            }
            this.RaisePropertyChanged(nameof(Children));
        }

        private ObservableCollection<IObservableOrgChar>? _children;
        public ObservableCollection<IObservableOrgChar>? Children
        {
            get
            {
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
                _notifyService.OnJobsUpdated(this);
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
                _notifyService.OnJobsUpdated(this);
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
