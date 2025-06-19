using CM4_Core.Models;
using CM4_UI.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CM4_UI.ObservableModels
{
    public class ObservableJob : ViewModelBase
    {
        private Job DataSource;
        public ObservableJob(Job _source)
        {
            DataSource = _source;
        }

        public ObservableJob()
        {
            DataSource = new Job(0);
        }

        public Job GetDataSource()
        {
            //processing to make sure data source matches current state

            return DataSource;
        }

        public void AddSubtask()
        {

        }

        public void AddCustomEvent()
        {

        }

        //Properties
        public Guid ID
        {
            get
            {
                return DataSource.ID;
            }
        }

        //

        //public List<ObservableItem> Required_Items
        //{
        //    get
        //    {
        //        return DataSource.Required_Items;
        //    }
        //    set
        //    {
        //        DataSource.Required_Items = value;
        //        this.RaisePropertyChanged(nameof(Required_Items));
        //    }
        //}

        public bool IsComplete
        {
            get
            {
                return DataSource.CheckIsComplete();
            }
        }

        public string Summary
        {
            get
            {
                return DataSource.Summary;
            }
            set
            {
                DataSource.Summary = value;
                this.RaisePropertyChanged(nameof(Summary));
            }
        }

        public string Description
        {
            get
            {
                return DataSource.Description;
            }
            set
            {
                DataSource.Description = value;
                this.RaisePropertyChanged(nameof(Description));
            }
        }

        public bool IsCurrentlyProgressing
        {
            get
            {
                return DataSource.IsCurrentlyProgressing;
            }
            set
            {
                DataSource.IsCurrentlyProgressing = value;
                this.RaisePropertyChanged(nameof(IsCurrentlyProgressing));
            }
        }

        public bool IsRecurring
        {
            get
            {
                return DataSource.IsRecurring;
            }
            set
            {
                DataSource.IsRecurring = value;
                this.RaisePropertyChanged(nameof(IsRecurring));
            }
        }

        public int Creation_Date
        {
            get
            {
                return DataSource.Creation_Date;
            }
        }

        public int Duration
        {
            get
            {
                return DataSource.Duration;
            }
            set
            {
                DataSource.Duration = value;
                this.RaisePropertyChanged(nameof(Duration));
            }
        }

        public int Progress
        {
            get
            {
                return DataSource.Progress;
            }
        }

        public int StartDate
        {
            get
            {
                return DataSource.StartDate;
            }
        }

        public int SuccessChance
        {
            get
            {
                return DataSource.SuccessChance;
            }
            set
            {
                DataSource.SuccessChance = value;
                this.RaisePropertyChanged(nameof(SuccessChance));
            }
        }

        public int FailureChance
        {
            get
            {
                return DataSource.FailureChance;
            }
            set
            {
                DataSource.FailureChance = value;
                this.RaisePropertyChanged(nameof(FailureChance));
            }
        }

        //public Guid OwnerEntity
        //{
        //    get
        //    {
        //        return DataSource.OwnerEntity;
        //    }
        //    set
        //    {
        //        DataSource.OwnerEntity = value;
        //        this.RaisePropertyChanged(nameof(OwnerEntity));
        //    }
        //}

        //public Guid OwnerJob
        //{
        //    get
        //    {
        //        return DataSource.OwnerJob;
        //    }
        //    set
        //    {
        //        DataSource.OwnerJob = value;
        //        this.RaisePropertyChanged(nameof(OwnerJob));
        //    }
        //}

        //public ObservableCollection<ObservableJob> Subtasks
        //{
        //    get
        //    {

        //    }
        //}
    }
}
