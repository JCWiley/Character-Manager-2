using System.Collections.ObjectModel;

namespace CM4_Core.Models
{
    public class Job : ModelBaseClass, IEquatable<Job>
    {
        public Job(int CreationDate, Guid? OwnerID = null, Guid? ParentJobId = null)
        {
            Required_Items = new List<Guid>();
            Summary = "Empty Job";
            Description = string.Empty;
            IsCurrentlyProgressing = true;
            IsRecurring = false;
            Days_Since_Creation = 0;
            Creation_Date = CreationDate;
            Duration = 0;
            Progress = 0;
            StartDate = CreationDate;
            SuccessChance = 20;
            FailureChance = 20;
            OwnerEntity = OwnerID ?? Guid.Empty;
            OwnerJob = ParentJobId ?? Guid.Empty;
        }

        public Job()
        {
            Required_Items = new List<Guid>();
            Summary = string.Empty;
            Description = string.Empty;
            IsCurrentlyProgressing = true;
            IsRecurring = false;
            Days_Since_Creation = 0;
            Creation_Date = 0;
            Duration = 0;
            Progress = 0;
            StartDate = 0;
            SuccessChance = 20;
            FailureChance = 20;
            OwnerEntity = Guid.Empty;
            OwnerJob = Guid.Empty;
        }

        public bool Equals(Job? other)
        {
            if (other == null)
            {
                return false;
            }
            return ((ModelBaseClass)this).Equals((ModelBaseClass)other);
        }

        public bool CheckIsComplete()
        {
            return Progress >= Duration;
        }

        //Values used to determine completion
        public bool IsCurrentlyProgressing { get; set; }
        public bool IsRecurring { get; set; }
        public int Days_Since_Creation { get; set; }
        public int Creation_Date { get; }
        public int Duration { get; set; }
        public int Progress { get; set; }

        //Derived values



        //Values with general information
        public string Summary { get; set; }
        public string Description { get; set; }
        public List<Guid> Required_Items { get; set; }
        public int StartDate { get; set; }
        public int SuccessChance { get; set; }
        public int FailureChance { get; set; }
        public Guid OwnerEntity { get; set; }
        public Guid OwnerJob { get; set; }








    }
}
