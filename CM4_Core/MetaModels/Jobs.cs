using CM4_Core.DataAccess;
using CM4_Core.Models;
using CM4_Core.Service.Interfaces;
using CM4_Core.Service.Interfaces.EventDataPackages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.MetaModels
{
    public class Jobs
    {
        IDataAccess _da;
        INotifyService _notifyService;
        Dictionary<Guid, Job> _jobsDict;
        People People;
        public Jobs(People people, IDataAccess DA, INotifyService notifyService) // DateManager
        {
            _da = DA;
            _notifyService = notifyService;
            People = people;

            _jobsDict = [];

            _notifyService.NotifyDataSourceChanged += _notifyService_NotifyDataSourceChanged;
            _notifyService.NotifyDataSourceAboutToChange += _notifyService_NotifyDataSourceAboutToChange;
            _notifyService.NotifyApplicationAboutToClose += _notifyService_NotifyApplicationAboutToClose;
            _notifyService.NotifyDateAdvanced += _notifyService_NotifyDateAdvanced;
        }

        private void _notifyService_NotifyApplicationAboutToClose(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }
        private void _notifyService_NotifyDataSourceChanged(object? sender, EventArgs e)
        {
            ReadFromDataAccess();
        }
        private void _notifyService_NotifyDataSourceAboutToChange(object? sender, EventArgs e)
        {
            WriteToDataAccess();
        }
        private void _notifyService_NotifyDateAdvanced(object? sender, DateAdvancedArgs e)
        {
           // _notifyService.OnJobsUpdated(this);
        }


        private void ReadFromDataAccess()
        {
            foreach (Job job in _da.Repository.Get<Job>())
            {
                _jobsDict[job.ID] = job;
            }
            _notifyService.OnJobsUpdated(this);
        }

        private void WriteToDataAccess()
        {
            foreach (Job job in _jobsDict.Values)
            {
                if (_da.Repository.Get<Job>().Contains(job))
                {
                    _da.Repository.Update(job);
                }
                else
                {
                    _da.Repository.Add(job);
                }
            }
        }

        public Guid AddJob(Guid OwnerID)
        {
            Job newJob = new Job(0);
            People.AddJob(OwnerID, newJob.ID);
            _jobsDict[newJob.ID] = newJob;
            _notifyService.OnJobsUpdated(this);
            return newJob.ID;
        }

        public Job GetJob(Guid jobID)
        {
            return _jobsDict[jobID];
        }
        public List<Job> GetJob(List<Guid> jobIDs)
        {
            return _jobsDict.Values.Where(x => jobIDs.Contains(x.ID) == true).ToList();
        }
        public List<Job> GetJob()
        {
            return _jobsDict.Values.ToList();
        }

        public List<Job> GetJobsForOrgChar(Guid ID)
        {
            List<Guid> IDs = new List<Guid>();
            if (People.IsChar(ID))
            {
                IDs = People.GetChar(ID).Jobs;
            }
            if (People.IsOrg(ID))
            {
                IDs = People.GetOrg(ID).Jobs;
            }
            List<Job> jobs = new List<Job>();
            foreach (var id in IDs)
            {
                jobs.Add(GetJob(id));
            }
            return jobs;
        }
    }
}
