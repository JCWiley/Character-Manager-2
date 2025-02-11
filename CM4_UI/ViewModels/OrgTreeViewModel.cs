using CM4_Core.DataAccess;
using CM4_Core.LogicalGroupInterfaces;
using CM4_Core.LogicalGroups;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using CM4_UI.DerivedModels;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class OrgTreeViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public OrgTreeViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
            _notifyService.NotifyDataSourceChanged += HandleDataSourceChanged;
        }

        private OrgTreeListItem? _listItem;

        public OrgTreeListItem? SelectedItem 
        {
            get => _listItem;
            set
            {
                _listItem = value;
                if (value != null)
                {
                    _notifyService.OnSelectedOrgCharChanged(this,new SelectedOrgCharEventArgs(value.EntityType, value.ID));
                }
            }
        }

        private bool OrgTreeListHasChanged = false;
        private List<OrgTreeListItem> _orgTreeList;
        public List<OrgTreeListItem> OrgTreeList 
        { get
            {
                if(OrgTreeListHasChanged == true || _orgTreeList == null)
                {
                    OrgTreeListHasChanged = false;
                    _orgTreeList = BuildOrgItemTree();
                }
                return _orgTreeList;
            }
        }
        
        private List<Organization> _organizations;
        private bool OrganazationsHasChanged = true;
        private List<Organization> Organizations
        { get
            {
                if(OrganazationsHasChanged == true || _organizations == null)
                {
                    OrganazationsHasChanged = false;
                    _organizations = _da.Repository.Get<Organization>();
                }
                return _organizations;
            }
        }

        private List<Character> _characters;
        private bool CharactersHasChanged = true;
        private List<Character> Characters
        {
            get
            {
                if (CharactersHasChanged == true || _characters == null)
                {
                    CharactersHasChanged = false;
                    _characters = _da.Repository.Get<Character>();
                }
                return _characters;
            }
        }

        private void HandleDataSourceChanged(object? sender, EventArgs e)
        {
            NotifyOrgTreeListChanged(true, true);
        }

        public async Task AddNewCharacterToCurrentOrg()
        {
            Character character = await _da.Repository.Add<Character>();
            if (SelectedItem != null)
            {
                _da.Repository.AddRelationship(Organizations.FirstOrDefault(x => x.ID == SelectedItem?.ID, null), character);
                NotifyOrgTreeListChanged(true, true);
            }
        }
        public async Task AddExistingCharacterToCurrentOrg()
        {

        }

        public async Task AddNewOrgToCurrentOrg()
        {
            if (SelectedItem == null)
            {
                Organization organization = await _da.Repository.Add<Organization>();
                NotifyOrgTreeListChanged(true, false);
                return;
            }
            else
            {
                Organization organization = await _da.Repository.Add<Organization>();
                _da.Repository.AddRelationship(Organizations.FirstOrDefault(x => x.ID == SelectedItem?.ID,null), organization);
                NotifyOrgTreeListChanged(true,false);
            }
            
        }
        public async Task AddExistingOrgToCurrentOrg()
        {

        }

        private void NotifyOrgTreeListChanged(bool OrgsHaveChanged,bool CharsHaveChanged)
        {
            OrganazationsHasChanged = OrgsHaveChanged;
            CharactersHasChanged = CharsHaveChanged;
            OrgTreeListHasChanged = true;
            this.RaisePropertyChanged(nameof(OrgTreeList));
        }

        private List<OrgTreeListItem> BuildOrgItemTree()
        {
            List<OrgTreeListItem> result = new List<OrgTreeListItem>();
            foreach (Organization organization in Organizations)
            {
                if(organization.Parent_Organizations.Count == 0)
                {
                    result.Add(new OrgTreeListItem(organization, Organizations, Characters));
                }
            }
            return result;
        }
    }
}
