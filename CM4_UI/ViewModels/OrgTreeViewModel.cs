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
        PeopleViewModel _pvm;
        INotifyService _notifyService;

        public OrgTreeViewModel(PeopleViewModel peopleViewModel, INotifyService notifyService)
        {
            PVM = peopleViewModel;
            _notifyService = notifyService;
            _notifyService.NotifyPeopleViewModelUpdated += _notifyService_NotifyPeopleViewModelUpdated;
        }

        private void _notifyService_NotifyPeopleViewModelUpdated(object? sender, EventArgs e)
        {
            this.RaisePropertyChanged(nameof(PVM));
        }

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

        public async Task AddNewCharacterToCurrentOrg()
        {
            PVM.AddNewChildChar();
        }

        public async Task AddNewOrgToCurrentOrg()
        {
            PVM.AddNewChildOrg();
        }
    }
}
