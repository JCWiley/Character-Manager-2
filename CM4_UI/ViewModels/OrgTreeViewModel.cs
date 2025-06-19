using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using CM4_UI.ObservableModels;
using DynamicData;
using DynamicData.Binding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CM4_UI.ViewModels
{
    public class OrgTreeViewModel : ViewModelBase
    {

        INotifyService _notifyService;

        public OrgTreeViewModel(PeopleViewModel _PVM, INotifyService notifyService)
        {
            PVM = _PVM;
            _notifyService = notifyService;
            _notifyService.NotifyPeopleUpdated += _notifyService_NotifyPeopleUpdated;
        }

        private void _notifyService_NotifyPeopleUpdated(object? sender, EventArgs e)
        {
            this.RaisePropertyChanged(nameof(PVM));
        }

        PeopleViewModel _pvm;
        public PeopleViewModel PVM
        {
            get
            {
                return _pvm;
            }
            set
            {
                if(value != null && _pvm != value)
                {
                    _pvm = value;
                    this.RaisePropertyChanged(nameof(PVM));
                }
            }
        }

        public async Task AddNewCharacter()
        {
            if(PVM.SelectedOrganization != null)
            {
                PVM.AddNewChildChar();
            }
            else
            {
                PVM.AddNewChar();
            }
        }

        public async Task AddNewOrg()
        {
            if (PVM.SelectedOrganization != null)
            {
                PVM.AddNewChildOrg();
            }
            else
            {
                PVM.AddNewOrg();
            }
        }
    }
}
