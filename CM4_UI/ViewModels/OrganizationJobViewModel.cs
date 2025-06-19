using CM4_Core.MetaModels;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_UI.ObservableModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace CM4_UI.ViewModels
{
    public class OrganizationJobViewModel : ViewModelBase
    {
        Jobs _source;
        INotifyService _notifyService;
        PeopleViewModel _PVM;
        public OrganizationJobViewModel(Jobs jobs, PeopleViewModel peopleViewModel, INotifyService notifyService)
        {
            _source = jobs;
            _notifyService = notifyService;
            _PVM = peopleViewModel;

            _jobs = [];
            _notifyService.NotifyJobsUpdated += JobsUpdated;

        }

        public void JobsUpdated(object? sender, EventArgs e)
        {
            _jobs.Clear();
            if(_PVM.SelectedItemSource != null)
            {
                foreach (Job job in _source.GetJobsForOrgChar(_PVM.SelectedItemSource.ID))
                {
                    _jobs.Add(new ObservableJob(job));
                }
            }
            this.RaisePropertyChanged(nameof(Jobs));
        }

        public void AddJob()
        {
            _source.AddJob(_PVM.SelectedItemSource.ID);
        }

        ObservableCollection<ObservableJob> _jobs;
        public ObservableCollection<ObservableJob> Jobs
        {
            get
            {
                return _jobs;
            }
        }

        ObservableJob? _selectedJob;
        public ObservableJob? SelectedJob
        {
            get
            {
                if (_selectedJob == null)
                {
                    if (Jobs.Count == 0)
                    {
                        return null;
                    }
                    else
                    {
                        _selectedJob = Jobs[0];
                    }
                }

                return _selectedJob;
            }
            set
            {
                if (_selectedJob != value)
                {
                    _selectedJob = value;
                    this.RaisePropertyChanged(nameof(SelectedJob));
                }
            }
        }
    }
}
