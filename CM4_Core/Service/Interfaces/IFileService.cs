using CM4_Core.DataAccess;
using CM4_Core.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.Service.Interfaces
{
    public interface IFileService
    {
        public void OpenProject(string Path);

        public void NewProject(string Path);
    }
}
