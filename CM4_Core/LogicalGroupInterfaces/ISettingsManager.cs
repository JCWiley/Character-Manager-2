using CM4_Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM4_Core.LogicalGroupInterfaces
{
    public interface ISettingsManager
    {
        public void OpenProject(string Path);
        public void NewProject(string Path);

        public string DataPath { get;}
    }
}
