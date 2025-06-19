using Avalonia.Collections;
using Avalonia.Media;
using CM4_Core.DataAccess;
using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ViewModels;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CM4_UI.ObservableModels
{
    public class JobsDataViewModel : ViewModelBase
    {
        Jobs _source;
        INotifyService _notifyService;
        PeopleViewModel _PVM;

        public JobsDataViewModel(Jobs source, INotifyService notifyService, PeopleViewModel PVM)
        {
            _notifyService = notifyService;
            _source = source;
            _selectedItem = null;
            _PVM = PVM;
        }

        void UpdateJobs()
        {
            //_jobs.Clear();
            //List<Job> jobs = [];
            //if (_PVM.CharSelected)
            //{
            //    jobs = _source.GetJob(_PVM.SelectedCharacter.Job_IDs.ToList());
            //}
            //else if (_PVM.OrgSelected)
            //{
            //    jobs = _source.GetJob(_PVM.SelectedOrganization.Job_IDs.ToList());
            //}
            //foreach (Job job in jobs)
            //{
            //    _jobs.Add(new ObservableJob(job));
            //}

        }

        public void AddNewJob()
        {
            if (_PVM.CharSelected)
            {
                _source.AddJob(_PVM.SelectedCharacter.ID);
            }
            else if (_PVM.OrgSelected)
            {
                _source.AddJob(_PVM.SelectedOrganization.ID);
            }
            
        }

        ObservableCollection<ObservableJob> _jobs;
        public ObservableCollection<ObservableJob> Jobs
        {
            get
            {
                return _jobs;
            }
        }

        Guid? _selectedItem;
        public Guid? SelectedItem {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                this.RaisePropertyChanged(nameof(SelectedJob));
            }
        }

        public ObservableJob? SelectedJob
        {
            get
            {
                if(_selectedItem == null)
                {
                    return null;
                }
                else
                {
                    return new ObservableJob(_source.GetJob((Guid)_selectedItem));
                }
            }
        }
    }
}
