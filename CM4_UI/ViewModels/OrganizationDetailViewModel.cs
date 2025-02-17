using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ViewModels
{
    public class OrganizationDetailViewModel : ViewModelBase
    {
        IDataAccess _da;
        INotifyService _notifyService;

        public OrganizationDetailViewModel(IDataAccess DA, INotifyService notifyService)
        {
            _da = DA;
            _notifyService = notifyService;
            _notifyService.NotifyDataSourceChanged += _notifyService_NotifyDataSourceChanged;
            _notifyService.NotifySelectedOrgCharChanged += _notifyService_NotifySelectedOrgCharChanged;
        }

        private void _notifyService_NotifySelectedOrgCharChanged(object? sender, CM4_Core.Service.Interfaces.EventDataPackages.SelectedOrgCharEventArgs e)
        {
            if(e.Type == CM4_Core.Utilities.EnumCollection.EntityTypeEnum.Organization)
            {
                SelectedOrganization = _da.Repository.Get<Organization>(e.Id);
            }
        }

        private void _notifyService_NotifyDataSourceChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        Organization? _selectedOrganization;
        public Organization? SelectedOrganization
        {
            get {  return _selectedOrganization; }
            set
            {
                if (_selectedOrganization != value)
                {
                    _da.Repository.Update<Organization>(value);
                    this.RaiseAndSetIfChanged(ref _selectedOrganization, value);
                }
            }
        }

        public void OrganizationDetailViewModel_LostFocus()
        {

        }
    }
}
