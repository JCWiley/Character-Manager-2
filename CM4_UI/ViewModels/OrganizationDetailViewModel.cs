﻿using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using CM4_UI.ObservableModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using static CM4_Core.Utilities.EnumCollection;

namespace CM4_UI.ViewModels
{
    public class OrganizationDetailViewModel : ViewModelBase
    {
        INotifyService _notifyService;

        public OrganizationDetailViewModel(PeopleViewModel peopleViewModel,WorldDataViewModel worldDataViewModel, INotifyService notifyService)
        {
            _notifyService = notifyService;
            PVM = peopleViewModel;
            WVM = worldDataViewModel;
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
                if (value != null && _pvm != value)
                {
                    _pvm = value;
                    this.RaisePropertyChanged(nameof(PVM));
                }
            }
        }

        WorldDataViewModel _wvm;
        public WorldDataViewModel WVM
        {
            get
            {
                return _wvm;
            }
            set
            {
                if (value != null && _wvm != value)
                {
                    _wvm = value;
                    this.RaisePropertyChanged(nameof(WVM));
                }
            }
        }
    }
}
