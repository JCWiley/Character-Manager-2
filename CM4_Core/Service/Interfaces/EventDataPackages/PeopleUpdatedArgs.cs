using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Interfaces.EventDataPackages
{
    public class PeopleUpdatedArgs : EventArgs
    {
        public PeopleUpdatedArgs(HashSet<Guid> _updatedChars, HashSet<Guid> _updatedOrgs)
        {
            AllUpdated = false;
            UpdatedGuids = _updatedOrgs;
            UpdatedGuids.UnionWith(_updatedChars);
        }
        public PeopleUpdatedArgs(Guid target)
        {
            AllUpdated = false;
            UpdatedGuids = new HashSet<Guid>();
            UpdatedGuids.Add(target);
        }
        public PeopleUpdatedArgs()
        {
            AllUpdated = true;
            UpdatedGuids = new HashSet<Guid>();
        }

        public bool AllUpdated { get; }

        public HashSet<Guid> UpdatedGuids { get; }

    }
}
